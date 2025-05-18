DotNet Selenium Framework -- Senior SDET Interview Prep
=======================================================

Overview
--------

This project is a C# and Selenium-based UI test automation framework. It automates UI testing for the Ryanair website, focusing on login and flight search functionalities.

The objective is to showcase ability in building a scalable, maintainable test automation framework with clean architecture, robust test execution, and integration with reporting and CI/CD pipelines.

Core Features
-------------

-   Built using .NET 6, Selenium WebDriver, and NUnit.

-   Fully implemented Page Object Model (POM) structure for maintainability.

-   Central Driver Management with thread-safe WebDriver instances (DriverManager, WebDriverFactory).

-   Explicit Waits via WaitHelper to handle dynamic web elements.

-   Custom Assertion Helpers with Allure step integration for readable test reports.

-   Parallel Execution of test fixtures (up to 4 concurrently).

-   Integrated Allure Reporting with screenshots on test failure.

-   CI/CD Integration via GitHub Actions, running tests on push/pull requests.

-   Hosted Test Reports available at: https://markhughes321.github.io/dotnet-selenium-framework/10/.

-   Environment Variable Management for secure credential handling (via .env).

-   Makefile for simplified test execution and report generation.

Folder Structure
----------------
```
├── Makefile
├── Readme.md
├── SeleniumFramework.sln
├── UITests
│   ├── Drivers
│   │   ├── DriverManager.cs
│   │   └── WebDriverFactory.cs
│   ├── Helpers
│   │   ├── AllureSetup.cs
│   │   ├── AssertHelper.cs
│   │   ├── Constants.cs
│   │   ├── TestConfig.cs
│   │   └── WaitHelper.cs
│   ├── Locators
│   │   ├── HomePageLocators.cs
│   │   └── LoginPageLocators.cs
│   ├── Pages
│   │   ├── HomePage.cs
│   │   ├── LoginPage.cs
│   │   └── PageFactory.cs
│   ├── Properties
│   │   └── AssemblyInfo.cs
│   ├── Tests
│   │   ├── Authentication
│   │   │   └── LoginTests.cs
│   │   ├── Base
│   │   │   └── BaseTest.cs
│   │   └── Booking
│   │       └── FlightSearchTests.cs
│   ├── UITests.csproj
│   └── allureConfig.json
```

Getting Started
---------------

1.  **Clone the repository**\
    `git clone https://github.com/markhughes321/dotnet-selenium-framework.git`

2.  **Install .NET 6 SDK**\
    Download from: <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>

3.  **Install Allure commandline (optional for local reporting)**\
    ```    
    npm install -g allure-commandline --save-dev
    ```

4.  **Configure environment variables**\
    Create a `.env` file in the root:
    ```
    RYANAIR_EMAIL=your_email@mail.com
    RYANAIR_PASSWORD=your_password
    ```

5.  **Run the tests locally**
    ```
    dotnet build
    dotnet test
    ```

6.  **View Allure reports (Run from the root directory)**
    ```
    allure serve ./UITests/bin/Debug/net6.0/allure-results
    ```


7.  **Run using NUnit categories**
    ```
    dotnet test --filter "Category=Smoke"
    ```

CI/CD
-----

Tests are executed automatically on every push and pull request to the main branch via GitHub Actions. The pipeline:

-   Restores dependencies and builds the project.

-   Runs tests with credentials from GitHub Secrets.

-   Generates and publishes Allure reports to GitHub Pages.


Author
------

Mark Hughes https://github.com/markhughes321
