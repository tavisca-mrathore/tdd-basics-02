using System;
using Xunit;
using ConsoleCalculator;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator;

        public CalculatorFixture()
        {
            calculator = new Calculator();
        }

        [Fact]
        public void FailsForInvalidKeyTest()
        {
            calculator.SendKeyPress('1');
            Assert.Equal("1", calculator.SendKeyPress('y'));
        }


        [Fact]
        public void PassForValidKeyTest()
        {
            Assert.Equal("0", calculator.SendKeyPress('0'));
        }

        public void MultiKeyPress(char[] keys)
        {
            foreach (char key in keys)
            {
                calculator.SendKeyPress(key);
            }
        }

        [Fact]
        public void AdditionOperationTest()
        {
            char[] input = { '1', '+', '1' };
            MultiKeyPress(input);
            Assert.Equal("2", calculator.SendKeyPress('='));
        }

        [Fact]
        public void SubtrationOperationTest()
        {
            char[] input = { '5', '-', '5' };
            MultiKeyPress(input);
            Assert.Equal("0", calculator.SendKeyPress('='));
        }

        [Fact]
        public void MultiplicationOperationTest()
        {
            char[] input = { '5', 'x', '5' };
            MultiKeyPress(input);
            Assert.Equal("25", calculator.SendKeyPress('='));
        }

        [Fact]
        public void DivisionOperationTest()
        {
            char[] input = { '5', '/', '5' };
            MultiKeyPress(input);
            Assert.Equal("1", calculator.SendKeyPress('='));
        }

        [Fact]
        public void RestOnKeyPress_C_Test()
        {
            char[] input = { '5', '/', '5' };
            MultiKeyPress(input);
            Assert.Equal("0", calculator.SendKeyPress('c'));
        }

        [Fact]
        public void NegativeNumberTest()
        {
            char[] input = { '5', 's', '+', '5' };
            MultiKeyPress(input);
            Assert.Equal("0", calculator.SendKeyPress('='));
        }

        [Fact]
        public void CaseInsentivityKeysTest()
        {
            char[] input = { '5', 'S', 'X', '5' };
            MultiKeyPress(input);
            Assert.Equal("-25", calculator.SendKeyPress('='));
        }

        [Fact]
        public void DivideByZeroTest()
        {
            char[] input = { '5', '/', '0' };
            MultiKeyPress(input);
            Assert.Equal("-E-", calculator.SendKeyPress('='));
        }

        [Fact]
        public void ScenarioOneTest()
        {
            char[] input1 = { '1', '0', '+', '2' };
            MultiKeyPress(input1);
            Assert.Equal("12", calculator.SendKeyPress('='));

        }

        [Fact]
        public void ScenarioTwoTest()
        {

            char[] input2 = { '1', '0', '/', '0' };
            MultiKeyPress(input2);
            Assert.Equal("-E-", calculator.SendKeyPress('='));

        }

        [Fact]
        public void ScenarioThreeTest()
        {

            char[] input3 = { '0', '0', '.', '.', '0', '0' };
            MultiKeyPress(input3);
            Assert.Equal("0.001", calculator.SendKeyPress('1'));
        }

        [Fact]
        public void ScenarioFourthTest()
        {

            char[] input4 = { '1', '2', '+', '2', 'S', 'S', 'S' };
            MultiKeyPress(input4);
            Assert.Equal("10", calculator.SendKeyPress('='));

        }

        [Fact]
        public void ScenarioFifthTest()
        {
            char[] input5 = { '1', '+', '2', '+', '3', '+', '6' };
            MultiKeyPress(input5);
            Assert.Equal("12", calculator.SendKeyPress('='));
        }

        [Fact]
        public void ScenarioSixthTest()
        {
            char[] input6 = { '1', '+', '2', '+' };
            MultiKeyPress(input6);
            Assert.Equal("0", calculator.SendKeyPress('C'));
        }

    }
}
