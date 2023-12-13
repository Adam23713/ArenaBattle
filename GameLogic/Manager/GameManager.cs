using GameLogic.Factory;
using GameLogic.Interface;
using GameLogic.Model;
using NLog;
using NLog.Fluent;
using System;
using System.Text;

namespace GameLogic.Manager
{
    public sealed class GameManager
    {
        #region StaticVariables
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static GameManager? instance = null;

        public static GameManager Instance 
        { 
            get 
            {
                if (instance == null) 
                {
                    instance = new GameManager();
                }
                return instance;
            }

            private set { }
        }
        #endregion

        #region Variables
        Random horsemanChance = new Random();

        private Task? gameTask = null;

        CancellationToken cancellationToken;

        CancellationTokenSource tokenSource;

        List<Warrior> warriors;

        IWarriorFactory warriorFactory = new RandomWarriorFactory();
        #endregion

        private GameManager()
        {
            
        }

        private void GenerateWarriors(int numberOfWarriors)
        {
            warriors = new List<Warrior>();
            for (int i = 0; i < numberOfWarriors; i++)
            {
                Warrior warrior = warriorFactory.CreateWarrior();
                warriors.Add(warrior);
            }
        }

        private Warrior PopRandomWarrior(Random random) 
        {
            var attacker = warriors.ElementAt(random.Next(warriors.Count));
            warriors.Remove(attacker);
            return attacker;
        }

        private void SwordsmanAttack(Warrior attacker, Warrior defender)
        {
            if (defender is Swordsman)
            {
                defender.Dead = true;
            }
            else if(defender is Archer)
            {
                defender.Dead = true;
            }
        }

        private void ArcherAttack(Warrior attacker, Warrior defender)
        {
            if (defender is Swordsman)
            {
                defender.Dead = true;
            }
            else if (defender is Archer)
            {
                defender.Dead= true;
            }
            else if (defender is Knight)
            {
                if(horsemanChance.Next(101) <= 40)
                {
                    defender.Dead = true;
                }
            }
        }

        private void KnightAttack(Warrior attacker, Warrior defender)
        {
            if (defender is Swordsman)
            {
                attacker.Dead = true;
            }
            else if (defender is Archer)
            {
                defender.Dead = true;
            }
            else if (defender is Knight)
            {
                defender.Dead = true;
            }
        }

        private void ReduceHealthPointIfNeed(Warrior warrior)
        {
            if (!warrior.Dead)
            {
                warrior.HP *= 0.5f;
            }
        }

        private void CheckHealthPointsAndKillIfNeed(Warrior warrior)
        {
            if(!warrior.Dead && warrior.HP <= warrior.MaximumHP * 0.25)
            {
                warrior.Dead = true;
            }
        }

        private void IncreaseHealthPoint()
        {
            warriors.ForEach(w => w.AddHpPoints(10)); 
        }

        private string GenerateStatusMessage(Warrior attacker, Warrior defender, float beginAttackerHP, float beginDefenderHP)
        {
            var builder = new StringBuilder($"{attacker.Name} (HP:{beginAttackerHP}) attacked {defender.Name} (HP:{beginDefenderHP}) -> ");
            builder.Append($"After battle {attacker.Name}'s HP is {attacker.HP}" + (attacker.Dead ? " and it's dead, " : ", "));
            builder.Append($"{defender.Name}'s HP is {defender.HP}" + (defender.Dead ? " and it's dead." : "."));
           
            return builder.ToString();
        }

        private void Game()
        {
            int round = 0;
            var random = new Random();
            while (warriors.Count != 1)
            {
                round++;

                cancellationToken.ThrowIfCancellationRequested();

                Warrior attacker = PopRandomWarrior(random);
                Warrior defender = PopRandomWarrior(random);
                var beginAttackerHP = attacker.HP;
                var beginDefenderHP = defender.HP;
                if (attacker is Swordsman)
                {
                    SwordsmanAttack(attacker, defender);
                }
                else if (attacker is Archer)
                {
                    ArcherAttack(attacker, defender);
                }
                else if (attacker is Knight)
                {
                    KnightAttack(attacker, defender);
                }

                ReduceHealthPointIfNeed(attacker);
                ReduceHealthPointIfNeed(defender);

                CheckHealthPointsAndKillIfNeed(attacker);
                CheckHealthPointsAndKillIfNeed(defender);

                IncreaseHealthPoint();

                if(!attacker.Dead) warriors.Add(attacker);
                if(!defender.Dead) warriors.Add(defender);

                string statusMsg = GenerateStatusMessage(attacker, defender, beginAttackerHP, beginDefenderHP);
                logger.Info($"Round {round}: {statusMsg}");

                if(warriors.Count == 0)
                {
                    logger.Info("Everybody died");
                    break;
                }
            }

            if(warriors.Count == 1)
            {
                logger.Info($"{warriors.ElementAt(0).Name} win!");
            }
        }

        public void Wait()
        {
            if (gameTask != null && !gameTask.IsCompleted)
            {
                gameTask.Wait();
            }
            else
            {
                logger.Warn("Game doesn't running");
            }
        }

        private Task InitGameTask(int numberOfWarriors)
        {
            tokenSource = new CancellationTokenSource();
            cancellationToken = tokenSource.Token;
            return Task.Run(() =>
            {
                logger.Info("-------------- Game Started --------------");
                cancellationToken.ThrowIfCancellationRequested();
                if(numberOfWarriors > 0)
                {
                    GenerateWarriors(numberOfWarriors);
                    Game();
                }
                else
                {
                    logger.Info("The arena is empty");
                }
                logger.Info("-------------- Game Finished --------------");
            }, tokenSource.Token);
        }

        public void Stop()
        {
            tokenSource.Cancel();
        }

        public async void StartGameAsync(int numberOfWarriors) 
        {
            if (gameTask != null)
            {
                logger.Warn("Game is running");
                return;
            }

            gameTask = InitGameTask(numberOfWarriors);

            try
            {
                await gameTask;
            }
            catch (OperationCanceledException e)
            {
                logger.Info("Game stopped");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            finally
            {
                gameTask = null;
                tokenSource.Dispose();
            }

        }
    }
}
