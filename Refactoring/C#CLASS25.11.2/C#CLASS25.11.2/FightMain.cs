using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    
    internal class FightMain
    {
       
        private int skillCounterPOne = 0;
        private int skillCounterPTwo = 0;
        private ConsoleKeyInfo move1;
        private ConsoleKeyInfo move2;

        public void runFight(int totalDamage, int totalDamage2, bool isPlayer1Turn, Hero Player1, Hero Player2, string currentPlayer, Statistics statistics, DateTime date)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nTotal damage Player one: {totalDamage} ");
                Console.WriteLine($"Total damage Player two: {totalDamage2} ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Player one remaining health: {Player1.Health}");
                Console.WriteLine($"Player two remaining health: {Player2.Health}");
                Console.ResetColor();

                Console.WriteLine($"\n\t\t\t{currentPlayer} move:");
                Console.WriteLine("\t\t\t1.Attack\n\t\t\t2.Defence\n\t\t\t3.Heal\n\t\t\t4.Skill");
                move1 = Console.ReadKey();
                Console.WriteLine();

                int damage = 0;
                int attckTypeChoice = 0;


                switch (move1.KeyChar)
                {
                    case '1':

                        damage = Player1.CalculateDamage(Player2.AttackPower, Hero.AttackType.Physical, Player1.CriticalChance, Player1.Name, move1);
                        damage = Player2.Defend(damage);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n{currentPlayer} dealt {damage} damage.");
                        Console.ResetColor();

                        break;
                    case '2':
                        Player1.StartDefending();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{currentPlayer} started defending.");
                        Console.ResetColor();

                        break;
                    case '3':
                        Player1.Heal();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{currentPlayer} healed.");
                        Console.ResetColor();

                        break;
                    case '4':
                        if (skillCounterPOne == 0)
                        {
                            damage = Player1.CalculateDamage(Player2.AttackPower, Hero.AttackType.Physical, Player1.CriticalChance, Player1.Name, move1);
                            damage = Player1.Skill(damage);
                            damage = Player2.Defend(damage);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{currentPlayer} dealt {damage} damage.");
                            Console.ResetColor();
                            skillCounterPOne = 3;

                        }
                        else
                        {

                            if (skillCounterPOne == 1)
                            {
                                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPOne} move left...");
                            }
                            else
                            {
                                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPOne} moves left...");

                            }

                        }
                        break;

                }
                totalDamage += damage;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nPlayer one remaining health: {Player1.Health}");
                Console.WriteLine($"Player two remaining health: {Player2.Health}");
                Console.ResetColor();

                if (Player1.Health <= 0 || Player2.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\t\t\t{currentPlayer} wins!");
                    Console.ResetColor();

                    statistics.Winner = currentPlayer;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Total damage Player one: {totalDamage} ");
                    Console.WriteLine($"Total damage Player two: {totalDamage2} ");
                    Console.ResetColor();

                    Console.WriteLine("\n\nPress enter to return to the main menu...");
                    Console.ReadLine();
                    break;
                }
                Console.WriteLine("\n\nPress enter to continue...");
                Console.ReadLine();
                Console.Clear();
                currentPlayer = isPlayer1Turn ? "Player two" : "Player one";

                // Player 2's turn
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nTotal damage Player one: {totalDamage} ");
                Console.WriteLine($"Total damage Player two: {totalDamage2} ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Player one remaining health: {Player1.Health}");
                Console.WriteLine($"Player two remaining health: {Player2.Health}");
                Console.ResetColor();

                Console.WriteLine($"\n\t\t\t{currentPlayer} move:");
                Console.WriteLine("\t\t\t1.Attack\n\t\t\t2.Defence\n\t\t\t3.Heal\n\t\t\t4.Skill");
                move2 = Console.ReadKey();
                Console.WriteLine();

                int damage2 = 0;


                switch (move2.KeyChar)
                {
                    case '1':
                        damage2 = Player2.CalculateDamage(Player1.AttackPower, Hero.AttackType.Physical, Player2.CriticalChance, Player2.Name, move2);
                        damage2 = Player1.Defend(damage2);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n{currentPlayer} dealt {damage2} damage.");
                        Console.ResetColor();

                        break;
                    case '2':
                        Player2.StartDefending();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{currentPlayer} started defending.");
                        Console.ResetColor();

                        break;
                    case '3':
                        Player2.Heal();
                        Console.WriteLine($"{currentPlayer} healed.");
                        break;
                    case '4':
                        if (skillCounterPTwo == 0)
                        {
                            damage2 = Player2.CalculateDamage(Player1.AttackPower, Hero.AttackType.Physical, Player2.CriticalChance, Player2.Name, move2);
                            damage2 = Player2.Skill(damage2);
                            damage2 = Player1.Defend(damage2);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{currentPlayer} dealt {damage2} damage.");
                            Console.ResetColor();
                            skillCounterPTwo = 3;
                        }
                        else
                        {
                            if (skillCounterPTwo == 1)
                            {
                                Console.WriteLine($"\t\t\tSkill is on the cooldown!\n{skillCounterPTwo} move left...");
                            }
                            else
                            {
                                Console.WriteLine($"\t\t\tSkill is on the cooldown!\n{skillCounterPTwo} moves left...");

                            }
                        }
                        break;
                }
                totalDamage2 += damage2;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nPlayer one remaining health: {Player1.Health}");
                Console.WriteLine($"Player two remaining health: {Player2.Health}");
                Console.ResetColor();


                if (Player1.Health <= 0 || Player2.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\t\t\t{currentPlayer} wins!");
                    Console.ResetColor();
                    statistics.Winner = currentPlayer;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Total damage Player one: {totalDamage} ");
                    Console.WriteLine($"Total damage Player two: {totalDamage2} ");
                    Console.ResetColor();
                    Console.WriteLine("\nPress enter to return to the main menu...");
                    Console.ReadLine();

                    break;
                }
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                Console.Clear();
                currentPlayer = isPlayer1Turn ? "Player one" : "Player two";

                if (skillCounterPOne > 0)
                {
                    skillCounterPOne--;
                }
                if (skillCounterPTwo > 0)
                {
                    skillCounterPTwo--;
                }
                statistics.totalDamagePlayerOne = totalDamage;
                statistics.totalDamagePlayerTwo = totalDamage2;
                string path = date.ToLongTimeString();
                path = path.Replace(":", "-");
                using (FileStream? file = new FileStream(@$"..\..\{path}.json", FileMode.Create))
                {
                    JsonSerializer.Serialize<Statistics>(file, statistics);
                    Console.WriteLine(file.Name);
                }

            }
        }
    }
}
