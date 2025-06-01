using System.Globalization;
using DemoQA_Automation.Pages;
using Reqnroll;
using static System.Net.Mime.MediaTypeNames;

namespace DemoQA_Automation.Steps
{
    [Binding]
    internal class WidgetsStepDefinitions : Widgets
    {
        private ScenarioContext _scenarioContext;
        public WidgetsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region Given steps

        [Given("list created to store selected colors")]
        public void GivenListCreatedToStoreSelectedColors()
        {
            List<string> alreadySelectedColors = new List<string>();
            _scenarioContext["autoCompleteSelectedColorsList"] = alreadySelectedColors;
        }

        #endregion

        #region When steps

        [When("user clicks on '(.*)' accordion section")]
        public void WhenUserClicksOnAccordionSection(string sectionName)
        {
            AccordianSelection(sectionName);
        }

        [When("user types '(.*)' in the 'Type multiple color names' input box")]
        [When("user types '(.*)' in the 'Type multiple color names' input box again")]
        public void WhenUserTypesInTheTypeMultipleColorNamesInputBox(string text)
        {
            EnterIntoTypeMultipleColorNames(text);
            _scenarioContext["autoCompleteMultipleInput"] = text;
        }

        [When("user adds '(.*)' in the existing text of 'Type multiple color names' input box")]
        public void WhenUserAddsInTheExistingTextOfTypeMultipleColorNamesInputBox(string addedText)
        {
            EnterIntoTypeMultipleColorNames(addedText);
            _scenarioContext["autoCompleteMultipleInput"] = _scenarioContext["autoCompleteMultipleInput"].ToString() + addedText;
        }

        [When("user selects '(.*)' color option")]
        public void WhenUserSelectsColorOption(string colorOption)
        {
            _scenarioContext["autoCompleteSelectedColorsList"] = SelectColorOptionFromAutoCompleteDropDown(colorOption, (List<string>)_scenarioContext["autoCompleteSelectedColorsList"]);
        }

        [When("clicks on remove icon of '(.*)' option")]
        public void WhenClicksOnRemoveIconOfOption(string option)
        {
            _scenarioContext["autoCompleteSelectedColorsList"] = ClickRemoveIconForParticularOption(option, (List<string>)_scenarioContext["autoCompleteSelectedColorsList"]);
        }

        [When("clicks on remove all icon")]
        public void WhenClicksOnRemoveAllIcon()
        {
            ClickRemoveAllIconForAutoComplete();
        }

        [When("user opens the calendar for Select date")]
        public void WhenUserOpensTheCalendarForSelectDate()
        {
            OpenSelectDateCalendar();
        }

        [When("selects year as '(.*)' from year dropdown")]
        public void WhenSelectsYearAsFromYearDropdown(string year)
        {
            SelectYearFromDropDown(year);
            _scenarioContext["yearDatePicker"] = year;
        }

        [When("selects month as '(.*)' and date as '(.*)' from month dropdown")]
        public void WhenSelectsMonthAsFromMonthDropdown(string month, string date)
        {
            SelectMonthAndDateFromDropDown(month, int.Parse(date));
            _scenarioContext["monthDatePicker"] = month;
            _scenarioContext["dateDatePicker"] = date;
        }

        [When("user selects date as '(.*)' and time as '(.*)'")]
        public void WhenUserSelectsDateAsSeptemberAndTimeAsAM(string date, string time)
        {
            string format = "MMMM dd, yyyy hh:mmtt";
            DateTime dateTime = DateTime.ParseExact($"{date} {time}", format, CultureInfo.InvariantCulture);
            SelectDateAndTimeFromCalendar(dateTime);
            _scenarioContext["dateTimeDatePicker"] = dateTime;
        }

        [When("user drags slider to (.*)")]
        public void WhenUserDragsSliderTo(int sliderValue)
        {
            SetSlider(sliderValue);
        }

        [When("user hovers on '(.*)' Button")]
        [When("user hovers on '(.*)' link")]
        public void WhenUserHoversOnElement(string elementText)
        {
            ToolTipHoverAction(elementText);
        }

        [When("user hovers on 'Hover me' Textbox")]
        public void WhenUserHoversOnHoverMeTextbox()
        {
            ToolTipHoverActionOnPlaceholderTextBox();
        }

        [When("wait till progress bar is complete")]
        public void WhenWaitTillProgressBarIsComplete()
        {
            WaitTillProgressBarIsComplete();
        }

        [When("user selects '(.*)' tab from menu")]
        public void WhenUserSelectsTabFromMenu(string tabName)
        {
            NavBarTabSelection(tabName);
        }

        #endregion

        #region Then steps

        [Then("Widgets dropdown is open by default")]
        public void ThenWidgetsDropdownIsOpenByDefault()
        {
            VerifyWidgetsDropDownIsOpen();
        }

        [Then("Widgets dropdown is closed")]
        public void ThenWidgetsDropdownIsClosed()
        {
            VerifyWidgetsDropDownIsClosed();
        }

        [Then("only '(.*)' accordian section is open by default")]
        [Then("only '(.*)' accordian section is open")]
        public void ThenOnlyAccordianSectionIsOpenByDefault(string sectionName)
        {
            ValidateOnlyParticularAccordianSectionIsActive(sectionName);
        }

        [Then("all accordian sections are closed")]
        public void ThenAllAccordianSectionsAreClosed()
        {
            ValidateAllAccordianSectionsAreClosed();
        }

        [Then("relevant correct colors are displayed in dropdown below")]
        public void ThenRelevantCorrectColorsAreDisplayedInDropdownBelow()
        {
            ValidateCorrectDropDownOptionsAreDisplayed(_scenarioContext["autoCompleteMultipleInput"].ToString()!, (List<string>)_scenarioContext["autoCompleteSelectedColorsList"]);
        }

        [Then("'(.*)' option is selected and displayed with its corresponding remove icon")]
        [Then("previously selected '(.*)' option is still selected and displayed")]
        public void ThenOptionIsSelectedAndDisplayedWithItsCorrespondingRemoveIcon(string colorOptionSelected)
        {
            VerifySelectedColorOptionIsDisplayedWithRemoveIcon(colorOptionSelected);
        }

        [Then("No color option will be selected and displayed")]
        public void ThenNoColorOptionWillBeSelectedAndDisplayed()
        {
            VerifyNoOptionIsSelectedInAutoComplete();
        }

        [Then("validate selected date is displayed")]
        public void ThenValidateSelectedDateIsDisplayed()
        {
            ValidateSelectedDateIsDisplayed(int.Parse(_scenarioContext["dateDatePicker"].ToString()!), _scenarioContext["monthDatePicker"].ToString()!, _scenarioContext["yearDatePicker"].ToString()!);
        }

        [Then("validate selected date and time is as expected")]
        public void ThenValidateSelectedDateAndTimeIsAsExpected()
        {
            ValidateSelectedDateAndTimeIsDisplayed((DateTime)_scenarioContext["dateTimeDatePicker"]);
        }

        [Then("slider is at (.*) by default")]
        [Then("textbox and slider show value (.*)")]
        public void ThenTextboxAndSliderShowValue(int sliderValue)
        {
            VerifySliderToolTipAndTextBoxValue(sliderValue);
        }

        [Then("min max values are 0 and 100")]
        public void ThenMinMaxValuesAreAnd()
        {
            VerifySliderMinAndMaxValues();
        }

        [Then("'(.*)' message for '(.*)' tool tip is displayed")]
        public void ThenToolTipIsDisplayed(string expectedToolTip, string elementType)
        {
            ValidateToolTipMessageIsDisplayed(expectedToolTip, elementType);
        }

        [Then("Progress bar is displayed by default at (.*)%")]
        [Then("Progress bar resets to (.*)%")]
        public void ThenProgressBarIsDisplayedByDefaultAt(int expectedPercent)
        {
            ValidateCurrentProgressBarLevel(expectedPercent);
        }

        [Then("validate progress bar reaches 100% and is success")]
        public void ThenValidateProgressBarReaches100AndIsInSuccess()
        {
            ValidateCurrentProgressBarLevel(100);
            VerifyProgressBarAt100IsSuccessGreen();
        }

        [Then("verify all expected tabs are displayed")]
        public void ThenVerifyAllExpectedTabsAreDisplayed()
        {
            VerifyAllExpectedTabsAreDisplayed();
        }

        [Then("'More' tab is disabled")]
        public void ThenTabIsDisabled()
        {
            ValidateMoreTabIsDisabled();
        }

        [Then("'(.*)' tab is in active state")]
        public void ThenTabIsInActiveState(string tabName)
        {
            ValidateParticularTabIsActive(tabName);
        }

        #endregion
    }
}
