UI Test Automation Framework
============================

This framework automates testing for the Ryanair (Angular) website using C# and Selenium. It's designed to be easy to maintain, scalable, and reliable, with clear reporting for test results. Below, you'll find an overview of the framework, how to set it up, run tests, and add new tests.

Framework Overview
------------------

The framework uses a modular design to keep code organized and reusable, making it simple to add new tests or update existing ones. 

Key features include:

-   **Page Objects**: Each webpage (e.g., Home, Login) has its own class to manage interactions, keeping tests clean and focused.

-   **Centralised WebDriver Management**: Ensures browser sessions are handled consistently across tests, supporting parallel execution.

-   **Reusable Helpers**: Common tasks like waiting for elements or asserting conditions are simplified with helper classes.

-   **Detailed Reporting**: Uses Allure to generate clear, visual reports with screenshots for failed tests.

-   **Environment Configuration**: Sensitive data like login credentials are securely stored in a .env file.

-   **CI Integration**: Includes a GitHub Actions workflow for automated testing and report publishing.

Project Structure
-----------------

The framework is organized for clarity and ease of use:

-   **Tests/**: Contains test classes (e.g., FlightSearchTests.cs, LoginTests.cs) for specific features.

-   **Pages/**: Page object classes (e.g., HomePage.cs, LoginPage.cs) for interacting with webpages.

-   **Locators/**: Stores element locators (e.g., HomePageLocators.cs) to keep them separate and maintainable.

-   **Drivers/**: Manages the WebDriver (e.g., DriverManager.cs, WebDriverFactory.cs) for browser control.

-   **Helpers/**: Utility classes (e.g., WaitHelper.cs, AssertHelper.cs) for common tasks.

-   **allureConfig.json**: Configures Allure reporting for test results.

-   **.env**: Stores environment variables like login credentials.

-   **Makefile**: Provides shortcuts for running tests and generating reports.

Prerequisites
-------------

To run the framework, ensure you have:

-   **.NET 8.0 SDK**: Installed on your machine (download here).

-   **Chrome Browser**: The framework uses Chrome in headless mode.

-   **Allure CLI**: For generating and viewing test reports (installation guide).

-   **Git**: To clone the repository.

-   A text editor or IDE like Visual Studio or Rider.

Setup Instructions
------------------

1.  **Clone the Repository**:

    ```
    git clone <repository-url>
    cd <repository-folder>
    ```

2.  **Restore Dependencies**: Run the following command to install required packages:

    ```
    dotnet restore UITests/UITests.csproj
    ```

3.  **Configure Environment Variables**: Create a .env file in the UITests/ folder (or use the provided example) with:

    ```
    RYANAIR_EMAIL=your-email@example.com
    RYANAIR_PASSWORD=your-password
    ```

    Replace with valid Ryanair credentials for testing.

4.  **Build the Project**:

    ```
    dotnet build UITests/UITests.csproj
    ```

Running Tests
-------------

The framework includes commands to run tests and generate reports. Use the Makefile for simplicity:

-   **Run All Tests**:

    ```
    make test
    ```

-   **Run Smoke Tests** (quick, critical tests):

    ```
    make test-smoke
    ```

-   **Run Regression Tests** (comprehensive tests):

    ```
    make test-regression
    ```

-   **View Allure Report**: After running tests, generate and view the report:

    ```
    make report
    ```

    This opens a browser with detailed test results, including steps and screenshots for failures.

Adding a New Test
-----------------

To add a new test, follow these steps to keep the framework consistent and maintainable.

1.  **Create a New Test Class**:

    -   Navigate to UITests/Tests/.

    -   Create a new folder if testing a new feature (e.g., Booking/ for booking-related tests).

    -   Add a new test class, e.g., NewFeatureTests.cs, inheriting from BaseTest.

    Example:

    ```
    using NUnit.Framework;
    using Allure.NUnit;
    using Allure.NUnit.Attributes;
    using Allure.Net.Commons;
    using UITests.Pages;
    using UITests.Helpers;

    namespace UITests.Tests
    {
        [TestFixture]
        [AllureNUnit]
        [AllureSuite("New Feature")]
        [AllureFeature("New Feature Testing")]
        [AllureOwner("Your Name")]
        public class NewFeatureTests : BaseTest
        {
            [Test]
            [AllureDescription("Validates the new feature works as expected.")]
            public void Test_NewFeature()
            {
                var homePage = PageFactory.HomePage;
                AllureApi.Step("Perform action on homepage", () => homePage.SomeAction());
                AssertHelper.StepAssert(() => homePage.IsActionSuccessful(), "Action should succeed");
            }
        }
    }
    ```

2.  **Update or Create Page Objects**:

    -   If the test interacts with a new page, create a new class in UITests/Pages/ (e.g., NewPage.cs).

    -   Add methods for user actions and element interactions.

    -   Update PageFactory.cs to include the new page:

        ```
        public static NewPage NewPage => new(DriverManager.Driver);
        ```

3.  **Define Locators**:

    -   Create or update a locators class in UITests/Locators/ (e.g., NewPageLocators.cs).

    -   Add element locators using By selectors:

        ```
        public static class NewPageLocators
        {
            public static readonly By SomeElement = By.CssSelector("[data-ref='some-element']");
        }
        ```

4.  **Run the Test**:

    -   Use make test to run all tests, including the new one.

    -   Verify the test appears in the Allure report.

Key Design Choices
------------------

-   **Page Object Model**: Separates page interactions from test logic, making tests easier to read and maintain.

-   **Thread-Safe WebDriver**: Uses ThreadLocal to support parallel test execution without conflicts.

-   **Allure Reporting**: Provides detailed, step-by-step reports with screenshots for debugging.

-   **Environment Variables**: Keeps sensitive data secure and configurable.

-   **Modular Helpers**: Simplifies common tasks like waiting or asserting, reducing code duplication.

-   **CI Workflow**: Automates testing and reporting via GitHub Actions for consistent results.