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
        public static RoundSystem instance;

        private int currentRound;
        private Level.Level myLevel;

        public RoundSystem(Level.Level level)
        {
            currentRound = 1;
            myLevel = level;

            instance = this;
        }

        public void StartGame()
        {
            PhaseView.StartGame();
        }

        public void increaseRound(int i)
        {
            i += 1;

            //TODO: Check for victory conditions -> Trigger Victory event

            if(i > myLevel.GetNumberOfRounds())
            {
                //Trigger Defeat event
            }
        }

    }
}
