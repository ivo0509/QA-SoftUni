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

let albumName = "";

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
        test("register with valid data redirects to correct page", async () => {
            await page.goto(host);
            await page.click('text=Register');

            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 1000);
            user.email = `abv_${random}@abv.bg`;

            await page.locator("#email").fill(user.email);
            await page.locator("#password").fill(user.password);
            await page.locator("#conf-pass").fill(user.confirmPass);
            
            page.click('[type="submit"]');
            
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("login with valid data redirects to correct page", async () => {
            await page.goto(host);
            await page.click('text=Login');

            await page.waitForSelector('form');
            
            await page.locator("#email").fill(user.email);
            await page.locator("#password").fill(user.password);

            page.click('[type="submit"]');
            
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('logout redirects to correct page', async () => {
            await page.goto(host);
            await page.click('text=Login');

            await page.waitForSelector('form');
            
            await page.locator("#email").fill(user.email);
            await page.locator("#password").fill(user.password);
            await page.click('[type="submit"]');

            await page.locator('nav >> text=Logout').click();
            
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    })

    describe("navbar", () => {
        test('logged user should see correct navigation', async () => {
            await page.goto(host);

            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator("#email").fill(user.email);
            await page.locator("#password").fill(user.password);
            await page.click('[type="submit"]')

            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Catalog')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();
            await expect(page.locator('nav >> text=Create Album')).toBeVisible();
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            await expect(page.locator('nav >> text=Login')).toBeHidden();
            await expect(page.locator('nav >> text=Register')).toBeHidden();
        });

        test('guest user should see correct navigation', async () => {
            await page.goto(host);

            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Catalog')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();
            await expect(page.locator('nav >> text=Create Album')).toBeHidden();
            await expect(page.locator('nav >> text=Logout')).toBeHidden();
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            await expect(page.locator('nav >> text=Register')).toBeVisible();
        });
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            //login configuration for execution before each test
            await page.goto(host);

            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator("#email").fill(user.email);
            await page.locator("#password").fill(user.password);
            await page.click('[type="submit"]')
        });

        test('create with valid data successfully creates the album', async () => {
            await page.click('text=Create Album');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 10000);
            albumName = `Random namer_${random}`; //creating a unique name is important for the next test. It makes searching easy and ensures we have the right album for edit testing

            await page.fill('[name="name"]', albumName);
            await page.fill('[name="imgUrl"]', "/images/pinkFloyd.jpg");
            await page.fill('[name="price"]', "15");
            await page.fill('[name="releaseDate"]', "29 June 2024");
            await page.fill('[name="artist"]', "Unknown");
            await page.fill('[name="genre"]', "Random genre");
            await page.fill('[name="description"]', "Random description");

            await page.click('[type="submit"]');
            
            await expect(page.locator('div.text-center p.name', { hasText: albumName })).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });

        test('edit with valid data successfully modifies the album', async () => {
            await page.click('text=Search'); //click on navbar search button

            await page.fill('#search-input', albumName); //use the saved album name for search
            await page.click('.button-list'); //click on search button to the input field

            await page.locator(`text=Details`).first().click();
            await page.click('text=Edit');

            await page.waitForSelector('form');

            albumName = albumName + "_edited"; //changing album name, so we save the changes in the variable. This is necessary because we search for the album by name. Therefore, if the name changes, we will search for the new name in the next test for deletion.
            await page.locator('[name="name"]').fill(albumName);
            
            await page.click('[type="submit"]');

            await expect(page.locator('h1', { hasText: `Name: ${albumName}` })).toHaveCount(1);
        });

        test('delete successfully deletes the album', async () => {
            await page.click('text=Search'); //click on navbar search button

            await page.fill('#search-input', albumName); //search by album name
            await page.click('.button-list'); //click on search button to the input field

            await page.locator(`text=Details`).first().click(); 

            await page.click('text=Delete');
            
            await expect(page.locator('div.text-center p.name', { hasText: albumName })).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    })
})