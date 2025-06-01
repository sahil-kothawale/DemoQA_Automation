using DemoQA_Automation.Helpers;
using DemoQA_Automation.Pages;
using Reqnroll;

namespace DemoQA_Automation.Steps
{
    [Binding]
    internal class CommonStepDefinitions : Common
    {
        private ScenarioContext _scenarioContext;
        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region Given steps

        [Given("Demo-QA web application is launched")]
        public void GivenDemoQaWebApplicationIsLaunched()
        {
            string? url = Configuration.Config["base_url"];
            BrowserSetup(url, Configuration.Config["browser"]);
        }

        [Given("get current window-handle")]
        [Given("user is working on original tab")]
        public void GivenUserIsWorkingOnOriginalTab()
        {
            _scenarioContext["currentWindowHandle"] = GetCurrentWindowHandle();
        }

        #endregion

        #region When steps

        [When("selects (.*) card")]
        public void WhenSelectsCard(string cardName)
        {
            SelectCategoryCard(cardName);
        }

        [When("user selects (.*) tab")]
        public void WhenUserSelectsTab(string tabName)
        {
            SelectTabFromLeftColumn(tabName);
        }

        [When("user selects (.*) sub-tab")]
        public void WhenUserSelectsSubTab(string subTabName)
        {
            SelectSubTabFromLeftColumn(subTabName);
        }

        [When("clicks on (.*) button")]
        public void WhenClicksOnButton(string buttonName)
        {
            ClickButton(buttonName);
        }

        [When("user clicks on (.*) link")]
        public void WhenUserClicksOnLink(string linkText)
        {
            ClickLink(linkText);
        }

        [When("user returns to original tab")]
        public void WhenUserReturnsToOriginalTab()
        {
            SwitchBackToOriginalTab(_scenarioContext["currentWindowHandle"].ToString()!);
        }

        #endregion

        #region Then steps

        [Then("ToolsQA homepage is displayed")]
        public void ThenToolsQAHomepageIsDisplayed()
        {
            ValidateToolsQaHomePageIsDisplayed();
        }

        [Then("all expected UI cards are displayed")]
        public void ThenAllExpectedUICardsAreDisplayed()
        {
            ValidateAllAvailableMenuCards();
        }

        [Then("(.*) page is displayed")]
        public void ThenPageIsDisplayed(string cardName)
        {
            ValidateExpectedPageUrlIsDisplayed(cardName);
        }

        [Then("check if user navigates to new tab")]
        public void ThenCheckIfUserNavigatesToNewTab()
        {
            ValidateThatNewTabIsLaunched(_scenarioContext["currentWindowHandle"].ToString()!);
        }

        [Then("(.*) button is available")]
        public void ThenButtonIsAvailable(string buttonName)
        {
            VerifyButtonIsAvailable(buttonName);
        }

        #endregion
    }
}
