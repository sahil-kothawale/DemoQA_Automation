using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace DemoQA_Automation.Helpers
{
    internal class Waits : BrowserDriver
    {
        private TimeSpan timeout = TimeSpan.FromSeconds(10);

        internal void ElementToBeVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        internal void ElementToBeClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        internal void ElementToBeClickable(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        internal void InvisibilityOfElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        internal void WaitForAlertToBeDisplayed(int timeoutInSeconds)
        {
            TimeSpan customTimeout = TimeSpan.FromSeconds(timeoutInSeconds);
            WebDriverWait wait = new WebDriverWait(driver, customTimeout);
            wait.Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
