using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    internal class MainMenu
    {
        ChoseHeroMenu chooseHeros = new ChoseHeroMenu();
       
        public void runMenu()
        {
            ConsoleKeyInfo menuChoice;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tWelcome to The Ancient Arena!");
                Console.ResetColor();

                Console.WriteLine("\n\t\t\t1 --- Choose Your Hero!\n\t\t\t2 --- Statistics\n\t\t\t3 --- Exit");
                menuChoice = Console.ReadKey();

                if (menuChoice.KeyChar == '1')
                {
                    chooseHeros.chooseHeroMenu();
                }
                else if (menuChoice.KeyChar == '2')
                {
                    StatisticsManager.runStatistics();
                }

                else if (menuChoice.KeyChar == '3')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                }

            }
            

        }
    }
}
