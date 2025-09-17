# DemoQA_Automation

An UI Automation framework designed and developed to validate test scenarios for [DemoQA.com](https://demoqa.com/). 
It is built in **C#** using **Selenium WebDriver**, **BDD SpecFlow (Reqnroll)**, **NUnit**, **Extent Reports** and **Page Object Model**.

---

## Project structure:

/Features -> SpecFlow feature files which use Gherkin syntax for BDD approach.

/Steps -> StepDefinition class files which contain step bindings divided in appropriate regions of Given, When and Then.

/Pages -> Page class files which contain locators, action methods and validation methods for elements on page.

/Helpers -> Contains utility classes for WebDriver configuration, waits, hooks, reporting and generalized methods to support test execution.

/Models -> Contains classes with properties and constructors used to transfer structured data accross the framework.

/Constants -> Contains readonly expected test constants in form of strings or lists used for validation and assertions.

/appsettings.json -> Includes base url and 'browser' selection key which can be set to 'chrome' or 'edge'.

## Reporting:

After test execution is completed, an HTML report is generated at: */bin/debug/net8.0/Report.html*
Report contains comprehensive breakdown of test results by feature and scenario, along with step-wise execution details.

---

## Author:

This automated framework was developed and is maintained by **Sahil Kothawale**
LinkedIn: [Sahil Kothawale](https://www.linkedin.com/in/sahil-kothawale/)