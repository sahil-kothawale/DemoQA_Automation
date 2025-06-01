using DemoQA_Automation.Helpers;
using DemoQA_Automation.Models;
using OpenQA.Selenium;
using Reqnroll;

namespace DemoQA_Automation.Pages
{
    internal class Elements : BrowserDriver
    {
        #region Locators
        private static IWebElement elementsDropDownelement => driver.FindElement(By.XPath("//*[text()='Elements']//ancestor::div[@class='element-group']//div[contains(@class,'element-list')]"));
        private static IWebElement inputFullName => driver.FindElement(By.Id("userName"));
        private static IWebElement inputEmail => driver.FindElement(By.Id("userEmail"));
        private static IWebElement inputCurrentAddress => driver.FindElement(By.Id("currentAddress"));
        private static IWebElement inputPermanentAddress => driver.FindElement(By.Id("permanentAddress"));
        private static IWebElement outputTxtFullName => driver.FindElement(By.XPath("//*[@id='output']//p[@id='name']"));
        private static IWebElement outputTxtEmail => driver.FindElement(By.XPath("//*[@id='output']//p[@id='email']"));
        private static IWebElement outputTxtCurrentAddress => driver.FindElement(By.XPath("//*[@id='output']//p[@id='currentAddress']"));
        private static IWebElement outputTxtPermanentAddress => driver.FindElement(By.XPath("//*[@id='output']//p[@id='permanentAddress']"));
        private static IWebElement outputTxtAfterDynamicClick => driver.FindElement(By.Id("dynamicClickMessage"));
        private static IWebElement outputTxtAfterRightClick => driver.FindElement(By.Id("rightClickMessage"));
        private static IWebElement outputTxtAfterDoubleClick => driver.FindElement(By.Id("doubleClickMessage"));
        private static IWebElement inputUploadChooseFile => driver.FindElement(By.Id("uploadFile"));
        private static IWebElement outputTxtAfterFileUpload => driver.FindElement(By.Id("uploadedFilePath"));
        private static IWebElement inputFirstNameWebTable => driver.FindElement(By.Id("firstName"));
        private static IWebElement inputLastNameWebTable => driver.FindElement(By.Id("lastName"));
        private static IWebElement inputEmailWebTable => driver.FindElement(By.Id("userEmail"));
        private static IWebElement inputAgeWebTable => driver.FindElement(By.Id("age"));
        private static IWebElement inputSalaryWebTable => driver.FindElement(By.Id("salary"));
        private static IWebElement inputDepartmentWebTable => driver.FindElement(By.Id("department"));
        private static IWebElement inputTypeToSearchFilterBox => driver.FindElement(By.Id("searchBox"));


        #endregion

        #region Action methods
        internal static void EnterFullName(string name)
        {
            GenericActions.EnterText(inputFullName, name);
        }

        internal static void EnterEmail(string email)
        {
            GenericActions.EnterText(inputEmail, email);
        }

        internal static void EnterCurrentAddress(string currentAddress)
        {
            GenericActions.EnterText(inputCurrentAddress, currentAddress);
        }

        internal static void EnterPermanentAddress(string permanentAddress)
        {
            GenericActions.EnterText(inputPermanentAddress, permanentAddress);
        }

        internal static void SelectsRadiobutton(string optionToBeSelected)
        {
            IWebElement radioButtonToBeSelected = driver.FindElement(By.XPath($"//label[text()='{optionToBeSelected}']"));
            GenericActions.ScrollOnElement(radioButtonToBeSelected);
            GenericActions.Click(radioButtonToBeSelected);
        }

        internal static void ExpandAllCheckBoxOptions()
        {
            IWebElement buttonExpandAll = driver.FindElement(By.XPath("//button[@title='Expand all']"));
            GenericActions.ScrollOnElement(buttonExpandAll);
            GenericActions.Click(buttonExpandAll);
        }

        internal static void CollapseAllCheckBoxOptions()
        {
            IWebElement buttonCollapseAll = driver.FindElement(By.XPath("//button[@title='Collapse all']"));
            GenericActions.ScrollOnElement(buttonCollapseAll);
            GenericActions.Click(buttonCollapseAll);
        }

        internal static void SelectAllRequiredCheckBoxes(DataTable table)
        {
            string[] nodes = Array.Empty<string>();
            string selectedCheckboxes = string.Empty;
            foreach (var row in table.Rows)
            {
                CollapseAllCheckBoxOptions();
                string path = row["Selection Path"];
                foreach (char c in path)
                {
                    nodes = path.Split('>', StringSplitOptions.TrimEntries);
                }
                SelectCheckBoxes(nodes, nodes[nodes.Length - 1]);
            }
        }

        private static void SelectCheckBoxes(string[] nodes, string actualCheckboxesToSelect)
        {
            string[] checkboxes = Array.Empty<string>();
            foreach (char c in actualCheckboxesToSelect)
            {
                checkboxes = actualCheckboxesToSelect.Split(',');
            }
            try
            {
                for (int i = 0; i < nodes.Length - 1; i++)
                {
                    IWebElement nodeToggleButton = driver.FindElement(By.XPath($"//*[text()='{nodes[i]}']/parent::label/preceding-sibling::button[@title='Toggle']"));
                    GenericActions.Click(nodeToggleButton);
                }
                foreach (string box in checkboxes)
                {
                    IWebElement checkBoxElement = driver.FindElement(By.XPath($"//*[text()='{box}']/parent::label/span[@class='rct-checkbox']"));
                    GenericActions.Click(checkBoxElement);
                }
            }
            catch (NoSuchElementException ex)
            {
                throw new ArgumentException($"Invalid checkbox path.\n{ex.Message}");
            }
        }

        internal static void DoubleClickMeButton()
        {
            By doubleClickMeButton = By.Id("doubleClickBtn");
            new Waits().ElementToBeClickable(doubleClickMeButton);
            Thread.Sleep(1000);
            GenericActions.DoubleClick(driver.FindElement(doubleClickMeButton));
        }

        internal static void RightClickMeButton()
        {
            IWebElement rightClickMeButton = driver.FindElement(By.Id("rightClickBtn"));
            GenericActions.RightClick(rightClickMeButton);
        }

        internal static void UploadFile(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (File.Exists(path))
            {
                GenericActions.EnterText(inputUploadChooseFile, path);
            }
            else
                throw new FileNotFoundException($"File not found at: {path}");
        }

        internal static List<ElementsWebTableRow> GetAllDataFromElementsWebTable()
        {
            IList<IWebElement> rowElements = driver.FindElements(By.XPath("//div[contains(@class,'tbody')]//div[not(descendant::span)]/parent::div"));
            List<ElementsWebTableRow> rowList = new List<ElementsWebTableRow>();

            for (int i = 1; i <= rowElements.Count; i++)
            {
                IList<IWebElement> cellElements = driver.FindElements(By.XPath($"(//div[contains(@class,'tbody')]//div[@role='row'])[{i}]/div[not(descendant::span)]"));
                ElementsWebTableRow row = new ElementsWebTableRow();
                row.FirstName = cellElements[0].Text;
                row.LastName = cellElements[1].Text;
                row.Age = int.Parse(cellElements[2].Text);
                row.Email = cellElements[3].Text;
                row.Salary = long.Parse(cellElements[4].Text);
                row.Department = cellElements[5].Text;
                rowList.Add(row);
            }
            return rowList;
        }

        internal static ElementsWebTableRow EnterNewRowDataIntoWebTable(DataTableRow row)
        {
            ElementsWebTableRow newRow = new ElementsWebTableRow
                (row["FirstName"],
                    row["LastName"],
                    int.Parse(row["Age"]),
                    row["Email"],
                    long.Parse(row["Salary"]),
                    row["Department"]);
            FillRegistrationFormDetails(newRow);
            return newRow;
        }

        internal static void FillRegistrationFormDetails(ElementsWebTableRow row)
        {
            GenericActions.EnterText(inputFirstNameWebTable, row.FirstName!);
            GenericActions.EnterText(inputLastNameWebTable, row.LastName!);
            GenericActions.EnterText(inputEmailWebTable, row.Email!);
            GenericActions.EnterText(inputAgeWebTable, row.Age.ToString());
            GenericActions.EnterText(inputSalaryWebTable, row.Salary.ToString());
            GenericActions.EnterText(inputDepartmentWebTable, row.Department!);
        }

        internal static void EnterIntoTypeToSearchFilterBox(string infoToSearch)
        {
            GenericActions.EnterText(inputTypeToSearchFilterBox, infoToSearch);
        }

        internal static void ClearTypeToSearchFilterBox()
        {
            GenericActions.ClearText(inputTypeToSearchFilterBox, useKeys: true);
        }

        internal static void DeleteNewlyAddedRecordFromWebTable()
        {
            IWebElement deleteIcon = driver.FindElement(By.XPath($"(//span[contains(@id,'delete-record')])[{GetAllDataFromElementsWebTable().Count}]"));
            GenericActions.ScrollAndClick(deleteIcon);
        }

        #endregion

        #region Validation methods
        internal static void VerifyElementsDropDownIsOpen()
        {
            Assert.That(GenericActions.GetAttributeValue(elementsDropDownelement, "class"), Does.Contain("show"));
        }

        internal static void VerifyElementsDropDownIsClosed()
        {
            Assert.That(GenericActions.GetAttributeValue(elementsDropDownelement, "class"), Does.Not.Contain("show"));
        }

        internal static void ValidateEnteredTextBoxDetailsFromTable(ScenarioContext scenarioContext)
        {
            GenericActions.ValidateText($"Name:{scenarioContext["textbox_FullName"]}", outputTxtFullName);
            GenericActions.ValidateText($"Email:{scenarioContext["textbox_email"]}", outputTxtEmail);
            GenericActions.ValidateText($"Current Address :{scenarioContext["textbox_currAdd"]}", outputTxtCurrentAddress);
            GenericActions.ValidateText($"Permananet Address :{scenarioContext["textbox_perAdd"]}", outputTxtPermanentAddress);
        }

        internal static void VerifyRadioButtonQuestionLabel()
        {
            By labelElement = By.XPath("//*[contains(text(),'site?')]");
            GenericActions.IsElementPresent(labelElement, "Do you like the site?");
        }

        internal static void VerifyThatNoRadioButtonOptionIsDisabled()
        {
            IWebElement noRadioButtonOption = driver.FindElement(By.XPath("//input[@type='radio']/following-sibling::label[text()='No']"));
            Assert.That(GenericActions.GetAttributeValue(noRadioButtonOption, "class"), Does.Contain("disabled"));
        }

        internal static void ValidateSelectedRadioButtonConfirmationText(string optionSelected)
        {
            By successMsgElement = By.XPath("//span[@class='text-success']/parent::p");
            new Waits().ElementToBeVisible(successMsgElement);
            GenericActions.ValidateText($"You have selected {optionSelected}", driver.FindElement(successMsgElement));
        }

        internal static void ValidateSelectedCheckoxDetailsAreDisplayed()
        {
            IWebElement resultTxtElements = driver.FindElement(By.XPath("//div[@id='result']"));
            GenericActions.ValidateText("You have selected :\r\nnotes\r\nreact\r\nangular\r\nprivate\r\nclassified\r\ngeneral\r\nwordFile", resultTxtElements);
        }

        internal static void VerifyMessageDisplayedAfterClicks(string buttonClickType, string message)
        {
            switch (buttonClickType.ToLower())
            {
                case "dynamic":
                    GenericActions.ScrollOnElement(outputTxtAfterDynamicClick);
                    GenericActions.ValidateText(message, outputTxtAfterDynamicClick);
                    break;
                case "right":
                    GenericActions.ScrollOnElement(outputTxtAfterRightClick);
                    GenericActions.ValidateText(message, outputTxtAfterRightClick);
                    break;
                case "double":
                    GenericActions.ScrollOnElement(outputTxtAfterDoubleClick);
                    GenericActions.ValidateText(message, outputTxtAfterDoubleClick);
                    break;
                default:
                    throw new ArgumentException($"Invalid button click type {buttonClickType}.");
            }
        }

        internal static void VerifyLabelSelectFileIsDisplayed()
        {
            By labelSelectFile = By.XPath("//label[text()='Select a file']");
            GenericActions.IsElementPresent(labelSelectFile, "Select file label");
        }

        internal static void ValidateChooseFileButtonExists()
        {
            By inputChooseFile = By.Id("uploadFile");
            GenericActions.IsElementPresent(inputChooseFile, "Choose file upload");
        }

        internal static void ValidateFileUploadedSuccessMessage(string fileName)
        {
            GenericActions.ValidateContainedText(fileName, outputTxtAfterFileUpload);
        }

        internal static void VerifyRegistrationFormModalIsDisplayed()
        {
            By modalElement = By.XPath("//div[@class='modal-content']//*[text()='Registration Form']");
            GenericActions.IsElementPresent(modalElement, "Registration form window");
        }

        internal static void ValidateNewDataRowIsAdded(List<ElementsWebTableRow> oldData, List<ElementsWebTableRow> newData)
        {
            Assert.That(newData.Count, Is.EqualTo(oldData.Count + 1));
        }

        internal static void ValidateNewDataRowFieldsAreCorrectlyDisplayed(List<ElementsWebTableRow> newFullData, ElementsWebTableRow newlyAddedRow)
        {
            IList<IWebElement> cellElements = driver.FindElements(By.XPath($"(//div[contains(@class,'tbody')]//div[@role='row'])[{newFullData.Count}]/div[not(descendant::span)]"));
            GenericActions.ValidateText(newlyAddedRow.FirstName!, cellElements[0]);
            GenericActions.ValidateText(newlyAddedRow.LastName!, cellElements[1]);
            GenericActions.ValidateText(newlyAddedRow.Age.ToString(), cellElements[2]);
            GenericActions.ValidateText(newlyAddedRow.Email!, cellElements[3]);
            GenericActions.ValidateText(newlyAddedRow.Salary.ToString(), cellElements[4]);
            GenericActions.ValidateText(newlyAddedRow.Department!, cellElements[5]);
        }

        internal static void VerifyFilteredRecordOfWebTable(ElementsWebTableRow rowToBeDisplayed)
        {
            Assert.That(GetAllDataFromElementsWebTable().Count, Is.EqualTo(1));
            Assert.That(GetAllDataFromElementsWebTable()[0].Equals(rowToBeDisplayed), Is.True);
        }

        internal static void VerifyWebTableDataIsDisplayedAsExpected(List<ElementsWebTableRow> originalExpectedData)
        {
            List<ElementsWebTableRow> actualList = GetAllDataFromElementsWebTable();
            for (int i = 0; i < originalExpectedData.Count; i++)
            {
                Assert.That(actualList[i].Equals(originalExpectedData[i]), Is.True);
            }
        }

        #endregion
    }
}
