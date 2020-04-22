using Assets.Scripts.Generic.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Level
{
    public abstract class Level
    {
        public abstract int GetNumberOfRounds();
        public abstract DiceSet GetWeatherDices(int currentRound);

        public abstract bool CheckForVictory(int currentRound);
        public abstract int GetWeatherRound();
        public abstract int GetStormRound();
    }
}
