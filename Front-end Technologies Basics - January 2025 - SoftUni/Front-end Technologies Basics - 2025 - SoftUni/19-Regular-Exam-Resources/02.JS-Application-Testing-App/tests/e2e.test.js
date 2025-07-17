const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

let bookTitle = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    
    describe("authentication", () => {
        test("Register with valid data", async () => {
            await page.goto(host);
            await page.click("//a[@href='/register']");
            await page.waitForSelector("//form");

            let random = Math.floor(Math.random() * 10000);
            user.email = `user_${random}@gmail.com`;
            await page.fill("//input[@type='email']", user.email);
            await page.fill("//input[@type='password']", user.password);
            await page.fill("//input[@name='conf-pass']", user.confirmPass);
            await page.click("//button[@type='submit']");


           await expect(page.locator("//a[@href='/logout']")).toBeVisible();
           
           expect(page.url()).toBe(host + '/');
           
        })

        test("Login with valid data", async () => {
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.locator("//input[@name='password']").fill(user.password);
            await page.click("//button[@type='submit']");

            await expect(page.locator("//a[@href='/logout']")).toBeVisible();
            expect(page.url()).toBe(host + '/');


        })

        test("Logout from the application", async () => {
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.locator("//input[@name='password']").fill(user.password);
            await page.click("//button[@type='submit']");
            await page.click("//a[@href='/logout']");

            await expect(page.locator("//a[@href='/login']")).toBeVisible();
            expect(page.url()).toBe(host + '/');


        })
    });

    describe("navbar", () => {
        test("Navigation to logged in users", async () => {
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.locator("//input[@name='password']").fill(user.password);
            await page.click("//button[@type='submit']");

            await expect(page.locator("//a[@href='/']")).toBeVisible();
            await expect(page.locator("//a[@href='/collection']")).toBeVisible();
            await expect(page.locator("//a[@href='/search']")).toBeVisible();
            await expect(page.locator("//a[@href='/create']")).toBeVisible();
            await expect(page.locator("//a[@href='/logout']")).toBeVisible();
            await expect(page.locator("//a[@href='/login']")).toBeHidden();
            await expect(page.locator("//a[@href='/register']")).toBeHidden();
            


        })


        test("Navigation to non-logged users", async() => {
            await page.goto(host);
           

            await expect(page.locator("//a[@href='/']")).toBeVisible();
            await expect(page.locator("//a[@href='/collection']")).toBeVisible();
            await expect(page.locator("//a[@href='/search']")).toBeVisible();
            await expect(page.locator("//a[@href='/login']")).toBeVisible();
            await expect(page.locator("//a[@href='/register']")).toBeVisible();
            await expect(page.locator("//a[@href='/create']")).toBeHidden();
            await expect(page.locator("//a[@href='/logout']")).toBeHidden();
        })
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.locator("//input[@name='password']").fill(user.password);
            await page.click("//button[@type='submit']");
        })

        test("Create a book", async () => {

            await page.click("//a[@href='/create']");
            await page.waitForSelector("//form");
            
            let random = Math.floor(Math.random() * 10000);
            bookTitle = `Book_Title_${random}`;

            await page.fill("//input[@id ='title']", bookTitle);
            await page.fill("//input[@id ='coverImage']",  './images/random_cover.webp');
            await page.fill("//input[@id ='year']",  '2012');
            await page.fill("//input[@id ='author']", "Ivan Vazov");
            await page.fill("//input[@id ='genre']",  "Someone Genre");
            await page.fill("//textarea[@name='description']",  "adsadada");
            await page.click("//button[@type='submit']");
             

            await expect(page.locator("//div[@class ='book-details']//h2[text() = 'My Harry Potter edited 2']")).toBeVisible();
            expect(page.url()).toBe(host + '/collection');



        })


        test("Edit a book", async () => {
             
            await page.click("//a[text()='Search']");
            await page.waitForSelector("//form");
        

           
            await page.fill("//input[@name = 'search']", bookTitle);
            await page.click("//button[@type = 'submit']");
            await page.click("//li//a");
            await page.click("//a[@class='edit-btn']");
            await page.waitForSelector("//form");





            bookTitle = bookTitle + "_edited"; 

         
            
            



            await page.fill("//input[@name = 'title']", bookTitle);
            await page.click("//button[@class ='save-btn']");

            await expect(page.locator('//div[@class="book-info"]//h2', {hasText : bookTitle})).toHaveCount(1);
             

           
            
             
                


        })


        test("Delete a book", async () => {
            await page.click("//a[text()='Search']");
            await page.waitForSelector("//form");
        

           
            await page.fill("//input[@name = 'search']", bookTitle);
            await page.click("//button[@type = 'submit']");

            await page.click("//li//a");
            await page.click("//a[@class ='delete-btn']");
             


            await expect(page.locator('//div[@class="book-details"]//h2', {hasText : bookTitle})).toHaveCount(0);
            expect(page.url()).toBe(host + '/collection');
        })
    });
});