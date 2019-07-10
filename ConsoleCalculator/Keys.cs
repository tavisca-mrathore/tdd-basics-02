using System.Linq;


namespace ConsoleCalculator
{
    public class Keys
    {
        private char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
        private char[] operators = { '-', '+', 'x', 'X', '/', '=' };
        private char[] specialKeys = { 's', 'S', 'c', 'C' };
        private char[] resultSign = { '=' };
        public enum KeyTypes
        {
            IsNumber, IsOperator, IsSpecialKeys, IsResultSign
        }
        public bool ValidateKey(char key, KeyTypes keyType)
        {
            switch (keyType)
            {
                case KeyTypes.IsNumber:
                    return Enumerable.Contains(numbers, key);
                case KeyTypes.IsOperator:
                    return Enumerable.Contains(operators, key);
                case KeyTypes.IsResultSign:
                    return Enumerable.Contains(resultSign, key);
                case KeyTypes.IsSpecialKeys:
                    return Enumerable.Contains(specialKeys, key);
            }
            return false;
        }
    }
}
