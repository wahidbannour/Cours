Feature: Navigation

A short summary of the feature

@NavigateToCounterMenu
Scenario: Navigate to counter menu
	Given user open the blazor site
	When user click on counter menu
	Then the counter page is visible

@clickEqualToResult
Scenario: Clicks are equals to result
	Given user open the blazor site and click on counter menu
	When user click on clickme button <n> times
	Then result must be equal to <n>

	Examples: 
		| n |
		| 1 |
		| 5 |
		| 7 |

