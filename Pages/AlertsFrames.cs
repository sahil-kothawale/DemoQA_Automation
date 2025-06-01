using DemoQA_Automation.Constants;
using DemoQA_Automation.Helpers;
using OpenQA.Selenium;

namespace DemoQA_Automation.Pages
{
    internal class AlertsFrames : BrowserDriver
    {
        #region Locators
        private static IWebElement alertsFrameWindowsDropDownelement => driver.FindElement(By.XPath("//*[text()='Alerts, Frame & Windows']//ancestor::div[@class='element-group']//div[contains(@class,'element-list')]"));
        private static IWebElement alertConfirmationResultText => driver.FindElement(By.Id("confirmResult"));
        private static IWebElement alertEnteredPromptResultText => driver.FindElement(By.Id("promptResult"));
        private static IWebElement iframeFirstSampleFrame => driver.FindElement(By.Id("frame1"));
        private static IWebElement iframeSecondSampleFrame => driver.FindElement(By.Id("frame2"));
        private static IWebElement iframeInsideHeaderText => driver.FindElement(By.XPath("//h1[@id='sampleHeading']"));

        #endregion

        #region Action methods

        internal static void AlertsClickMeButtonPress(int predicateNum)
        {
            IWebElement clickMeButton = driver.FindElement(By.XPath($"(//button[text()='Click me'])[{predicateNum}]"));
            GenericActions.ScrollAndClick(clickMeButton);
        }

        internal static void AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        internal static void DismissAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        internal static void EnterTextIntoPromptAlert(string inputText)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(inputText);
            alert.Accept();
        }

        internal static void SwitchToFirstSampleFrame()
        {
            driver.SwitchTo().Frame(iframeFirstSampleFrame);
        }

        internal static void SwitchToSecondSampleFrame()
        {
            driver.SwitchTo().Frame(iframeSecondSampleFrame);
        }

        internal static void SwitchBackToOriginalFrame()
        {
            driver.SwitchTo().DefaultContent();
        }

        #endregion

        #region Validation methods

        internal static void VerifyAlertsFrameWindowsDropDownIsOpen()
        {
            Assert.That(GenericActions.GetAttributeValue(alertsFrameWindowsDropDownelement, "class"), Does.Contain("show"));
        }

        internal static void VerifyAlertsFrameWindowsDropDownIsClosed()
        {
            Assert.That(GenericActions.GetAttributeValue(alertsFrameWindowsDropDownelement, "class"), Does.Not.Contain("show"));
        }

        internal static void ValidateAlertMessage(string message)
        {
            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo(message));
        }

        internal static bool VerifyAlertIsNoLongerPresent()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                return false;
            }
            catch (NoAlertPresentException)
            {
                return true;
            }
        }

        internal static void ValidateAlertConfirmationResult(string message)
        {
            GenericActions.ValidateText(message, alertConfirmationResultText);
        }

        internal static void ValidateAlertEnteredPromptResult(string message)
        {
            GenericActions.ValidateText(message, alertEnteredPromptResultText);
        }

        internal static void ValidateExpectedMsgDisplayedInFrame(string expectedMessage)
        {
            GenericActions.ValidateText(expectedMessage, iframeInsideHeaderText);
        }

        #endregion
    }
}
