using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    internal class ChoseHeroMenu
    {
        ChooseHero cHero = new ChooseHero();
        FightMain fightMain = new FightMain();
        private int totalDamage = 0;
        private int totalDamage2 = 0;
        private bool isPlayer1Turn = true;

        public void chooseHeroMenu()
        {
            while (true)
            {
                
                ConsoleKeyInfo loc;

                Console.Clear();
                DateTime date;
                date = DateTime.Now;
                Statistics statistics = new Statistics(date.ToLongDateString());

                string currentPlayer = isPlayer1Turn ? "Player one" : "Player two";

                Hero Player1 = cHero.chooseHero("Player one");
                Console.Clear();
                Hero Player2 = cHero.chooseHero("Player two");
                Console.Clear();

                statistics.classPlayerOne = Player1.Name;
                statistics.classPlayerTwo = Player2.Name;

                Console.WriteLine($"\n\t\t\tChoose location:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\n\t\t\t1.Arena");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\n\t\t\t2.Everest");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\n\t\t\t3.Forest");
                Console.ResetColor();

                loc = Console.ReadKey();

                if (loc.KeyChar == '1')
                {
                    Player1.Location(Hero.BattleLocation.Arena);
                    Player2.Location(Hero.BattleLocation.Arena);
                }
                else if (loc.KeyChar == '2')
                {
                    Player1.Location(Hero.BattleLocation.Everest);
                    Player2.Location(Hero.BattleLocation.Everest);
                }
                else if (loc.KeyChar == '3')
                {
                    Player1.Location(Hero.BattleLocation.Forest);
                    Player2.Location(Hero.BattleLocation.Forest);
                }
                Console.Clear();

                Console.WriteLine($"\n\nPress enter to start the game!");
                Console.ReadLine();
                Console.Clear();
                
                
                fightMain.runFight(totalDamage, totalDamage2, isPlayer1Turn, Player1, Player2, currentPlayer, statistics, date);
                           
                break;
            }
        }

    }
}
