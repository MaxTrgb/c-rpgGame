using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    static class FightPrint
    {
        public static void printTotalDamage(int totalDamage, int totalDamage2) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nTotal damage Player one: {totalDamage} ");
            Console.WriteLine($"Total damage Player two: {totalDamage2} ");
            Console.ResetColor();
        }
        public static void printRemainingHealth(Hero Player1, Hero Player2) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Player one remaining health: {Player1.Health}");
            Console.WriteLine($"Player two remaining health: {Player2.Health}");
            Console.ResetColor();
        }
        public static void printCurrentPlayerMove(string currentPlayer) {
            Console.WriteLine($"\n\t\t\t{currentPlayer} move:");
            Console.WriteLine("\t\t\t1.Attack\n\t\t\t2.Defence\n\t\t\t3.Heal\n\t\t\t4.Skill");
        }
        public static void pressEnterMainMenu()
        {
            Console.WriteLine("\n\nPress enter to return to the main menu...");
        }
        public static void pressEnterContinue() {
            Console.WriteLine("\n\nPress enter to continue...");

        }
        public static void printSkillCdOne(int skillCounterPOne) {
            if (skillCounterPOne == 1)
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPOne} move left...");
            }
            else
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPOne} moves left...");

            }
        }
        public static void printSkillCdTwo(int skillCounterPTwo)
        {
            if (skillCounterPTwo == 1)
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPTwo} move left...");
            }
            else
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPTwo} moves left...");

            }
        }
    }
}
