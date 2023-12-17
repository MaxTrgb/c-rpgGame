using C_CLASS25._11._2;
using MySpace;
using static System.Net.Mime.MediaTypeNames;

class Warrior : Hero
{
    public Warrior()
    {
        Name = "Warrior";
        Health = 2000;
        AttackPower = 150;
        ResistanceToPhysical = 15;
        ResistanceToMagical = 5;
        CriticalChance = 5;
        DodgeChance = 1;
        IsDefending = false;
    }
    Random random = new Random();
    public override void Heal()
    {
        Health += 50;
    }
    public override int Skill(int damage)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nBash!");
        Console.ResetColor();

        return damage += 100;

    }
    public override void Location(BattleLocation location)
    {
        switch (location)
        {
            case BattleLocation.Arena:

                {
                    ResistanceToPhysical += 2;
                    ResistanceToMagical += 2;
                    break;
                }
            case BattleLocation.Everest:
                {
                    ResistanceToPhysical -= 2;
                    ResistanceToMagical -= 2;
                    break;
                }
            case BattleLocation.Forest:
                {
                    AttackPower -= 25;
                    break;
                }
        }
    }

}