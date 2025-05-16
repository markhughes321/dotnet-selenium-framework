SeleniumFramework
=================

This is a UI Test Automation framework built using C#, Selenium WebDriver, NUnit, and GitHub Actions. It automates UI scenarios on the Ryanair website and is structured for scalability and maintainability.

Project Structure
-----------------

*   Tests/ – Contains all NUnit test classes.
    
*   Pages/ – Page Object Models for different pages of the application.
    
*   Components/ – Shared UI components like headers, footers, etc.
    
*   Helpers/ – Utilities like config loading, wait helpers, constants.
    
*   Drivers/ – WebDriver setup and teardown logic.
    
*   Properties/AssemblyInfo.cs – Enables parallel test execution.
    
*   .github/workflows/ci.yml – CI pipeline definition for GitHub Actions.
    

Features
--------

*   Parallel test execution via NUnit
    
*   Page Object Model (POM) design pattern
    
*   Centralized wait logic
    
*   Environment variable loading via .env file
    
*   GitHub Actions integration
    

Prerequisites
-------------

*   [.NET 9 SDK](https://dotnet.microsoft.com/)
    
*   Chrome
    
*   ChromeDriver
    
*   Git
    

How to Run Locally
------------------

1.  Restore dependencies:dotnet restore
    
2.  Run tests:dotnet test
    
3.  Run by category:dotnet test --filter TestCategory=Login
    

Environment Variables
---------------------

Create a .env file in the UITests folder with the following:

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   iniCopyEditRYANAIR_EMAIL=your_email@example.com  RYANAIR_PASSWORD=your_password   `

These are loaded using dotenv.net.

Debugging Test Failures
-----------------------

*   Logs are shown in the console via test runner.
    
*   Update BaseTest to take screenshots or log HTML if needed on failure.
    

CI/CD
-----

This project runs tests automatically using GitHub Actions. See .github/workflows/ci.yml.