const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let game= {
    title: "",
    category: "",
    id: "",
    maxLevel: "99",
    imageUrl: "https://jpeg.org/images/jpeg-home.jpg",
    summary: "This is an amazing game"
}

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
            await page.locator("#register-password").fill(user.password);
            await page.locator("#confirm-password").fill(user.confirmPass);
            
            page.click('[type="submit"]');
            
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
        
        test("register does not work with empty fields", async () => {
            await page.goto(host);
            await page.click('text=Register');

            expect(page.url()).toBe(host + '/register');
        });

        test("login with valid data redirects to correct page", async () => {
            await page.goto(host);
            await page.click('text=Login');

            await page.waitForSelector('form');
            
            await page.locator("#email").fill(user.email);
            await page.locator("#login-password").fill(user.password);
            
            page.click('[type="submit"]');
            
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("login does not work with empty fields", async () => {
            await page.goto(host);
            await page.click('text=Login');

            expect(page.url()).toBe(host + '/login');
        });

        test('logout redirects to correct page', async () => {
            await page.goto(host);
            await page.click('text=Login');

            await page.waitForSelector('form');
            
            await page.locator("#email").fill(user.email);
            await page.locator("#login-password").fill(user.password);
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
            await page.locator("#login-password").fill(user.password);
            await page.click('[type="submit"]')

            await expect(page.locator('nav >> text=All games')).toBeVisible();
            await expect(page.locator('nav >> text=Create Game')).toBeVisible();
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            await expect(page.locator('nav >> text=Login')).toBeHidden();
            await expect(page.locator('nav >> text=Register')).toBeHidden();
        });

        test('guest user should see correct navigation', async () => {
            await page.goto(host);

            await expect(page.locator('nav >> text=All games')).toBeVisible();
            await expect(page.locator('nav >> text=Create Game')).toBeHidden();
            await expect(page.locator('nav >> text=Logout')).toBeHidden();
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            await expect(page.locator('nav >> text=Register')).toBeVisible();
        });
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);

            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator("#email").fill(user.email);
            await page.locator("#login-password").fill(user.password);
            await page.click('[type="submit"]')
        });

        test('create does NOT work with empty fields', async () => {
            await page.click('text=Create Game');
            await page.waitForSelector('form');
            await page.click('[type="submit"]');

            expect(page.url()).toBe(host + '/create');
        });

        test('create with valid data successfully creates the game', async () => {
            let random = Math.floor(Math.random() * 1000);
            game.title = `Game title ${random}`;
            game.category = `Game category ${random}`;

            await page.click('text=Create Game');
            await page.waitForSelector('form');

            await page.fill('[name="title"]', game.title);
            await page.fill('[name="category"]', game.category);
            await page.fill('[name="maxLevel"]', game.maxLevel);
            await page.fill('[name="imageUrl"]', game.imageUrl);
            await page.fill('[name="summary"]', game.summary);

            await page.click('[type="submit"]');
            
            await expect(page.locator('.game h3', { hasText: game.title })).toHaveCount(1);
            expect(page.url()).toBe(host + '/');
        });

        test('details show edit/delete buttons for owner', async () => {
            await page.goto(host + "/catalog");

            await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);

            game.id = page.url().split('/').pop();

            await expect(page.locator('text="Delete"')).toBeVisible();
            await expect(page.locator('text="Edit"')).toBeVisible();
        });

        test('non-owner does NOT see delete and edit buttons', async () => {
            await page.goto(host + "/catalog");
            await page.click(`.allGames .allGames-info:has-text("MineCraft") >> .details-button`);

            await expect(page.locator('text="Delete"')).toBeHidden();
            await expect(page.locator('text="Edit"')).toBeHidden();
        });

        test('edit with valid data successfully modifies the game', async () => {
            await page.goto(host + "/catalog");

            await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);
            await page.click('text=Edit');

            await page.waitForSelector('form');

            game.title = `${game.title}_edit`;

            await page.locator('[name="title"]').fill(game.title);

            await page.click('[type="submit"]');
            
            await expect(page.locator('.game-header h1', { hasText: game.title })).toHaveCount(1);
            expect(page.url()).toBe(host + `/details/${game.id}`);
        });

        test('delete successfully deletes the game', async () => {
            await page.goto(host + "/catalog");

            await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);

            await page.click('text=Delete');
            
            await expect(page.locator('.game h3', { hasText: game.title })).toHaveCount(0);
            expect(page.url()).toBe(host + '/');
        });
    })

    describe('Home Page', () => {
        test('show home page', async () => {
            await page.goto(host);

            expect(page.locator('.welcome-message h2')).toHaveText("ALL new games are");
            expect(page.locator('.welcome-message h3')).toHaveText("Only in GamesPlay");
            expect(page.locator('#home-page h1')).toHaveText("Latest Games");
            
            const gameDivs = await page.locator('#home-page .game').all();
            
            expect(gameDivs.length).toBeGreaterThanOrEqual(3);
        });
    });
})