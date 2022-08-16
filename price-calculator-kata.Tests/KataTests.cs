namespace price_calculator_kata.Tests;

public class KataTests
{
   [Fact]
public void AddTwoNumbers_returns_sum_of_numbers()
{
    //Arrange
    var calculator = new Calculator();
    //Act
    var result = calculator.AddTwoNumbers(5, 6);
    //Assert
    Assert.Equal(11, result);
}
}