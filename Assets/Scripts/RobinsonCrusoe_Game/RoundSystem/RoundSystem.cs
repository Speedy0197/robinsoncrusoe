using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class RoundSystem
    {
        private int gameRound;
        private int playerNumber;
        private int maxGameRound;

        public RoundSystem() 
        {
            //init
            gameRound = 1;
            playerNumber = 1;
            maxGameRound = 12;
            RobinsonCrusoe_Game.GameAttributes.Roof.SetStartValue(0);
            RobinsonCrusoe_Game.GameAttributes.Wall.SetStartState(0);
            RobinsonCrusoe_Game.GameAttributes.WeaponPower.SetStartValue(0);
            RobinsonCrusoe_Game.GameAttributes.Phases.SetStartValue();
            firstRound();

            for (int i = 1; i < maxGameRound-1; i++)
            {
                normalRound();
            }

            lastRound();
        }

        private void firstRound()
        {
            //TO-DO Lots
            increaseRound(gameRound);
        }

        private void normalRound()
        {
            //TO-DO Lots More
            increaseRound(gameRound);
        }

        private void lastRound()
        {
            //TO-DO if not successful -> DEFEAT
        }

        private void increaseRound(int i)
        {
            i += 1;
        }

    }   
}
