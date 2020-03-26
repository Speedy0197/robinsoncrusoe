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

        public static string GetMoraleString()
        {
            string moraleString = string.Empty;
            if (currentMorale == MoralState.Best) moraleString = "+2 Entschlossenheit oder +1 Leben";
            if (currentMorale == MoralState.Better) moraleString = "+2 Entschlossenheit";
            if (currentMorale == MoralState.Good) moraleString = "+1 Entschlossenheit";
            if (currentMorale == MoralState.Neutral) moraleString =  "+0 Entschlossenheit";
            if (currentMorale == MoralState.Bad) moraleString = "-1 Entschlossenheit";
            if (currentMorale == MoralState.Worse) moraleString = "-2 Entschlossenheit";
            if (currentMorale == MoralState.Demoralized) moraleString = "-3 Entschlossenheit";
            return moraleString;
        }

        internal static int GetMoraleInt()
        {
            int moraleInt = 0;
            if (currentMorale == MoralState.Best) moraleInt = 2;
            if (currentMorale == MoralState.Better) moraleInt = 2;
            if (currentMorale == MoralState.Good) moraleInt = 1;
            if (currentMorale == MoralState.Neutral) moraleInt = 0;
            if (currentMorale == MoralState.Bad) moraleInt = -1;
            if (currentMorale == MoralState.Worse) moraleInt = -2;
            if (currentMorale == MoralState.Demoralized) moraleInt = -3;
            return moraleInt;
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
