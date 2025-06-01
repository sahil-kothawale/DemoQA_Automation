using DemoQA_Automation.Models;
using DemoQA_Automation.Pages;
using Reqnroll;

namespace DemoQA_Automation.Steps
{
    [Binding]
    internal class ElementsStepDefinitions : Elements
    {
        private ScenarioContext _scenarioContext;
        public ElementsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region When steps

        [When("user enters full name as (.*) in textbox")]
        public void WhenUserEntersFullNameInTextbox(string fullName)
        {
            EnterFullName(fullName);
            _scenarioContext["textbox_FullName"] = fullName;
        }

        [When("user enters email as (.*) in textbox")]
        public void WhenUserEntersEmailInTextbox(string email)
        {
            EnterEmail(email);
            _scenarioContext["textbox_email"] = email;
        }

        [When("user enters (.*) and (.*) addresses")]
        public void WhenUserEntersAndAddresses(string currentAddress, string permanentAddress)
        {
            EnterCurrentAddress(currentAddress);
            EnterPermanentAddress(permanentAddress);
            _scenarioContext["textbox_currAdd"] = currentAddress;
            _scenarioContext["textbox_perAdd"] = permanentAddress;
        }

        [When("user selects (.*) radiobutton")]
        public void WhenUserSelectsRadiobutton(string option)
        {
            SelectsRadiobutton(option);
            _scenarioContext["radioButtonSelected"] = option;
        }

        [When("user clicks on plus icon to see all checkboxes")]
        public void WhenUserClicksOnPlusIconToSeeAllCheckboxes()
        {
            ExpandAllCheckBoxOptions();
        }

        [When("selects required checkboxes from the list")]
        public void WhenSelectsRequiredCheckboxesFromTheList(DataTable table)
        {
            SelectAllRequiredCheckBoxes(table);
        }

        [When("user double clicks on 'Double Click Me' button")]
        public void WhenUserDoubleClicksOnDoubleClickMeButton()
        {
            DoubleClickMeButton();
        }

        [When("user right clicks on 'Right Click Me' button")]
        public void WhenUserRightClicksOnButton()
        {
            RightClickMeButton();
        }

        [When("user uploads a file (.*)")]
        public void WhenUserUploadsAFile(string fileName)
        {
            UploadFile(fileName);
            _scenarioContext["uploadedFileName"] = fileName;
        }

        [When("user captures data from web table")]
        public void WhenUserCapturesDataFromWebTable()
        {
            _scenarioContext["webTableData"] = GetAllDataFromElementsWebTable();
        }

        [When("user captures new latest data from web table")]
        public void WhenUserCapturesNewLatestDataFromWebTable()
        {
            _scenarioContext["newWebTableData"] = GetAllDataFromElementsWebTable();
        }

        [When("user enters new data")]
        public void WhenUserEntersNewData(DataTable dataTable)
        {
            _scenarioContext["newAddedRowWebTable"] = EnterNewRowDataIntoWebTable(dataTable.Rows[0]);
        }

        [When("user enters name in Type to search filter box")]
        public void WhenUserEntersNameInTypeToSearchFilterBox()
        {
            string firstNameOfNewRow = ((ElementsWebTableRow)_scenarioContext["newAddedRowWebTable"]).FirstName!;
            EnterIntoTypeToSearchFilterBox(firstNameOfNewRow);
        }

        [When("user clears the search filter box")]
        public void WhenUserClearsTheSearchFilterBox()
        {
            ClearTypeToSearchFilterBox();
        }

        [When("user clicks on the delete icon for newly added record")]
        public void WhenUserClicksOnTheDeleteIconForNewlyAddedRecord()
        {
            DeleteNewlyAddedRecordFromWebTable();
        }

        #endregion

        #region Then steps

        [Then("Elements dropdown is open by default")]
        public void ThenElementsDropdownIsOpenByDefault()
        {
            VerifyElementsDropDownIsOpen();
        }

        [Then("Elements dropdown is closed")]
        public void ThenElementsDropdownIsClosed()
        {
            VerifyElementsDropDownIsClosed();
        }

        [Then("validate entered text details displayed below")]
        public void ThenValidateEnteredTextDetailsDisplayedBelow()
        {
            ValidateEnteredTextBoxDetailsFromTable(_scenarioContext);
        }

        [Then("label with 'Do you like this site' text is displayed")]
        public void ThenLabelWithDoYouLikeThisSiteTextIsDisplayed()
        {
            VerifyRadioButtonQuestionLabel();
        }

        [Then("verify that 'No' option is disabled")]
        public void ThenVerifyThatNoOptionIsDisabled()
        {
            VerifyThatNoRadioButtonOptionIsDisabled();
        }

        [Then("validate selected radiobutton is displayed below")]
        public void ThenValidateSelectedRadiobuttonIsDisplayedBelow()
        {
            ValidateSelectedRadioButtonConfirmationText(_scenarioContext["radioButtonSelected"].ToString()!);
        }

        [Then("validate details from selected checkboxes is displayed below")]
        public void ThenValidateDetailsFromSelectedCheckboxesIsDisplayedBelow()
        {
            ValidateSelectedCheckoxDetailsAreDisplayed();
        }

        [Then("after (.*) click, validate output message '(.*)'")]
        public void ThenAfterClickValidateMsg(string buttonClickType, string message)
        {
            VerifyMessageDisplayedAfterClicks(buttonClickType, message);
        }

        [Then("label Select file with Choose file button is displayed")]
        public void ThenLabelSelectFileWithChooseFileButtonIsDisplayed()
        {
            VerifyLabelSelectFileIsDisplayed();
            ValidateChooseFileButtonExists();
        }

        [Then("validate message displayed after upload")]
        public void ThenValidateMessageDisplayedAfterUpload()
        {
            ValidateFileUploadedSuccessMessage(_scenarioContext["uploadedFileName"].ToString()!);
        }

        [Then("Registration form window is opened")]
        public void ThenRegistrationFormWindowIsOpened()
        {
            VerifyRegistrationFormModalIsDisplayed();
        }

        [Then("validate new data row is added successfully")]
        public void ThenValidateNewDataRowIsAddedSuccessfully()
        {
            ValidateNewDataRowIsAdded((List<ElementsWebTableRow>)_scenarioContext["webTableData"], (List<ElementsWebTableRow>)_scenarioContext["newWebTableData"]);
            ValidateNewDataRowFieldsAreCorrectlyDisplayed((List<ElementsWebTableRow>)_scenarioContext["newWebTableData"], (ElementsWebTableRow)_scenarioContext["newAddedRowWebTable"]);
        }

        [Then("records are filtered by entered first name")]
        public void ThenRecordsAreFilteredByEnteredFirstName()
        {
            VerifyFilteredRecordOfWebTable((ElementsWebTableRow)_scenarioContext["newAddedRowWebTable"]);
        }

        [Then("validate unfiltered original data is displayed")]
        public void ThenValidateUnfilteredOriginalDataIsDisplayed()
        {
            VerifyWebTableDataIsDisplayedAsExpected((List<ElementsWebTableRow>)_scenarioContext["newWebTableData"]);
        }

        [Then("validate deleted data row is not displayed")]
        public void ThenValidateDeletedDataRowIsNotDisplayed()
        {
            VerifyWebTableDataIsDisplayedAsExpected((List<ElementsWebTableRow>)_scenarioContext["webTableData"]);
        }

        #endregion
    }
}
