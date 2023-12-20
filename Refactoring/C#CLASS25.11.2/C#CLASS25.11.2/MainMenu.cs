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
        //private ConsoleKeyInfo choice1;
        //private ConsoleKeyInfo choice2;

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
                    Console.WriteLine("\t\t\tEnter the file name (format: HH-mm-ss):");
                    string fileName = Console.ReadLine();
                    string filePath = @$"..\..\{fileName}.json";

                    if (File.Exists(filePath))
                    {
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                        {
                            Statistics statistics = JsonSerializer.Deserialize<Statistics>(fileStream);

                            Console.WriteLine("\n\t\t\t\tStatistics");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\n\t\t\tFight Number: {fileName}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\t\t\tPlayer One Class: {statistics.classPlayerOne}");
                            Console.WriteLine($"\t\t\tPlayer Two Class: {statistics.classPlayerTwo}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\t\t\tTotal Damage Player One: {statistics.totalDamagePlayerOne}");
                            Console.WriteLine($"\t\t\tTotal Damage Player Two: {statistics.totalDamagePlayerTwo}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"\t\t\tWinner: {statistics.Winner}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"File '{fileName}.json' not found.");
                    }

                    Console.WriteLine("\n\nPress enter to go back to the main menu...");
                    Console.ReadLine();
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
