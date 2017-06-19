Feature: Login
	In order to do work
	As a a client
	I want to login to smarttesters training portal

@Login
Scenario Outline: Logging into Smart Testers Training portal
	Given I goto "http://localhost/smarttesters/account.php" on "<BROWSER>"
	And I enter "Username" as "<USERNAME>"
	And I enter "Password" as "<PASSWORD>"
	When I click "loginButton"
	Then login is "<EXPECTEDRESULT>"
	@source:SpecFlowTestData.xlsx:logintestdata
	Examples: 
	| BROWSER | USERNAME | PASSWORD   | EXPECTEDRESULT |
