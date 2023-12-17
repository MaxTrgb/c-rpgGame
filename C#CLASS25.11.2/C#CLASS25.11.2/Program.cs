using C_CLASS25._11._2;
using System.Text.Json;

namespace MySpace 
{
    class Program
    {
        public static void Main(string[] args)
        {
           ConsoleKeyInfo choice1;
           ConsoleKeyInfo choice2;
           ConsoleKeyInfo loc;
           ConsoleKeyInfo move1;
           ConsoleKeyInfo move2;
           ConsoleKeyInfo menuChoice;
           bool isPlayer1Turn = true;
           int totalDamage = 0;
           int totalDamage2 = 0;
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
                    while (true)
                    {
                        Console.Clear();
                        DateTime date;
                        date = DateTime.Now;
                        Statistics statistics = new Statistics(date.ToLongDateString());

                        string currentPlayer = isPlayer1Turn ? "Player one" : "Player two";

                        Hero Player1 = ChooseHero("Player one");
                        Console.Clear();
                        Hero Player2 = ChooseHero("Player two");
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
                        int skillCounterPOne =0;
                        int skillCounterPTwo =0;

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
                                    else {

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
                                    else {
                                        if (skillCounterPTwo == 1)
                                        {
                                            Console.WriteLine($"\t\t\tSkill is on the cooldown!\n{skillCounterPTwo} move left...");
                                        }
                                        else {
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

                        break;
                    }
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
                            Console.ResetColor ();
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
            static Hero ChooseHero(string player)
                {
                    Console.WriteLine($"\n\t\t\t{player} Choose hero:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t\t\t1.Warrior");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n\t\t\t2.Mage");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t\t\t3.Archer");
                Console.ResetColor();
               
                    ConsoleKeyInfo choice = Console.ReadKey();
                    Hero playerHero = null;

                    switch (choice.KeyChar)
                    {
                        case '1':
                            playerHero = new Warrior();
                            break;
                        case '2':
                            playerHero = new Mage();
                            break;
                        case '3':
                            playerHero = new Archer();
                            break;
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                    }

                    return playerHero;
                }
            
        }
    }
}