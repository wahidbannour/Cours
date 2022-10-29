Feature: CalculSimple

composant de calcul simple

@tag1
Scenario: Add two Number
	Given user want to add 50 and 30
	When click add button
	Then result must be 80
