# SaaSAutomationFramework

C# Selenium WebDriver test automation framework for the [SauceDemo](https://www.saucedemo.com/) web app.

## Tech Stack

- C#, .NET
- Selenium WebDriver
- NUnit
- SpecFlow (BDD)
- Page Object Model (POM)

## Features

- POM-based page classes:
  - `LoginPage` – handles login actions and error messages
  - `ProductsPage` – verifies products page and cart badge
  - `BasePage` – common Selenium helpers (click, type, waits)
- Central `DriverFactory` to create and quit Chrome WebDriver
- NUnit tests:
  - Valid login → navigates to products page
  - Invalid login → verifies login error message
  - Add-to-cart flow → verifies cart count becomes 1
- SpecFlow BDD:
  - `Login.feature` with Given/When/Then scenarios
  - Step definitions reuse the same page objects
  - Hooks start and close the browser before/after each scenario

## How to run

1. Open `SaaSAutomationFramework.sln` in Visual Studio 2022.
2. Restore NuGet packages.
3. Open **Test Explorer**.
4. Run **All Tests**.
