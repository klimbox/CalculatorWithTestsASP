Feature: SpecFlowCalcFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Buttons
Scenario Outline: All buttons can be pressed
	Given I press <button>
	Then i Expect <value> on screen
	
	Examples:
    | button   | value |
    |  num1    |   1   |
    |  num2    |   2   |

@Sum
Scenario: X + Y
	Given Enter first number 1
	Given Press add
	Given Enter second number 2
	When Press =
	Then Expect 3 on screen

@Sub
Scenario: X - Y
	Given Enter first number 1
	Given Press Sub
	Given Enter second number 2
	When Press = 
	Then Expect -1 on screen

@Mul
Scenario: X mul Y
	Given Enter first number 4
	Given Press mul
	Given Enter second number 5
	When Press = 
	Then Expect 20 on screen

@Div
Scenario: X div Y
	Given Enter first number 6
	Given Press div
	Given Enter second number 3
	When Press = 
	Then Expect 2 on screen

