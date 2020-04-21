using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Player;
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

        public int currentRound { get; private set; }
        public bool started { get; private set; }
        private Level.Level myLevel;

        public RoundSystem(Level.Level level)
        {
            currentRound = 1;
            myLevel = level;
            started = false;

            instance = this;

            InvokeRoundChange();
        }

        public void StartGame()
        {
            started = true;
            PhaseView.StartGame();
        }

        public DiceSet GetWeatherDices()
        {
            return myLevel.GetWeatherDices(currentRound);
        }

        public void increaseRound()
        {
            currentRound += 1;
            PartyActions.SetNextActiveCharacter();

            //TODO: Check for victory conditions -> Trigger Victory event
            if (myLevel.CheckForVictory(currentRound))
            {
                EndGame.Victory();
            }

            if (currentRound > myLevel.GetNumberOfRounds())
            {
                EndGame.Defeat();
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
