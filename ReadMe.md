DotNet Selenium Framework -- Senior SDET Interview Prep
======================================================

Overview
--------

This project is a C# and Selenium-based UI test automation framework built as part of a technical exercise to demonstrate the capabilities of a **Senior Software Development Engineer in Test (SDET)**.

The objective is to show hands-on expertise in building a scalable and maintainable test automation framework from the ground up --- with clean architecture, robust test execution, and integration with reporting and CI/CD pipelines.

It targets modern web applications (e.g. Angular, React) and is built using .NET 6, Selenium WebDriver, NUnit, and Allure for reporting.

Core Features
-------------

-   ✅ Built using **.NET 6**, **Selenium WebDriver**, and **NUnit**

-   ✅ Fully implemented **Page Object Model (POM)** structure

-   ✅ **Reusable Components** and page abstractions (`HeaderComponent`, `LoginPage`, `HomePage`)

-   ✅ **Custom Assertion Helpers** with Allure step integration for readable test flow

-   ✅ **Central Driver Management** using `DriverManager` and `WebDriverFactory`

-   ✅ **Explicit Waits** wrapped in `WaitHelper` to handle dynamic web elements

-   ✅ **Parallel Execution** setup via `AssemblyInfo.cs`

-   ✅ **Retry Logic** on flaky tests using `[Retry(2)]`

-   ✅ Integrated with **Allure Reporting**

-   ✅ **CI Integration via GitHub Actions** --- tests run on push/PR

-   ✅ **Hosted test reports** available at:\
    <https://markhughes321.github.io/dotnet-selenium-framework/10/>

Folder Structure
----------------

```
├── Components/            # Reusable UI components
├── Drivers/               # Driver manager and setup
├── Helpers/               # Assertion, config, wait logic, and Allure setup
├── Pages/                 # Page Object Model classes grouped by domain
├── Tests/                 # Test classes grouped by feature area
├── Resources/             # Data-driven test inputs (optional)
├── Reports/               # Output location for reports and screenshots
├── .env                   # Env variables (e.g. credentials)
├── UITests.csproj         # Project file`
```

Getting Started
---------------

1.  **Clone the repository**\
    `git clone https://github.com/markhughes321/dotnet-selenium-framework.git`

2.  **Install .NET 6 SDK**\
    Download from: <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>

3.  **Install Allure commandline (optional for local reporting)**\
    `npm install -g allure-commandline --save-dev`

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
    `allure serve ./UITests/bin/Debug/net6.0/allure-results`

7.  **Run using NUnit categories**
    `dotnet test --filter "Category=Smoke"`


CI/CD
-----

Tests are executed on every push and pull request via GitHub Actions.\
Results are published and accessible at:

<https://markhughes321.github.io/dotnet-selenium-framework/10/>

Author
------

Mark Hughes\
<https://github.com/markhughes321>