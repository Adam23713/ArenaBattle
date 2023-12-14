using NLog;

namespace ConsoleVersion
{
    internal class NumberValidator
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static bool IsValidIntNumber(string userInput, out int result)
        {
            bool isValid = false;
            long number;
            result = 0;
            if (long.TryParse(userInput, out number))
            {
                isValid = number >= int.MinValue && number <= int.MaxValue;
                if (!isValid)
                {
                    logger.Error($"{userInput} is not in the range ({int.MinValue} - {int.MaxValue})");
                }
                else
                {
                    result = (int)number;
                }
            }
            else
            {
                logger.Error($"{userInput} is not a number");
            }
            return isValid;
        }
    }
}

