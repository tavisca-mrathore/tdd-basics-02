using System;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
        Keys keyObj;
        private char operatingSymbol = '+';
        private string operandOne = "";
        private string operandTwo = "";
        public string display = "";
        private bool operatorIsAvailable = false;

        public Calculator()
        {
            keyObj = new Keys();
        }
        public string SendKeyPress(char key)
        {
            if (keyObj.ValidateKey(key, Keys.KeyTypes.IsResultSign))
            {
                return InputIsResultSign();
            }
            if (keyObj.ValidateKey(key, Keys.KeyTypes.IsNumber))
            {
                InputIsOperand(key);
            }
            if (keyObj.ValidateKey(key, Keys.KeyTypes.IsOperator))
            {
                InputIsOperator(key);
            }
            if (keyObj.ValidateKey(key, Keys.KeyTypes.IsSpecialKeys))
            {
                InputIsSpecialKey(key);
            }

            return display;
        }

        private string InputIsResultSign()
        {
            if (operandTwo.Equals("") && operatorIsAvailable)
            {
                return display;
            }
            display = PerformOperation(operatingSymbol);
            return display;
        }

        private void InputIsSpecialKey(char key)
        {
            switch (key)
            {
                case 'C':
                    ResetCalculator();
                    break;
                case 'c':
                    ResetCalculator();
                    break;
                case 's':
                    ToggleSignOfOperand();
                    break;
                case 'S':
                    ToggleSignOfOperand();
                    break;
            }
        }

        private void InputIsOperator(char key)
        {
            if (operatorIsAvailable)
            {
                operandOne = PerformOperation(key);
                display = operandOne;

                // operatorIsAvailable = true;
                operatingSymbol = key;
                operandTwo = "";
            }
            else
            {
                operatingSymbol = key;
                operatorIsAvailable = true;
            }
        }

        private void InputIsOperand(char key)
        {
            if (operatorIsAvailable)
            {
                operandTwo += key;
                operandTwo = ValidateOperand(operandTwo);
                display = operandTwo;
            }
            else
            {
                operandOne += key;
                operandOne = ValidateOperand(operandOne);
                display = operandOne;
            }
        }

        private void ToggleSignOfOperand()
        {
            if (operatorIsAvailable)
            {
                operandTwo = (-Double.Parse(operandTwo)).ToString();
                display = operandTwo;
            }
            else
            {
                operandOne = (-Double.Parse(operandOne)).ToString();
                display = operandOne;
            }
        }

        private void ResetCalculator()
        {
            display = "0";
            operandOne = "";
            operandTwo = "";
            operatorIsAvailable = false;
        }

        private string ValidateOperand(string operand)
        {
            // For Leading Zeros
            operand = Regex.Replace(operand, @"^0+", "0");
            //operand = Regex.Replace(operand, @"0+\.", "0.");
            // For Multiple Decimals
            operand = Regex.Replace(operand, @"\.+", ".");
            return operand;
        }

        private string PerformOperation(char key)
        {
            double answer = 0;
            string error = "-E-";

            switch (key)
            {
                case '+':
                    answer = Double.Parse(operandOne) + Double.Parse(operandTwo);
                    break;
                case '-':
                    answer = Double.Parse(operandOne) - Double.Parse(operandTwo);
                    break;
                case 'x':
                    answer = Double.Parse(operandOne) * Double.Parse(operandTwo);
                    break;
                case 'X':
                    answer = Double.Parse(operandOne) * Double.Parse(operandTwo);
                    break;
                case '/':
                    answer = Double.Parse(operandOne) / Double.Parse(operandTwo);
                    break;
            }
            if (Double.IsNaN(answer) || Double.IsInfinity(answer))
            {
                return error;
            }

            return answer.ToString();
        }

    }
}
