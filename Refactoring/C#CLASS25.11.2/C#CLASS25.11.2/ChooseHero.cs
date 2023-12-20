using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    internal class ChooseHero
    {
        public Hero chooseHero(string player)
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
