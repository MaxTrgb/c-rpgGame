using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    
    class PalyersWins
    {
        private static DateTime date = DateTime.Now;
        Statistics statistics = new Statistics(date.ToLongDateString());

        public bool whichPlayerWin(int totalDamage, int totalDamage2, string currentPlayer, Hero Player1, Hero Player2, int skillCounterPOne, int skillCounterPTwo) {

            if (Player1.Health <= 0 || Player2.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\t\t\t{currentPlayer} wins!");
                Console.ResetColor();

                FightPrint.printTotalDamage(totalDamage, totalDamage2);

                FightPrint.pressEnterMainMenu();
                Console.ReadLine();

                skillCounterPOne = 0;
                skillCounterPTwo = 0;

                statistics.Winner = currentPlayer;
                statistics.classPlayerOne = Player1.Name;
                statistics.classPlayerTwo = Player2.Name;
                statistics.totalDamagePlayerOne = totalDamage;
                statistics.totalDamagePlayerTwo = totalDamage2;

                string path = date.ToLongTimeString();
                path = path.Replace(":", "-");

                using (FileStream? file = new FileStream(@$"..\..\{path}.json", FileMode.Create))
                {
                    JsonSerializer.Serialize<Statistics>(file, statistics);
                    Console.WriteLine(file.Name);
                }
                return true;
            }
            return false;
        }

    }
}
