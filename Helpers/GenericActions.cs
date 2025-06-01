using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Reqnroll;

namespace DemoQA_Automation.Helpers
{
    internal class GenericActions : BrowserDriver
    {
        internal static void ValidateText(string expectedText, IWebElement actualTextElement)
        {
            Assert.That(actualTextElement.Text, Is.EqualTo(expectedText), $"Expected: '{expectedText}' ; Actual: '{actualTextElement.Text}'");
        }

        internal static void ValidateContainedText(string expectedText, IWebElement actualTextElement)
        {
            Assert.That(actualTextElement.Text, Does.Contain(expectedText), $"Expected: '{expectedText}' ; Actual: '{actualTextElement.Text}'");
        }

        internal static void EnterText(IWebElement element, string input)
        {
            element.SendKeys(input);
        }

        internal static void ClearAndEnterText(IWebElement element, string input)
        {
            ClearText(element, useKeys: true);
            EnterText(element, input);
        }

        internal static void Click(IWebElement element)
        {
            new Waits().ElementToBeClickable(element);
            element.Click();
        }

        internal static void ScrollAndClick(IWebElement element)
        {
            new Waits().ElementToBeClickable(element);
            ScrollOnElement(element);
            element.Click();
        }

        internal static void DoubleClick(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element).Perform();
        }

        internal static void RightClick(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.ContextClick(element).Perform();
        }

        internal static void HoverOverElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        internal static string? GetAttributeValue(IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        internal static void IsElementPresent(By locator, string elementName)
        {
            try
            {
                var element = driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Element '{elementName}' not found");
            }
        }

        internal static void ScrollOnElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        internal static void ScrollDownToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        internal static void ClearText(IWebElement element, bool useKeys = false)
        {
            if (!useKeys)
                element.Clear();
            else
            {
                EnterText(element, Keys.Control + "A" + Keys.Backspace);
            }
        }

        internal static void SetSliderByKeys(IWebElement sliderElement, int targetValue)
        {
            Click(sliderElement);
            int currentValue = int.Parse(GetAttributeValue(sliderElement, "value")!);
            if (currentValue != targetValue)
            {
                string key = currentValue < targetValue ? Keys.ArrowRight : Keys.ArrowLeft;
                for (int i = 0; i < Math.Abs(targetValue - currentValue); i++)
                {
                    EnterText(sliderElement, key);
                }
            }
        }
    }
}
