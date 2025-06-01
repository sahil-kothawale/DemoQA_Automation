using System.Globalization;
using DemoQA_Automation.Constants;
using DemoQA_Automation.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Automation.Pages
{
    internal class Widgets : BrowserDriver
    {
        #region Locators
        private static IWebElement widgetsDropDownelement => driver.FindElement(By.XPath("//*[text()='Widgets']//ancestor::div[@class='element-group']//div[contains(@class,'element-list')]"));
        private static IWebElement inputAutoCompleteTypeMultiple => driver.FindElement(By.XPath("//input[@id='autoCompleteMultipleInput']"));
        private static IWebElement iconRemoveAllAutoComplete => driver.FindElement(By.XPath("//div[contains(@class,'auto-complete__clear')]"));
        private static IWebElement datepickerSelectDateCalendar => driver.FindElement(By.XPath("//*[@id='datePickerMonthYearInput']"));
        private static IWebElement datepickerYearDropdown => driver.FindElement(By.XPath("//select[contains(@class,'year-select')]"));
        private static IWebElement datepickerMonthDropdown => driver.FindElement(By.XPath("//select[contains(@class,'month-select')]"));
        private static IWebElement datepickerDateAndTime => driver.FindElement(By.Id("dateAndTimePickerInput"));
        private static IWebElement datepickerYearForDateAndTime => driver.FindElement(By.XPath("//*[contains(@class,'year-dropdown-container')]"));
        private static IWebElement datepickerMonthForDateAndTime => driver.FindElement(By.XPath("//div[contains(@class,'month-dropdown-container')]"));
        private static IWebElement sliderElement => driver.FindElement(By.XPath("//*[@type='range']"));
        private static IWebElement sliderTextBoxValue => driver.FindElement(By.Id("sliderValue"));
        private static IWebElement sliderToolTipValue => driver.FindElement(By.XPath("//*[@type='range']/following::div/div[contains(@class,'tooltip__label')]"));
        private static IWebElement tooltipTextBoxToHover => driver.FindElement(By.XPath("//*[@placeholder='Hover me to see']"));
        private static IWebElement progressBarElement => driver.FindElement(By.XPath("//*[@id='progressBar']/div"));


        #endregion

        #region Action methods

        internal static void AccordianSelection(string sectionHeaderToBeSelected)
        {
            IWebElement sectionToBeSelected = driver.FindElement(By.XPath($"//div[@class='card-header' and text()='{sectionHeaderToBeSelected}']"));
            GenericActions.ScrollAndClick(sectionToBeSelected);
        }

        internal static void EnterIntoTypeMultipleColorNames(string text)
        {
            GenericActions.EnterText(inputAutoCompleteTypeMultiple, text);
            Thread.Sleep(1000);
        }

        internal static List<string> GetFilteredListOfAutoCompleteColorNames(string inputText, List<string> alreadySelectedOptions)
        {
            List<string> filteredColors = new List<string>();
            foreach (string color in ContentConstants.WidgetsAutoCompleteColors)
            {
                if (color.Contains(inputText, StringComparison.OrdinalIgnoreCase) && !alreadySelectedOptions.Contains(color))
                {
                    filteredColors.Add(color);
                }
            }
            return filteredColors;
        }

        internal static List<string> SelectColorOptionFromAutoCompleteDropDown(string color, List<string> selectedColors)
        {
            By optionToBeSelected = By.XPath($"//*[contains(@class,'auto-complete__option') and text()='{color}']");
            new Waits().ElementToBeClickable(optionToBeSelected);
            GenericActions.ScrollAndClick(driver.FindElement(optionToBeSelected));
            selectedColors.Add(color);
            return selectedColors;
        }

        internal static List<string> ClickRemoveIconForParticularOption(string option, List<string> selectedColors)
        {
            IWebElement removeIcon = driver.FindElement(By.XPath($"//div[text()='{option}']/following::div[contains(@class,'remove')]"));
            GenericActions.ScrollAndClick(removeIcon);
            selectedColors.Remove(option);
            return selectedColors;
        }

        internal static void ClickRemoveAllIconForAutoComplete()
        {
            GenericActions.ScrollAndClick(iconRemoveAllAutoComplete);
        }

        internal static void OpenSelectDateCalendar()
        {
            GenericActions.ScrollAndClick(datepickerSelectDateCalendar);
            new Waits().ElementToBeVisible(By.XPath("//*[@role='listbox']"));
        }

        internal static void SelectYearFromDropDown(string yearToBeSelected)
        {
            SelectElement selectElement = new SelectElement(datepickerYearDropdown);
            selectElement.SelectByValue(yearToBeSelected);
        }

        internal static void SelectMonthAndDateFromDropDown(string monthToBeSelected, int dateToBeSelected)
        {
            SelectElement selectElement = new SelectElement(datepickerMonthDropdown);
            selectElement.SelectByText(monthToBeSelected);
            IWebElement dateElement = driver.FindElement(By.XPath($"//div[@role='listbox']//*[text()='{dateToBeSelected}' and contains(@aria-label,'{monthToBeSelected}')]"));
            GenericActions.Click(dateElement);
        }

        internal static void SelectDateAndTimeFromCalendar(DateTime dateTime)
        {
            GenericActions.ScrollAndClick(datepickerDateAndTime);
            YearSelectionInDateAndTimePicker(dateTime.Year);
            MonthAndDaySelectionInDateAndTimePicker(dateTime.ToString("MMMM"), dateTime.Day);
            TimeSelectionInDateAndTimePicker(dateTime.ToString("HH:mm"));
        }

        private static void YearSelectionInDateAndTimePicker(int year)
        {
            GenericActions.Click(datepickerYearForDateAndTime);
            By yearDropDown = By.XPath("//*[contains(@class,'dropdown-container')]/div[contains(@class,'year-dropdown')]");
            new Waits().ElementToBeVisible(yearDropDown);
            int topYear = int.Parse(driver.FindElement(By.XPath("//div[contains(@class,'year-option')][2]")).Text);
            int bottomYear = int.Parse(driver.FindElement(By.XPath("//div[contains(@class,'year-option')][last()]/preceding-sibling::div[1]")).Text);

            if (bottomYear > year)
            {
                IWebElement downYearArrow = driver.FindElement(By.XPath("//div[contains(@class,'year-option')][last()]"));
                for (int i = 0; i < bottomYear - year; i++)
                {
                    GenericActions.Click(downYearArrow);
                }
            }
            else if (topYear < year)
            {
                IWebElement upYearArrow = driver.FindElement(By.XPath("//div[contains(@class,'year-option')][last()]/preceding-sibling::div[last()]"));
                for (int i = 0; i < year - topYear; i++)
                {
                    GenericActions.Click(upYearArrow);
                }
            }
            IWebElement yearElement = driver.FindElement(By.XPath($"//div[contains(@class,'year-option') and text()='{year}']"));
            GenericActions.Click(yearElement);
        }

        private static void MonthAndDaySelectionInDateAndTimePicker(string month, int day)
        {
            GenericActions.Click(datepickerMonthForDateAndTime);
            By monthDropDown = By.XPath("//*[contains(@class,'dropdown-container')]/div[contains(@class,'month-dropdown')]");
            new Waits().ElementToBeVisible(monthDropDown);
            IWebElement monthElement = driver.FindElement(By.XPath($"//div[contains(@class,'month-option') and text()='{month}']"));
            GenericActions.Click(monthElement);

            IWebElement dayElement = driver.FindElement(By.XPath($"//*[@role='listbox']//div[text()='{day}' and contains(@aria-label,'{month}')]"));
            GenericActions.Click(dayElement);
        }

        private static void TimeSelectionInDateAndTimePicker(string time)
        {
            IWebElement timeElement = driver.FindElement(By.XPath($"//div[contains(@class,'time-box')]//li[text()='{time}']"));
            GenericActions.Click(timeElement);
        }

        internal static void SetSlider(int targetSliderValue)
        {
            GenericActions.SetSliderByKeys(sliderElement, targetSliderValue);
        }

        internal static void ToolTipHoverAction(string elementText)
        {
            Thread.Sleep(1000);
            IWebElement elementToHover = driver.FindElement(By.XPath($"//*[text()='{elementText}']"));
            GenericActions.HoverOverElement(elementToHover);
            new Waits().ElementToBeVisible(By.XPath($"//*[text()='{elementText}' and contains(@aria-describedBy,'ToolTip')]"));
            Assert.That(GenericActions.GetAttributeValue(elementToHover, "aria-describedBy"), Is.Not.Null);
        }

        internal static void ToolTipHoverActionOnPlaceholderTextBox()
        {
            GenericActions.HoverOverElement(tooltipTextBoxToHover);
            Assert.That(GenericActions.GetAttributeValue(tooltipTextBoxToHover, "aria-describedBy"), Is.Not.Null);
        }

        internal static void WaitTillProgressBarIsComplete()
        {
            new Waits().ElementToBeVisible(By.XPath("//*[@id='progressBar']/div[contains(@class,'bg-success')]"));
            new Waits().ElementToBeVisible(By.XPath("//button[text()='Reset']"));
        }

        internal static void NavBarTabSelection(string tabSelected)
        {
            IList<IWebElement> tabs = driver.FindElements(By.XPath("//*[@id='tabsContainer']/nav/a[not(contains(@class,'disable'))]"));
            foreach (IWebElement tab in tabs)
            {
                if (tab.Text == tabSelected)
                {
                    GenericActions.ScrollAndClick(tab);
                    return;
                }
            }
            throw new ArgumentException($"Invalid tab name: {tabSelected}");
        }

        #endregion

        #region Validation methods

        internal static void VerifyWidgetsDropDownIsOpen()
        {
            Assert.That(GenericActions.GetAttributeValue(widgetsDropDownelement, "class"), Does.Contain("show"));
        }

        internal static void VerifyWidgetsDropDownIsClosed()
        {
            Assert.That(GenericActions.GetAttributeValue(widgetsDropDownelement, "class"), Does.Not.Contain("show"));
        }

        internal static void ValidateOnlyParticularAccordianSectionIsActive(string sectionName)
        {
            new Waits().ElementToBeVisible(By.XPath($"//*[text()='{sectionName}']/following-sibling::div[contains(@class,'collapse')]"));

            IWebElement sectionElement = driver.FindElement(By.XPath($"//div[@class='accordion']//*[text()='{sectionName}']/following-sibling::div"));
            Assert.That(GenericActions.GetAttributeValue(sectionElement, "class"), Does.Contain("show"));

            IList<IWebElement> sectionElements = driver.FindElements(By.XPath($"//div[@class='card']/div[not(text()='{sectionName}')]/following-sibling::div"));
            foreach (IWebElement section in sectionElements)
            {
                Assert.That(GenericActions.GetAttributeValue(section, "class"), Does.Not.Contain("show"));
            }
        }

        internal static void ValidateAllAccordianSectionsAreClosed()
        {
            IList<IWebElement> sectionElements = driver.FindElements(By.XPath("//div[@class='card-header']/following-sibling::div"));
            foreach (IWebElement section in sectionElements)
            {
                Assert.That(GenericActions.GetAttributeValue(section, "class"), Does.Not.Contain("show"));
            }
        }

        internal static void ValidateCorrectDropDownOptionsAreDisplayed(string inputEntered, List<string> alreadySelectedOptions)
        {
            List<string> filteredColors = GetFilteredListOfAutoCompleteColorNames(inputEntered, alreadySelectedOptions);
            IList<IWebElement> dropdownElements = driver.FindElements(By.XPath("//*[contains(@class,'auto-complete__option')]"));
            Assert.That(dropdownElements.Count, Is.EqualTo(filteredColors.Count));

            foreach (string color in filteredColors)
            {
                By colorOption = By.XPath($"//*[contains(@class,'auto-complete__option') and text()='{color}']");
                GenericActions.IsElementPresent(colorOption, $"Dropdown option '{color}'");
            }
        }

        internal static void VerifySelectedColorOptionIsDisplayedWithRemoveIcon(string colorOptionSelected)
        {
            By selectedOption = By.XPath($"//*[@id='autoCompleteMultipleContainer']//div[contains(@class,'multi-value__label') and text()='{colorOptionSelected}']");
            GenericActions.IsElementPresent(selectedOption, $"'{colorOptionSelected}' option");
            By selectedOptionRemoveIcon = By.XPath($"//div[contains(@class,'multi-value__label') and text()='{colorOptionSelected}']/following::div[contains(@class,'remove')]");
            GenericActions.IsElementPresent(selectedOptionRemoveIcon, $"'{colorOptionSelected}' option remove icon");
        }

        internal static void VerifyNoOptionIsSelectedInAutoComplete()
        {
            By selectedLabelsElement = By.XPath("//*[@id='autoCompleteMultipleContainer']//div[contains(@class,'multi-value__label')]");
            new Waits().InvisibilityOfElement(selectedLabelsElement);
        }

        internal static void ValidateSelectedDateIsDisplayed(int date, string month, string year)
        {
            var actualDate = GenericActions.GetAttributeValue(datepickerSelectDateCalendar, "value");
            string monthInDigits = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month.ToString();
            Assert.That(actualDate, Is.EqualTo($"{monthInDigits}/{date}/{year}"));
        }

        internal static void ValidateSelectedDateAndTimeIsDisplayed(DateTime dateTime)
        {
            var actual = GenericActions.GetAttributeValue(datepickerDateAndTime, "value");
            Assert.That(actual, Is.EqualTo(dateTime.ToString("MMMM dd, yyyy h:m tt")));
        }

        internal static void VerifySliderToolTipAndTextBoxValue(int sliderValue)
        {
            Assert.That(GenericActions.GetAttributeValue(sliderTextBoxValue, "value"), Is.EqualTo(sliderValue.ToString()));
            Assert.That(GenericActions.GetAttributeValue(sliderElement, "value"), Is.EqualTo(sliderValue.ToString()));
            GenericActions.HoverOverElement(sliderToolTipValue);
            GenericActions.ValidateText(sliderValue.ToString(), sliderToolTipValue);
        }

        internal static void VerifySliderMinAndMaxValues()
        {
            Assert.That(int.Parse(GenericActions.GetAttributeValue(sliderElement, "min")!), Is.EqualTo(0));
            Assert.That(int.Parse(GenericActions.GetAttributeValue(sliderElement, "max")!), Is.EqualTo(100));
        }

        internal static void ValidateToolTipMessageIsDisplayed(string expectedToolTip, string elementType)
        {
            By locator = elementType switch
            {
                "button" => By.XPath("//*[@id='buttonToolTip']"),
                "textField" => By.XPath("//*[@id='textFieldToolTip']"),
                "link" => By.XPath("//*[@id='contraryTexToolTip']"),
                _ => throw new ArgumentException($"Invalid argument {elementType}."),
            };
            GenericActions.ScrollOnElement(driver.FindElement(locator));
            GenericActions.ValidateText(expectedToolTip, driver.FindElement(locator));
        }

        internal static void ValidateCurrentProgressBarLevel(int expectedPercent)
        {
            if (expectedPercent != 0)
                GenericActions.ValidateText($"{expectedPercent.ToString()}%", progressBarElement);
            Assert.That(GenericActions.GetAttributeValue(progressBarElement, "aria-valuenow"), Is.EqualTo(expectedPercent.ToString()));
        }

        internal static void VerifyProgressBarAt100IsSuccessGreen()
        {
            Assert.That(GenericActions.GetAttributeValue(progressBarElement, "class"), Does.Contain("bg-success"));
        }

        internal static void VerifyAllExpectedTabsAreDisplayed()
        {
            IList<IWebElement> actualTabs = driver.FindElements(By.XPath("//*[@id='tabsContainer']/nav/a"));
            List<string> expectedTabs = ContentConstants.WidgetsAllAvailableTabs;
            for (int i = 0; i < expectedTabs.Count; i++)
            {
                GenericActions.ValidateText(expectedTabs[i], actualTabs[i]);
            }
        }

        internal static void ValidateMoreTabIsDisabled()
        {
            IWebElement moreTab = driver.FindElement(By.XPath("//*[@id='tabsContainer']/nav/a[text()='More']"));
            Assert.That(GenericActions.GetAttributeValue(moreTab, "class")!, Does.Contain("disabled"));
        }

        internal static void ValidateParticularTabIsActive(string tabName)
        {
            IWebElement moreTab = driver.FindElement(By.XPath($"//*[@id='tabsContainer']/nav/a[text()='{tabName}']"));
            Assert.That(GenericActions.GetAttributeValue(moreTab, "class")!, Does.Contain("active"));
        }

        #endregion
    }
}
