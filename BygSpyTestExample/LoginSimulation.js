const puppeteer = require('puppeteer');

(async () => {
    const browser = await puppeteer.launch({ headless: false }); // Launch browser in non-headless mode for visibility
    const page = await browser.newPage();

    await page.goto('https://localhost:7289/', { waitUntil: 'domcontentloaded' }); // Wait for DOM content to be loaded

    //// Wait for the email and password input fields to be present
    //await page.waitForSelector('input[name="email"]');
    //await page.waitForSelector('input[name="password"]');

    //// Execute JavaScript to fill in email and password fields
    //await page.evaluate(() => {
    //    window.fillLoginForm('esb@mail.com', '5678');
    //});

    await delay(1000);

    await page.evaluate(() => {
        document.querySelector('button#login').click();
    });

    await page.waitForNavigation();

    const metrics = await page.metrics();
    console.log(metrics);

    // Close the browser
    //await browser.close();
})();

async function delay(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}
