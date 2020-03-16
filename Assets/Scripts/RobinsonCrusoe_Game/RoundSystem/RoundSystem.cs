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
    public static class RoundSystem
    {
        private static int gameRound;
        public static int maxPlayerNumber;
        private static int maxGameRound;

        public static void init() 
        {
            //init
            gameRound = 1;
            maxPlayerNumber = 1;
            maxGameRound = 12;
            RobinsonCrusoe_Game.GameAttributes.Roof.SetStartValue(0);
            RobinsonCrusoe_Game.GameAttributes.Wall.SetStartState(0);
            RobinsonCrusoe_Game.GameAttributes.WeaponPower.SetStartValue(0);
            RobinsonCrusoe_Game.GameAttributes.Phases.SetStartValue();

            Moralphase moralphase = new Moralphase();
            Productionphase productionphase = new Productionphase();

            firstRound(moralphase, productionphase);


            for (int i = 1; i < maxGameRound-1; i++)
            {
                normalRound();
            }

            lastRound();
        }

        private static void firstRound(Moralphase moralphase, Productionphase productionphase)
        {
            //Skip EventPhase in first round
            
            Phases.NextPhase();

            
            moralphase.InitStage();
            moralphase.ProcessStage();
            moralphase.EndStage();
            
            productionphase.InitStage();
            productionphase.ProcessStage();

            Actionphase actionphase = new Actionphase();
            actionphase.InitStage();
            actionphase.ProcessStage();
            //actionphase.EndStage();



            increaseRound(gameRound);
        }

        private static void normalRound()
        {
            //TO-DO Lots More
            increaseRound(gameRound);
        }

        private static void lastRound()
        {
            //TO-DO if not successful -> DEFEAT
        }

        private static void increaseRound(int i)
        {
            i += 1;
        }

    }

    public class ButtonHandler : MonoBehaviour
    {
        public static event EventHandler Btn_ChangeStageOnClicked;
        public void Btn_ChangeStageOnClick()
        {
            Btn_ChangeStageOnClicked?.Invoke(this, new EventArgs());
        }
 

    }

}
