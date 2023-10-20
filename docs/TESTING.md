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
- First install the required software (mostly Node.js) and cloned the repository, like told in the [contributing guidelines](/docs/CONTRIBUTING.md).
- In the root, you might need to re-run `npm install` to install playwright.

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
UI-tests consist of three different parts: Navigation, Actions, Assertions (what you expect). And these tests can be isolated, compare this to a method if you will. 
[Docs](https://playwright.dev/docs/writing-tests).

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
[Docs](https://playwright.dev/docs/codegen-intro).

To start recording test code you can just start the codegen and start testing, `the first step should always be opening the correct URL/this can also be set behind the command`. This command runs the codegen: `npx playwright codegen`

The generated code can be used for testing!

Other (emulation) [options](https://playwright.dev/docs/codegen-intro#emulation) that can be configured include devices, color theme, geolocation, language, timezones
(The website at the end of the command can be changed to whatever you like).
Emulation options, respectively:
- `npx playwright codegen --device="iPhone 13" playwright.dev`
- `npx playwright codegen --color-scheme=dark playwright.dev`
- `npx playwright codegen --timezone="Europe/Madrid" --geolocation="40.4179328,-3.7140031" --lang="es-ES" bing.com/maps`


## API tests
> Coming soon, depends on how API will be used, or if there is a direct connection to the database
- Install [Postman](https://www.postman.com/downloads/) for API testing.
- Install Newman by running this command in commandprompt `npm install -g newman`.
### Running API tests
> Coming soon
### Writing API tests
> Coming soon

## Unit tests
We employ a unit testing structure known as Component-Based Unit Testing. In this approach, each individual folder within the application corresponds to a distinct folder in the testing directory. This organization simplifies the process of locating and modifying tests associated with specific components.
### Running unit tests
- When the project is opened in Visual Studio you can open right click on the `Test` project.
- The tests can be directly started by clicking `Run tests`.
- In the `Test explorer` individual tests can be ran.
### Writing unit tests
Creating unit tests is a flexible process, adaptable to your needs, ranging from simplicity to complexity. Typically, the individual responsible for developing a particular functionality also creates the associated test, if deemed necessary.

It's important to emphasize that when testing core functionality, it's essential to ensure that references are correctly established to access this code, and the focus should solely be on examining business logic, not testing user interface elements.

A basic example can be found here:

```cs
using Xunit;

namespace MyFirstUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
```
> #### AAA-Pattern

The Arrange-Act-Assert (AAA) pattern is a common and widely used structure for organizing and writing unit tests in software development. It provides a clear and structured way to set up, execute, and validate the outcomes of a test case. Here's a breakdown of each step in the AAA pattern:

- Arrange:
In this initial phase, you set up the preconditions for your test. This typically involves creating instances of the classes or objects you need, initializing variables, and arranging the environment in a way that prepares it for the specific test scenario.
You might also set the context or state of the system being tested.

- Act:
This is where you perform the action or operation that you want to test. This is the part of the test where you're actually invoking the method or functionality you're interested in evaluating.
You are simulating the behavior you want to examine under specific conditions.

- Assert:
After the "Act" phase, you check the results and verify that they meet the expected outcomes or conditions.
You use assertions to compare the actual results from the "Act" phase with the expected results or expected state.
If the actual results match the expected results, the test case passes. If they don't match, the test case fails.

Here's a simple example to illustrate the AAA pattern in a unit test for a function that validates an email adress:
```cs
  [Fact]
  public void ValidEmail()
  {
    //Arrange
    var mailManager = new MailManager();
    const string mailAddress = "john.smith@company.com";
 
    //Act
    bool isValid = mailManager.IsValidAddress(mailAddress);
 
    //Assert
    Assert.True(isValid, $"The email {mailAddress} is not valid");
  }
```

