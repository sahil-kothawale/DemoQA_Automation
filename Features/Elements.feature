Feature: 'Elements' page test scenarios 
This feature covers test scenarios for the 'Elements' page.

Background: Visit DemoQA
	Given Demo-QA web application is launched
	Then ToolsQA homepage is displayed
	And all expected UI cards are displayed
	When selects Elements card
	Then elements page is displayed

@ElementsTest
Scenario: Elements card test
	Then Elements dropdown is open by default
	When user selects Elements tab 
	Then Elements dropdown is closed

@ElementsTest
Scenario Outline: Elements - Textbox test
	When user selects Text Box sub-tab
	Then text-box page is displayed
	When user enters full name as <fullName> in textbox
	And user enters email as <email> in textbox
	And user enters <currentAddress> and <permanentAddress> addresses
	And clicks on Submit button
	Then validate entered text details displayed below
Examples: 
| fullName   | email                  | currentAddress             | permanentAddress |
| Nico Robin | nicorobin07@crew.in    | Thousand sunny, Grand Line | Ohara, West blue |
| Gaara      | kazekagegaara@ninja.in | Uzumaki Residence, Konoha  | Sunagakure       |

@ElementsTest
Scenario: Elements - Radiobutton test
	When user selects Radio Button sub-tab
	Then radio-button page is displayed
	And label with 'Do you like this site' text is displayed
	And verify that 'No' option is disabled
	When user selects Yes radiobutton
	Then validate selected radiobutton is displayed below
	When user selects Impressive radiobutton
	Then validate selected radiobutton is displayed below

@ElementsTest
Scenario: Elements - Checkbox test
	When user selects Check Box sub-tab
	Then checkbox page is displayed
	When user clicks on plus icon to see all checkboxes
	And selects required checkboxes from the list
	| Selection Path                                         |
	| Home > Desktop > Notes                                 |
	| Home > Documents > WorkSpace > React,Angular           |
	| Home > Documents > Office > Private,Classified,General |
	| Home > Downloads > Word File.doc                       |
	Then validate details from selected checkboxes is displayed below

@ElementsTest
Scenario: Elements - Buttons test
	When user selects Buttons sub-tab
	Then buttons page is displayed
	When clicks on Click Me button
	Then after dynamic click, validate output message 'You have done a dynamic click'
	When user double clicks on 'Double Click Me' button
	Then after double click, validate output message 'You have done a double click'
	When user right clicks on 'Right Click Me' button
	Then after right click, validate output message 'You have done a right click'

@ElementsTest
Scenario: Elements - Links test
	When user selects Links sub-tab
	Then links page is displayed
	Given user is working on original tab
	When user clicks on Home link
	Then check if user navigates to new tab
	And ToolsQA homepage is displayed
	And all expected UI cards are displayed

@ElementsTest
Scenario: Elements - Upload and Download test
	When user selects Upload and Download sub-tab
	Then upload-download page is displayed
	And label Select file with Choose file button is displayed
	When user uploads a file testFileToUpload.txt
	Then validate message displayed after upload
	#When user clicks on Download link
	#Then file is downloaded

@ElementsTest
Scenario: Elements - Web Table test
	When user selects Web Tables sub-tab
	Then webtables page is displayed
	When user captures data from web table
	And clicks on Add button
	Then Registration form window is opened
	When user enters new data
	| FirstName | LastName | Email                 | Age | Salary | Department |
	| Zenitsu   | Agatsuma | agatsumazen@slayer.in | 18  | 11000  | Sales      |
	And clicks on Submit button
	When user captures new latest data from web table
	Then validate new data row is added successfully
	When user enters name in Type to search filter box
	Then records are filtered by entered first name
	When user clears the search filter box
	Then validate unfiltered original data is displayed
	When user clicks on the delete icon for newly added record
	Then validate deleted data row is not displayed