Feature: CalculSimple

Test the regular operations made by CalculSimple DLL

@AddNumbers
Scenario: adding numbers
	Given user want add <operande1> and <operande2>
	When user click addbutton
	Then the result <result> is printed on the screen
	Examples: 
	| operande1 | operande2 | result |
	|      0    |      0    |    0   |
	|     50    |     30    |   80   |
	|      1    |     100   |   101  |
	|     5     |    -10    |   -5   |
	|     -3    |     -7    |   -10  |

@SubstructNumbers
Scenario: substruct two numbers
	Given user want to substruct <operande1> and <operande2>
	When user click substruct-button
	Then the result <result> is printed on the screen
	Examples: 
	| operande1 | operande2 | result |
	|      0    |      0    |    0   |
	|     50    |     30    |   20   |
	|      1    |     100   |   -99  |
	|     5     |    -10    |   15   |
	|     -3    |     -7    |    4   |
