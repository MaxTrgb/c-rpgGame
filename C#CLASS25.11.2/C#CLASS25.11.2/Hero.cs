    using MySpace;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace C_CLASS25._11._2
    {
        abstract class Hero
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int AttackPower { get; set; }
            public int ResistanceToPhysical { get; set; }
            public int ResistanceToMagical { get; set; }
            public int CriticalChance { get; set; }
            public int DodgeChance { get; set; }
            public bool IsDefending { get; set; }
            public enum AttackType
            {
                Physical,
                Magical 
            }
            Random random = new Random();
            public enum BattleLocation
            {
                Arena,
                Everest,
                Forest
            }
            public int CalculateDamage(int enemyAttackPower, AttackType enemyAttackType, int enemyCriticalChance)
            {
                double damageMultiplier = 1.0;

                if (enemyAttackType == AttackType.Physical)
                {
                    damageMultiplier -= ResistanceToPhysical / 100.0;
                }
                else
                {
                    damageMultiplier -= ResistanceToMagical / 100.0;
                }

                if (random.Next(1, 101) <= enemyCriticalChance)
                {
                    damageMultiplier *= 2;
                }

                return (int)(AttackPower * damageMultiplier); 
            }
            public int Defend(int damage)
            {
                if (IsDefending)
                {
                    damage -= 50;
                    if (damage < 0) damage = 0;

                    IsDefending = false;
                }

                Health -= damage;
                return damage;
            }


            public abstract void Location(BattleLocation location);
        
            public abstract void Skill();

            public abstract void Heal();

            public void StartDefending()
            {
                IsDefending = true;
            }

            public void StopDefending()
            {
                IsDefending = false;
            }

        }

    }
