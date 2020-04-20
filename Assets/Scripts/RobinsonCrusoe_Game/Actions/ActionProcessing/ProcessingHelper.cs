using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing
{
    public static class ProcessingHelper
    { 
        public static int CalculateAmountOfActions(Dictionary<Characters.Character, int> dictionary)
        {
            int actions = 0;
            foreach (var kvp in dictionary)
            {
                actions += Convert.ToInt32(kvp.Value);
            }
            return actions;
        }

        /// <summary>
        /// !!! EXPERIMENTAL AND WRONG !!!
        /// Gets one of the characters that spend an action point during this turn, only works for one player games.
        /// This should be part of the <see cref="Position"/> object.
        /// </summary>
        /// <returns></returns>
        public static Characters.Character GetExecutingCharacter(Dictionary<string, float> dictionary)
        {
            return Player.PartyActions.GetActiveCharacter();
        }
    }
}
