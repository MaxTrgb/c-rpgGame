using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    [Serializable]
    public class Statistics
    {
        public string fightNum { get; set; }

        public string classPlayerOne{ get; set; }
        public string classPlayerTwo{ get; set; }
        public int totalDamagePlayerOne { get; set; }
        public int totalDamagePlayerTwo { get; set; }
        public string Winner { get; set; }

        public Statistics(string fightNum) {
            fightNum = fightNum;
        }

    }
}
