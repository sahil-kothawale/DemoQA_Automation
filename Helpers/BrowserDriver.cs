using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace DemoQA_Automation.Helpers
{
    internal class BrowserDriver
    {
        internal static IWebDriver driver { get; set; } = null!;

        internal static void BrowserSetup(string? url, string? browser)
        {
            if (url != null)
            {
                try
                {
                    ArgumentNullException.ThrowIfNull(browser);
                    switch (browser.ToLower())
                    {
                        case "chrome":
                            var chromeOptions = new ChromeOptions();
                            chromeOptions.AddArguments("start-maximized");
                            driver = new ChromeDriver(chromeOptions);
                            break;
                        case "edge":
                            var edgeOptions = new EdgeOptions();
                            edgeOptions.AddArguments("start-maximized");
                            driver = new EdgeDriver(edgeOptions);
                            break;
                        default:
                            throw new ArgumentException($"Invalid browser: '{browser}'");
                    }
                    driver.Navigate().GoToUrl(url);
                }
                catch
                {
                    driver.Quit();
                }
            }
            else
            {
                throw new Exception("Base URL not found");
            }
        }

        internal static string GetCurrentWindowHandle()
        {
            return driver.CurrentWindowHandle;
        }
    }
}
