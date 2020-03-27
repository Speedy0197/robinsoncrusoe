using Assets.Scripts.Generic.Dice;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class RoundSystem
    {
        public static event EventHandler RoundChanged;
        public static RoundSystem instance;

        private int currentRound;
        private Level.Level myLevel;

        public RoundSystem(Level.Level level)
        {
            currentRound = 1;
            myLevel = level;

            instance = this;

            InvokeRoundChange();
        }

        public void StartGame()
        {
            PhaseView.StartGame();
        }

        public DiceSet GetWeatherDices()
        {
            return myLevel.GetWeatherDices(currentRound);
        }

        public void increaseRound()
        {
            currentRound += 1;

            //TODO: Check for victory conditions -> Trigger Victory event

            if (currentRound > myLevel.GetNumberOfRounds())
            {
                //Trigger Defeat event
            }

            InvokeRoundChange();
        }

        private void InvokeRoundChange()
        {
            string roundString = currentRound + "/" + myLevel.GetNumberOfRounds();
            RoundChanged?.Invoke(roundString, new EventArgs());
        }
    }
}
