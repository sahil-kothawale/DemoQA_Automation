using OpenQA.Selenium;
using Reqnroll;

namespace DemoQA_Automation.Helpers
{
    internal class ScreenshotHelper : BrowserDriver
    {
        internal static void TakeScreenShot(ScenarioContext scenarioContext, string path = "")
        {
            if (driver != null)
            {
                ITakesScreenshot? screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver!.GetScreenshot();
                screenshot.SaveAsFile($"{path}/{scenarioContext.ScenarioInfo.Title}_{DateTime.Now}");
            }
        }
    }
}
