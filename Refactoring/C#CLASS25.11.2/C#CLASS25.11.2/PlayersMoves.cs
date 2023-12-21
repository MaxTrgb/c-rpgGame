using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace C_CLASS25._11._2
{
    static class PlayersMoves
    {
        public static int playerOneMove(ConsoleKeyInfo move1, int damage, string currentPlayer, Hero Player1, Hero Player2, int skillCounterPOne)
        {

            switch (move1.KeyChar)
            {
                case '1':

                    damage = Player1.CalculateDamage(Player2.AttackPower, Hero.AttackType.Physical, Player1.CriticalChance, Player1.Name, move1);
                    damage = Player2.Defend(damage);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"\n{currentPlayer} dealt {damage} damage.");
                    Console.ResetColor();
                    return damage;
                    break;
                case '2':
                    Player1.StartDefending();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{currentPlayer} started defending.");
                    Console.ResetColor();
                    return damage;
                    break;
                case '3':
                    Player1.Heal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{currentPlayer} healed.");
                    Console.ResetColor();
                    return damage;
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
                        return damage;

                    }
                    else
                    {
                        FightPrint.printSkillCdOne(skillCounterPOne);
                        return damage;
                    }
                    return damage;
                    break;
            }
            return damage;
        }
        public static int playerTwoMove(ConsoleKeyInfo move2, int damage2, string currentPlayer, Hero Player1, Hero Player2, int skillCounterPTwo)
        {
            switch (move2.KeyChar)
            {
                case '1':
                    damage2 = Player2.CalculateDamage(Player1.AttackPower, Hero.AttackType.Physical, Player2.CriticalChance, Player2.Name, move2);
                    damage2 = Player1.Defend(damage2);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"\n{currentPlayer} dealt {damage2} damage.");
                    Console.ResetColor();
                    return damage2;
                    break;
                case '2':
                    Player2.StartDefending();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{currentPlayer} started defending.");
                    Console.ResetColor();
                    return damage2;

                    break;
                case '3':
                    Player2.Heal();
                    Console.WriteLine($"{currentPlayer} healed.");
                    return damage2;

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
                        return damage2;

                    }
                    else
                    {
                        FightPrint.printSkillCdTwo(skillCounterPTwo);
                        return damage2;

                    }
                    return damage2;

                    break;
            }
            return damage2;

        }
    }
}
