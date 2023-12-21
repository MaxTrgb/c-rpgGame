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
             
        FightManager fightManager  = new FightManager();
        
        public void runFight(int totalDamage, int totalDamage2, bool isPlayer1Turn, Hero Player1, Hero Player2, string currentPlayer)
        {
           fightManager.runFight(totalDamage, totalDamage2, isPlayer1Turn, Player1, Player2, currentPlayer);
        }
    }
}
