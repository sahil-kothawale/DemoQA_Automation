using DemoQA_Automation.Helpers;
using DemoQA_Automation.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Reqnroll;

namespace DemoQA_Automation.Steps
{
    [Binding]
    internal class AlertsFramesStepDefinitions : AlertsFrames
    {
        #region When steps

        [When("user clicks on the (.*)st Click me button")]
        [When("user clicks on the (.*)nd Click me button")]
        [When("user clicks on the (.*)rd Click me button")]
        [When("user clicks on the (.*)th Click me button")]
        public void WhenUserClicksOnTheClickMeButton(int num)
        {
            AlertsClickMeButtonPress(num);
        }

        [When("user clicks on '(.*)' button in the alert")]
        public void WhenUserClicksOnButtonInTheAlert(string option)
        {
            switch (option.ToUpper())
            {
                case "OK":
                    AcceptAlert();
                    break;
                case "CANCEL":
                    DismissAlert();
                    break;
                default:
                    throw new ArgumentException($"Invalid alert option: '{option}'");
            }
        }

        [When("waits (.*) seconds for alert to be displayed")]
        public void WhenWaitsSecondsForAlertToBeDisplayed(int timeout)
        {
            new Waits().WaitForAlertToBeDisplayed(timeout);
        }

        [When("user enters name in alert as '(.*)'")]
        public void WhenUserEntersNameInAlertAs(string alertPromptInput)
        {
            EnterTextIntoPromptAlert(alertPromptInput);
        }

        [When("user switches to first iframe")]
        public void WhenUserSwitchesToFirstIframe()
        {
            SwitchToFirstSampleFrame();
        }

        [When("user switches to second iframe")]
        public void WhenUserSwitchesToSecondIframe()
        {
            SwitchToSecondSampleFrame();
        }

        [When("user scrolls down to bottom in frame")]
        public void WhenUserScrollsDownToBottomInFrame()
        {
            GenericActions.ScrollDownToBottom();
        }

        [When("user returns to original frame")]
        public void WhenUserReturnsToOriginalFrame()
        {
            SwitchBackToOriginalFrame();
        }

        #endregion

        #region Then steps

        [Then("Alerts, Frame & Windows dropdown is open by default")]
        public void ThenAlertsFrameWindowsDropdownIsOpenByDefault()
        {
            VerifyAlertsFrameWindowsDropDownIsOpen();
        }

        [Then("Alerts, Frame & Windows dropdown is closed")]
        public void ThenAlertsFrameWindowsDropdownIsClosed()
        {
            VerifyAlertsFrameWindowsDropDownIsClosed();
        }

        [Then("Alert with message '(.*)' is displayed")]
        public void ThenAlertWithMessageIsDisplayed(string expectedMessage)
        {
            ValidateAlertMessage(expectedMessage);
        }

        [Then("Alert is no longer displayed")]
        public void ThenAlertIsNoLongerDisplayed()
        {
            Assert.That(VerifyAlertIsNoLongerPresent(), Is.True);
        }

        [Then("'(.*)' confirmation message is shown")]
        public void ThenConfirmationMessageIsShown(string message)
        {
            ValidateAlertConfirmationResult(message);
        }

        [Then("'(.*)' entered prompt message is shown")]
        public void ThenEnteredPromptMessageIsShown(string message)
        {
            ValidateAlertEnteredPromptResult(message);
        }

        [Then("validates heading text in frame '(.*)'")]
        public void ThenValidatesHeadingTextInFrame(string messageInFrame)
        {
            ValidateExpectedMsgDisplayedInFrame(messageInFrame);
        }

        #endregion
    }
}
