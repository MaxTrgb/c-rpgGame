using C_CLASS25._11._2;

class Mage : Hero
{
    public Mage(string name)
    {
        Name = name;
        Health = 1000;
        AttackPower = 250;
        ResistanceToPhysical = 5;
        ResistanceToMagical = 15;
        CriticalChance = 10;
        DodgeChance = 5;
        IsDefending = false;
    }
    public override void Heal()
    {
        Health += 80;
    }

    public override void Skill()
    {
        CriticalChance += 10;
    }
    public override void Location(BattleLocation location)
    {
        switch (location)
        {
            case BattleLocation.Arena:

                {
                   CriticalChance -= 5;
                    break;
                }
            case BattleLocation.Everest:
                {
                   AttackPower += 25;
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
