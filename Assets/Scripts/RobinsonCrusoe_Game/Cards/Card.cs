using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards
{
    public abstract class Card
    {   
        public abstract bool IsCardTypeBook();
        public abstract string GetQuestionMarkColour();
        public abstract string GetActiveThreat();
        public abstract string GetFutureThreat();
        public abstract void RemoveCard();
                     
        public abstract event EventHandler HealthLoss;
        public abstract event EventHandler PreRaiseMoral;
        public abstract event EventHandler RaiseMoral;
        public abstract event EventHandler PreLowerMoral;
        public abstract event EventHandler LowerMoral;
        public abstract event EventHandler NoMoralChange;
    }
}
