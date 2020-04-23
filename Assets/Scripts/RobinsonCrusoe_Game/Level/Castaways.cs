using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Generic.Dice;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Level
{
    public class Castaways : Level
    {
        public const int weatherRound = 4;
        public const int stormRound = 7;

        private bool isStackCompleted = false;

        public override bool CheckForVictory(int currentRound)
        {
            if(currentRound >= 10 &&
              InventionStorage.IsAvailable(Invention.Fire) &&
              isStackCompleted)
            {
                return true;
            }
            return false;
        }

        public override int GetNumberOfRounds()
        {
            return 12;
        }

        public override int GetStormRound()
        {
            return stormRound;
        }

        public override DiceSet GetWeatherDices(int currentRound)
        {
            DiceSet dice = new DiceSet();
            if(currentRound >= weatherRound && currentRound < stormRound)
            {
                dice.weatherDice_Normal = true;
                dice.weatherDice_Advanced = false;
                dice.environmentalDice = false;
                return dice;
            }
            else if(currentRound >= stormRound)
            {
                dice.weatherDice_Normal = true;
                dice.weatherDice_Advanced = true;
                dice.environmentalDice = true;
                return dice;
            }
            dice.weatherDice_Normal = false;
            dice.weatherDice_Advanced = false;
            dice.environmentalDice = false;
            return dice;
        }

        public override int GetWeatherRound()
        {
            return weatherRound;
        }

        public void StackOfWood_Completed()
        {
            isStackCompleted = true;
        }
    }
}
