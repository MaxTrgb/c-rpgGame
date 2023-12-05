using C_CLASS25._11._2;
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
           bool isPlayer1Turn = true;
           int totalDamage = 0;
           int totalDamage2 = 0;


            while (true)
           {
                string currentPlayer = isPlayer1Turn ? "Player one" : "Player two";

                Hero Player1 = ChooseHero("Player one");
                Hero Player2 = ChooseHero("Player two");

                Console.WriteLine($"\nChoose location:");
                Console.WriteLine("1.Arena\n2.Everest\n3.Forest");
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

                Console.WriteLine($"\nPress enter to start the game!");
                Console.ReadLine();

                while (true)
                {
                    Console.WriteLine($"\n{currentPlayer} move:");
                    Console.WriteLine("1.Attack\n2.Defence\n3.Heal\n4.Skill");
                    move1 = Console.ReadKey();
                    Console.WriteLine();

                    int damage = 0;
                    int attckTypeChoice = 0;

                    switch (move1.KeyChar)
                    {
                        case '1':

                            damage = Player1.CalculateDamage(Player2.AttackPower, Hero.AttackType.Physical, Player2.CriticalChance);
                            damage = Player2.Defend(damage);
                            Console.WriteLine($"{currentPlayer} dealt {damage} damage.");
                            break;
                        case '2':
                            Player1.StartDefending();
                            Console.WriteLine($"{currentPlayer} started defending.");
                            break;
                        case '3':
                            Player1.Heal();
                            Console.WriteLine($"{currentPlayer} healed.");
                            break;
                        case '4':
                            Player1.Skill();
                            Console.WriteLine($"{currentPlayer} used a skill.");
                            break;
                    }
                    totalDamage += damage;

                    Console.WriteLine($"Player one remaining health: {Player1.Health}");
                    Console.WriteLine($"Player two remaining health: {Player2.Health}");

                    if (Player1.Health <= 0 || Player2.Health <= 0)
                    {
                        Console.WriteLine($"{currentPlayer} wins!");
                        Console.WriteLine($"Total damage Player one: {totalDamage} ");
                        Console.WriteLine($"Total damage Player two: {totalDamage2} ");
                        break;
                    }

                    currentPlayer = isPlayer1Turn ? "Player two" : "Player one";  

                    // Player 2's turn
                    Console.WriteLine($"\n{currentPlayer} move:");
                    Console.WriteLine("1.Attack\n2.Defence\n3.Heal\n4.Skill");
                    move2 = Console.ReadKey();
                    Console.WriteLine();

                    int damage2 = 0;

                    switch (move2.KeyChar)
                    {
                        case '1':
                            damage2 = Player2.CalculateDamage(Player1.AttackPower, Hero.AttackType.Physical, Player1.CriticalChance);
                            damage2 = Player1.Defend(damage2);
                            Console.WriteLine($"{currentPlayer} dealt {damage2} damage.");
                            break;
                        case '2':
                            Player2.StartDefending();
                            Console.WriteLine($"{currentPlayer} started defending.");
                            break;
                        case '3':
                            Player2.Heal();
                            Console.WriteLine($"{currentPlayer} healed.");
                            break;
                        case '4':
                            Player2.Skill();
                            Console.WriteLine($"{currentPlayer} used a skill.");
                            break;
                    }
                    totalDamage2 += damage2;

                    Console.WriteLine($"Player one remaining health: {Player1.Health}");
                    Console.WriteLine($"Player two remaining health: {Player2.Health}");

                    if (Player1.Health <= 0 || Player2.Health <= 0)
                    {
                        Console.WriteLine($"{currentPlayer} wins!");
                        Console.WriteLine($"Total damage Player one: {totalDamage} ");
                        Console.WriteLine($"Total damage Player two: {totalDamage2} ");

                        break;
                    }

                    currentPlayer = isPlayer1Turn ? "Player one" : "Player two";
                }



            }
            static Hero ChooseHero(string player)
            {
                Console.WriteLine($"\n{player} Choose hero:");
                Console.WriteLine("1.Warrior\n2.Mage\n3.Archer");
                ConsoleKeyInfo choice = Console.ReadKey();
                Hero playerHero = null;

                switch (choice.KeyChar)
                {
                    case '1':
                        playerHero = new Warrior("Aragorn");
                        break;
                    case '2':
                        playerHero = new Mage("Gandalf");
                        break;
                    case '3':
                        playerHero = new Archer("Legolas");
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