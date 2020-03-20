using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class Actionphase : IStage
    {
        public static event EventHandler InitActionPhase;
        public static event EventHandler EndActionPhase;
        

        public void EndStage()
        {
            EndActionPhase?.Invoke(this, new EventArgs());
        }

        public void InitStage()
        {
            Action action = new Action();
            InitActionPhase?.Invoke(action, new EventArgs());
            StageHandler.ChangeStage(Stage.Action);
        }

        public void ProcessStage()
        {
            //throw new NotImplementedException();
        }
    }
}
