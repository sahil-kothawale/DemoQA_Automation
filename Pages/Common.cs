using DemoQA_Automation.Helpers;
using OpenQA.Selenium;

namespace DemoQA_Automation.Pages
{
    internal class Common : BrowserDriver
    {
        #region Action methods
        internal static void SelectCategoryCard(string cardToBeSelected)
        {
            By card = By.XPath($"//h5[text()='{cardToBeSelected}']//parent::div");
            GenericActions.Click(driver.FindElement(card));
        }

        internal static void SelectTabFromLeftColumn(string tabToBeSelected)
        {
            By tab = By.XPath($"//*[text()='{tabToBeSelected}']//ancestor::div[@class='element-group']//div[@class='header-text']");
            GenericActions.Click(driver.FindElement(tab));
        }

        internal static void SelectSubTabFromLeftColumn(string subTabToBeSelected)
        {
            By subTab = By.XPath($"//span[text()='{subTabToBeSelected}']//ancestor::li");
            GenericActions.ScrollAndClick(driver.FindElement(subTab));
        }

        internal static void ClickButton(string buttonName)
        {
            By buttonElement = By.XPath($"//button[text()='{buttonName}']");
            new Waits().ElementToBeClickable(buttonElement);
            GenericActions.ScrollOnElement(driver.FindElement(buttonElement));
            GenericActions.Click(driver.FindElement(buttonElement));
        }

        internal static void ClickLink(string linkText)
        {
            By linkElement = By.XPath($"//a[normalize-space(.)='{linkText}']");
            new Waits().ElementToBeClickable(linkElement);
            GenericActions.ScrollOnElement(driver.FindElement(linkElement));
            GenericActions.Click(driver.FindElement(linkElement));
        }

        internal static void SwitchBackToOriginalTab(string originalWindowHandle)
        {
            driver.SwitchTo().Window(originalWindowHandle);
        }

        #endregion

        #region Validation methods
        internal static void ValidateToolsQaHomePageIsDisplayed()
        {
            By toolsQaImg = By.XPath("//header//img[@src='/images/Toolsqa.jpg']");
            new Waits().ElementToBeVisible(toolsQaImg);
            GenericActions.IsElementPresent(toolsQaImg, "Tools QA image");
        }

        internal static void ValidateAllAvailableMenuCards()
        {
            string[] expectedCards = { "Elements", "Forms", "Alerts, Frame & Windows", "Widgets", "Interactions", "Book Store Application"};
            var menuCardElements = driver.FindElements(By.XPath("//*[@class='category-cards']/descendant::div[@class='card-body']/h5"));

            Assert.That(menuCardElements.Count, Is.EqualTo(expectedCards.Length));
            for (int i = 0; i < expectedCards.Length; i++)
            {
                GenericActions.ValidateText(expectedCards[i], menuCardElements[i]);
            }
        }

        internal static void ValidateExpectedPageUrlIsDisplayed(string page)
        {
            string currentUrl = driver.Url;
            string expectedUrl = Configuration.Config["base_url"] + $"/{char.ToLower(page[0]) + page.Substring(1)}";
            Assert.That(currentUrl, Is.EqualTo(expectedUrl));
        }

        internal static void ValidateThatNewTabIsLaunched(string originalWindowHandle)
        {
            var windowHandles = driver.WindowHandles;
            Assert.That(driver.WindowHandles.Count > 1, Is.True);
            driver.SwitchTo().Window(windowHandles.Last());
            string currentWindowHandle = GetCurrentWindowHandle();
            Assert.That(currentWindowHandle != originalWindowHandle, Is.True);
        }

        internal static void VerifyButtonIsAvailable(string buttonName)
        {
            By buttonElementLocator = By.XPath($"//button[normalize-space()='{buttonName}']");
            GenericActions.IsElementPresent(buttonElementLocator, $"Button: {buttonName}");
        }

        #endregion
    }
}
