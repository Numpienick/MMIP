<!-- omit in toc -->
# Testing in MMIP
<!-- omit in toc -->
## Table of Contents
- [Setting up for Windows](#setting-up-for-windows)
- [UI-tests](#ui-tests)
  - [Running UI-tests](#running-ui-tests)
  - [Writing UI-tests](#writing-ui-tests)
- [API tests](#api-tests)
  - [Running API tests](#running-api-tests)
  - [Writing API tests](#writing-api-tests)
- [Unit tests](#unit-tests)
  - [Running unit tests](#running-unit-tests)
  - [Writing unit tests](#writing-unit-tests)

## Setting up for Windows
- First install the required software (mostly NPM) and cloned the repository, like told in the [contributing guidelines](CONTRIBUTING.md)
- Install Postman for API testing

## UI-tests
The UI-tests will be run by [Playwright](https://playwright.dev/docs/intro). Playwright is a framework for Web Testing and Automation. It allows testing Chromium, Firefox and WebKit with a single API. Playwright is built to enable cross-browser web automation that is ever-green, capable, reliable and fast.

### Running UI-tests
- Open command prompt inside `Test > ui-tests`

Inside that directory, you can run several commands:
- `npx playwright test` Runs the end-to-end tests (in 3 browsers automatically: Firefox, Chromium and Webkit) and generates a report for it (opens if failed).
- `npx playwright show-report` Shows latest report
- `npx playwright test --ui` Starts the interactive UI mode.
- `npx playwright test --project=chromium` Runs the tests only on Desktop Chrome.
- `npx playwright test example` Runs the tests in a specific file.
- `npx playwright test --debug` Runs the tests in debug mode.
- `npx playwright codegen` Auto generate tests with Codegen.

### Writing UI-tests
> #### Manually
UI-tests are buildup in different parts: Navigation, Actions, Assertions (what you expect). And these tests can be isolated, compare this to a method if you will. 
[Docs](https://playwright.dev/docs/writing-tests)

An example of a spec.ts can look like this:
```ts
    import { test, expect } from '@playwright/test';

    test('get started link', async ({ page }) => {      // Code isolation
        await page.goto('https://playwright.dev/');     // Navigation

        // Click the get started link.
        await page.getByRole('link', { name: 'Get started' }).click(); //Action

        // Expects page to have a heading with the name of Installation.
        await expect(page.getByRole('heading', { name: 'Installation' })).toBeVisible(); //Assertion

        //Another example for assertion
        // Expect a title "to contain" a substring.
        await expect(page).toHaveTitle(/Playwright/); //Another assertion
    });
```
> #### Recording
Playwright comes with the ability to generate tests out of the box and is a great way to quickly get started with testing. It will open two windows, a browser window where you interact with the website you wish to test and the Playwright Inspector window where you can record your tests, copy the tests, clear your tests as well as change the language of your tests.
[Docs](https://playwright.dev/docs/codegen-intro)

To start recording test code you can just start the codegen and start testing, `the first step should always be opening the correct URL/this can also be set behind the command`.

`npx playwright codegen`

The generated code can be used for testing!

Other (emulation) options that can be configured include devices, color theme, geolocation, language, timezones
(The website at the end of the command can be changed to whatever you like)
Emulation options, respectively:
- `npx playwright codegen --device="iPhone 13" playwright.dev`
- `npx playwright codegen --color-scheme=dark playwright.dev`
- `npx playwright codegen --timezone="Europe/Madrid" --geolocation="40.4179328,-3.7140031" --lang="es-ES" bing.com/maps`


## API tests
> Coming soon
### Running API tests
> Coming soon
### Writing API tests
> Coming soon

## Unit tests
> Coming soon
### Running unit tests
> Coming soon
### Writing unit tests