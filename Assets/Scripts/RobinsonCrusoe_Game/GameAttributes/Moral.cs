using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Moral
    {
        public static event EventHandler MoralStateChanged;
        private static MoralState currentMorale = GetStartState();

        public static MoralState GetStartState()
        {
            return MoralState.Neutral;
        }
        private static void Character_RaiseMoral(object sender, EventArgs e)
        {
            RaiseMoral();
        }

        public static MoralState GetCurrentMoralState()
        {
            return currentMorale;
        }

        public static void RaiseMoral()
        {
            MoralState newMoralState = MoralState.Neutral;
            if (currentMorale == MoralState.Demoralized) newMoralState = MoralState.Worse;
            if (currentMorale == MoralState.Worse) newMoralState = MoralState.Bad;
            if (currentMorale == MoralState.Bad) newMoralState = MoralState.Neutral;
            if (currentMorale == MoralState.Neutral) newMoralState = MoralState.Good;
            if (currentMorale == MoralState.Good) newMoralState = MoralState.Better;
            if (currentMorale == MoralState.Better) newMoralState = MoralState.Best;
            if (currentMorale == MoralState.Best) newMoralState = MoralState.Best;

            currentMorale = newMoralState;
            MoralStateChanged?.Invoke(currentMorale, new EventArgs());
        }

        public static void SetStartValue()
        {
            currentMorale = MoralState.Neutral;
            MoralStateChanged?.Invoke(currentMorale, new EventArgs());
        }

        private static void Character_LowerMoral(object sender, EventArgs e)
        {
            LowerMoral();
        }

        public static void LowerMoral()
        {
            MoralState newMoralState = MoralState.Neutral;
            if (currentMorale == MoralState.Best) newMoralState = MoralState.Better;
            if (currentMorale == MoralState.Better) newMoralState = MoralState.Good;
            if (currentMorale == MoralState.Good) newMoralState = MoralState.Neutral;
            if (currentMorale == MoralState.Neutral) newMoralState = MoralState.Bad;
            if (currentMorale == MoralState.Bad) newMoralState = MoralState.Worse;
            if (currentMorale == MoralState.Worse) newMoralState = MoralState.Demoralized;
            if (currentMorale == MoralState.Demoralized) newMoralState = MoralState.Demoralized;

            currentMorale = newMoralState;
            MoralStateChanged?.Invoke(currentMorale, new EventArgs());
        }
    }

    public enum MoralState
    {
        Demoralized,
        Worse,
        Bad,
        Neutral,
        Good,
        Better,
        Best
    }
}
