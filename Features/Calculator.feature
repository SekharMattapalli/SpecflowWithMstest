Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowCalucator/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@SumOFTwoNumbers
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@SubmissionFTwoNumbers
Scenario: Sub two numbers
	Given the first number is 70
	And the second number is 50
	When the two numbers are Subtracted
	Then the result should be 20

@DivisionOfTwoNumbers
Scenario: divided by two numbers
	Given the first number is 60
	And the second number is 10
	When the two numbers are divided
	Then the result should be 7
