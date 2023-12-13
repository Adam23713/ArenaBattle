using GameLogic.Manager;
using NLog;

namespace ConsoleVersion 
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            int numberOfWarrior;
            if (args.Length > 0)
            {
                if (NumberValidator.IsValidIntNumber(args[0], out numberOfWarrior))
                {
                    var gameManager = GameManager.Instance;
                    gameManager.StartGameAsync(numberOfWarrior);
                    gameManager.Wait();
                }
            }
            else
            {
                logger.Error("Empty argument");
            }

            Console.WriteLine("Press any key to close this window...");
            Console.ReadLine();
        }
    }
}
