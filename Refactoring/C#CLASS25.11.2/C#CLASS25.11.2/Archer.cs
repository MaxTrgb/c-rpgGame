using C_CLASS25._11._2;

class Archer : Hero
{
    public Archer()
    {
        Name = "Archer";
        Health = 1500;
        AttackPower = 175;
        ResistanceToPhysical = 10;
        ResistanceToMagical = 10;
        CriticalChance = 15;
        DodgeChance = 10;
        IsDefending = false;
    }

    public override void Heal()
    {
        Health += 65;
    }

    public override int Skill(int damage)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nTriple Strike!");
        Console.ResetColor();

        return damage *= 3;
    }
    public override void Location(BattleLocation location)
    {
        switch (location)
        {
            case BattleLocation.Arena: 

                {
                    DodgeChance -= 3;
                    break;
                }
            case BattleLocation.Everest:
                {
                    AttackPower -= 25;
                    break;
                }
            case BattleLocation.Forest:
                {
                    DodgeChance += 3;
                    break;
                }
        }
    }
}
