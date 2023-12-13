using NLog;

namespace ConsoleVersion
{
    internal class NumberValidator
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static bool IsValidIntNumber(string userInput, out int result)
        {
            bool isValid = false;
            if (IsNumeric(userInput, out result))
            {
                isValid = result >= int.MinValue && result <= int.MaxValue;
                if (!isValid)
                {
                    logger.Error($"{userInput} is not in the range ({int.MinValue} - {int.MaxValue})");
                }
            }
            else
            {
                logger.Error($"{userInput} is not a number");
            }
            return isValid;
        }

        private static bool IsNumeric(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

    }
}

