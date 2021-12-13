Feature: KeyPresses
		
@Assertingkeypresses
Scenario Outline: Key Presses test
   Given I open the Home Page
   And the page title is displayed
   And I select the Key Presses on menu 
   When I press <key>
   Then You entered: <message> is displayed

Examples:
	|  key  | message |
	|   R	|   R     |
	|   C   |   C     |
	|   5   |   5     |
	|   9   |   9     |