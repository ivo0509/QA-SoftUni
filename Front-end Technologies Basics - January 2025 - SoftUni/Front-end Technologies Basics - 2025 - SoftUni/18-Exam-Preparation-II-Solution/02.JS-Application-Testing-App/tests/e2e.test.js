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

let petName = "";

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
            await page.locator("#repeatPassword").fill(user.confirmPass);
            
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
            await expect(page.locator('nav >> text=Dashboard')).toBeVisible();
            await expect(page.locator('nav >> text=Create Postcard')).toBeVisible();
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            await expect(page.locator('nav >> text=Login')).toBeHidden();
            await expect(page.locator('nav >> text=Register')).toBeHidden();
        });

        test('guest user should see correct navigation', async () => {
            await page.goto(host);

            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Dashboard')).toBeVisible();
            await expect(page.locator('nav >> text=Create Postcard')).toBeHidden();
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

        test('create with valid data successfully creates the postcard', async () => {
            await page.click('text=Create Postcard');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 10000);
            petName = `Pet name_${random}`;

            await page.fill('[name="name"]', petName);
            await page.fill('[name="breed"]', "Random breed");
            await page.fill('[name="age"]', "3 years");
            await page.fill('[name="weight"]', "5kg");
            await page.fill('[name="image"]', "/images/cat-create.jpg");

            await page.click('[type="submit"]');
            
            await expect(page.locator('div.animals-board h2.name', { hasText: petName })).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });

        test('edit with valid data successfully modifies the postcard', async () => {
            await page.goto(host + '/catalog');

            const divLocator = page.locator(`div.animals-board:has(h2:text("${petName}"))`);
            await divLocator.locator('a:text("Details")').click();
            await page.click('text=Edit');

            await page.waitForSelector('form');

            petName = petName + "_edited";
            await page.locator('[name="name"]').fill(petName);
            
            await page.click('[type="submit"]');

            await expect(page.locator('div.animalInfo h1', { hasText: `Name: ${petName}` })).toHaveCount(1);
        });

        test('delete successfully deletes the postcard', async () => {
            await page.goto(host + '/catalog');

            const divLocator = page.locator(`div.animals-board:has(h2:text("${petName}"))`);
            await divLocator.locator('a:text("Details")').click();

            await page.click('text=Delete');
            
            await expect(page.locator('div.animals-board h2.name', { hasText: petName })).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    });
})