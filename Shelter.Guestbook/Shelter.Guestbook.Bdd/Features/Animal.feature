Feature: Animal

A short summary of the feature

@tag1
Scenario: Add new animal with valid data
	Given the name is "Lua"
	And the species is "Cat"
	And the description is "Cute"
	When animals is sent to the server
	Then animal is created

Scenario: Add new animal with invalid data
	Given the name is "Lua"
	And the species is ""
	And the description is "Cute"
	When animals is sent to the server
	Then animal is not created
