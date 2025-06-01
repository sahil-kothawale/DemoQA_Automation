Feature: 'Widgets' page test scenarios 
This feature covers test scenarios for the 'Widgets' page.

Background: Visit DemoQA
	Given Demo-QA web application is launched
	Then ToolsQA homepage is displayed
	And all expected UI cards are displayed
	When selects Widgets card
	Then widgets page is displayed

@WidgetsTest
Scenario: Widgets card test
	Then Widgets dropdown is open by default
	When user selects Widgets tab 
	Then Widgets dropdown is closed

@WidgetsTest
Scenario: Widgets - Accordian test
	When user selects Accordian sub-tab
	Then accordian page is displayed
	And only 'What is Lorem Ipsum?' accordian section is open by default
	When user clicks on 'Where does it come from?' accordion section
	Then only 'Where does it come from?' accordian section is open
	When user clicks on 'Why do we use it?' accordion section
	Then only 'Why do we use it?' accordian section is open
	When user clicks on 'Why do we use it?' accordion section
	Then all accordian sections are closed

@WidgetsTest
Scenario: Widgets - Auto Complete (multiple) test
	When user selects Auto Complete sub-tab
	Then auto-complete page is displayed
	Given list created to store selected colors
	When user types 'R' in the 'Type multiple color names' input box
	Then relevant correct colors are displayed in dropdown below
	When user selects 'Red' color option
	Then 'Red' option is selected and displayed with its corresponding remove icon
	When user types 'R' in the 'Type multiple color names' input box again
	Then relevant correct colors are displayed in dropdown below
	When user selects 'Purple' color option
	Then 'Purple' option is selected and displayed with its corresponding remove icon
	And previously selected 'Red' option is still selected and displayed
	When clicks on remove icon of 'Purple' option
	When user types 'I' in the 'Type multiple color names' input box
	Then relevant correct colors are displayed in dropdown below
	When user adds 'n' in the existing text of 'Type multiple color names' input box
	Then relevant correct colors are displayed in dropdown below
	When user selects 'Indigo' color option
	Then 'Indigo' option is selected and displayed with its corresponding remove icon
	When clicks on remove all icon
	Then No color option will be selected and displayed

@WidgetsTest
Scenario: Widgets - Date Picker test
	When user selects Date Picker sub-tab
	Then date-picker page is displayed
	When user opens the calendar for Select date
	And selects year as '1999' from year dropdown
	And selects month as 'December' and date as '22' from month dropdown
	Then validate selected date is displayed
	When user selects date as 'September 28, 2012' and time as '11:45AM'
	Then validate selected date and time is as expected

@WidgetsTest
Scenario: Widgets - Slider test
	When user selects Slider sub-tab
	Then slider page is displayed
	And slider is at 25 by default
	And min max values are 0 and 100
	When user drags slider to 50
	Then textbox and slider show value 50
	When user drags slider to 77
	Then textbox and slider show value 77
	When user drags slider to 100
	Then textbox and slider show value 100
	When user drags slider to 0
	Then textbox and slider show value 0

@WidgetsTest
Scenario: Widgets - Tool tips test
	When user selects Tool Tips sub-tab
	Then tool-tips page is displayed
	When user hovers on 'Hover me to see' Button
	Then 'You hovered over the Button' message for 'button' tool tip is displayed
	When user hovers on 'Hover me' Textbox
	Then 'You hovered over the text field' message for 'textField' tool tip is displayed
	When user hovers on 'Contrary' link
	Then 'You hovered over the Contrary' message for 'link' tool tip is displayed

@WidgetsTest
Scenario: Widgets - Progress Bar test
	When user selects Progress Bar sub-tab
	Then progress-bar page is displayed
	And Progress bar is displayed by default at 0%
	When clicks on Start button
	Then Stop button is available
	When clicks on Stop button
	Then Start button is available
	When clicks on Start button
	And wait till progress bar is complete
	Then validate progress bar reaches 100% and is success
	And Reset button is available
	When clicks on Reset button
	Then Progress bar resets to 0%
	And Start button is available

@WidgetsTest
Scenario: Widgets - Tabs test
	When user selects Tabs sub-tab
	Then tabs page is displayed
	And verify all expected tabs are displayed
	And 'More' tab is disabled
	And 'What' tab is in active state
	When user selects 'Origin' tab from menu
	Then 'Origin' tab is in active state
	When user selects 'Use' tab from menu
	Then 'Use' tab is in active state