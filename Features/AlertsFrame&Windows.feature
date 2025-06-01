Feature: 'Alerts, Frame & Windows' page test scenarios 
This feature covers test scenarios for the 'Alerts, Frame & Windows' page.

Background: Visit DemoQA
	Given Demo-QA web application is launched
	Then ToolsQA homepage is displayed
	And all expected UI cards are displayed
	When selects Alerts, Frame & Windows card
	Then alertsWindows page is displayed

@AlertsFrameWindowsTest
Scenario: Alerts Frame Windows card test
	Then Alerts, Frame & Windows dropdown is open by default
	When user selects Alerts, Frame & Windows tab 
	Then Alerts, Frame & Windows dropdown is closed

@AlertsFrameWindowsTest
Scenario: Alerts - test
	When user selects Alerts sub-tab
	Then alerts page is displayed
	When user clicks on the 1st Click me button
	Then Alert with message 'You clicked a button' is displayed
	When user clicks on 'OK' button in the alert
	Then Alert is no longer displayed
	When user clicks on the 2nd Click me button
	And waits 5 seconds for alert to be displayed 
	Then Alert with message 'This alert appeared after 5 seconds' is displayed
	When user clicks on 'OK' button in the alert
	Then Alert is no longer displayed
	When user clicks on the 3rd Click me button
	Then Alert with message 'Do you confirm action?' is displayed
	When user clicks on 'OK' button in the alert
	Then 'You selected Ok' confirmation message is shown
	When user clicks on the 3rd Click me button
	Then Alert with message 'Do you confirm action?' is displayed
	When user clicks on 'Cancel' button in the alert
	Then 'You selected Cancel' confirmation message is shown
	When user clicks on the 4th Click me button
	Then Alert with message 'Please enter your name' is displayed
	When user enters name in alert as 'Luffy'
	Then 'You entered Luffy' entered prompt message is shown

@AlertsFrameWindowsTest
Scenario: Frames - test
	When user selects Frames sub-tab
	Then frames page is displayed
	When user switches to first iframe
	Then validates heading text in frame 'This is a sample page'
	When user returns to original frame
	And user switches to second iframe
	And user scrolls down to bottom in frame
	Then validates heading text in frame 'This is a sample page'

@AlertsFrameWindowsTest
Scenario: Browser Windows - test
	When user selects Browser Windows sub-tab
	Then browser-windows page is displayed
	Given user is working on original tab
	When clicks on New Window button
	Then check if user navigates to new tab
	When user returns to original tab
	Given user is working on original tab
	When clicks on New Window Message button
	Then check if user navigates to new tab