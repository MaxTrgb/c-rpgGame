using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    static class StatisticsManager
    {
        public static void runStatistics() {
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
    }
}
