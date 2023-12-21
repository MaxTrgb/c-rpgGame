using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    class FightManager
    {
        private int skillCounterPOne = 0;
        private int skillCounterPTwo = 0;
        private ConsoleKeyInfo move1;
        private ConsoleKeyInfo move2;
        private bool playerWins = false;
        PalyersWins palyersWins = new PalyersWins();
        
        public void runFight(int totalDamage, int totalDamage2, bool isPlayer1Turn, Hero Player1, Hero Player2, string currentPlayer) {
            while (true)
            {
                FightPrint.printTotalDamage(totalDamage, totalDamage2);
                FightPrint.printRemainingHealth(Player1,Player2);
                FightPrint.printCurrentPlayerMove(currentPlayer);                

                move1 = Console.ReadKey();
                Console.WriteLine();

                int damage = 0;
                int attckTypeChoice = 0;

                
                totalDamage += PlayersMoves.playerOneMove(move1, damage, currentPlayer, Player1, Player2, skillCounterPOne);
                                
                
                FightPrint.printRemainingHealth(Player1, Player2);


                if (playerWins = palyersWins.whichPlayerWin(totalDamage, totalDamage2, currentPlayer, Player1, Player2, skillCounterPOne, skillCounterPTwo))
                {
                    break;
                }


                FightPrint.pressEnterContinue();
                Console.ReadLine();
                Console.Clear();
                currentPlayer = isPlayer1Turn ? "Player two" : "Player one";

                // Player 2's turn
                FightPrint.printTotalDamage(totalDamage, totalDamage2);
                FightPrint.printRemainingHealth(Player1, Player2);
                FightPrint.printCurrentPlayerMove(currentPlayer);

                move2 = Console.ReadKey();
                Console.WriteLine();

                int damage2 = 0;
                
                totalDamage2 += PlayersMoves.playerTwoMove(move2, damage2, currentPlayer, Player1, Player2, skillCounterPTwo);                              
             
                FightPrint.printRemainingHealth(Player1, Player2);


                if (playerWins = palyersWins.whichPlayerWin(totalDamage, totalDamage2, currentPlayer, Player1, Player2, skillCounterPOne, skillCounterPTwo))
                {
                    break;
                }

                FightPrint.pressEnterContinue();
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
        }
    }
}
