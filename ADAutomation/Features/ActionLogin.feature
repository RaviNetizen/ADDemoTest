Feature: Action Login
	 
@AutomateFormAuthentication
Scenario Outline: Login Credentials test
   Given I open the Home Page
   And the page title is displayed
   And I select the Form Authentication on menu 
   When I enter <username>
   And I input <password>
   And I click login button
   Then the <message> is displayed

Examples:
	| username | password             | message                        |
	| tomsmith | SuperSecret          | Your password is invalid!      |
	| tomsmi   | SuperSecretPassword! | Your username is invalid!      |
	| tomsmith | SuperSecretPassword! | You logged into a secure area! |  

@LogoutScenario 
Scenario: Login Logout test
   Given I open the Home Page
   And the page title is displayed
   And I select the Form Authentication on menu 
   When I enter tomsmith
   And I input SuperSecretPassword!
   And I click login button
  Then the You logged into a secure area! is displayed
  And I clicked the logout button
  Then I assert a log out message is displayed 