using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class Moralphase : IStage
    {
        public void EndStage()
        {
            //throw new NotImplementedException();
            //Change to next stage
        }

        public void InitStage()
        {
            StageHandler.ChangeStage(this);
        }

        private int ConvertMoralToValue(MoralState state)
        {
            if (state == MoralState.Demoralized) return -3;
            else if (state == MoralState.Worse) return -2;
            else if (state == MoralState.Bad) return -1;
            else if (state == MoralState.Good) return 1;
            else if (state == MoralState.Better) return 2;
            else return 0; //Neutral
        }

        public void ProcessStage()
        {
            var state = Moral.GetCurrentMoralState();

            if (RoundSystem.maxPlayerNumber == 1)
            {
                Moral.RaiseMoral();
            }

            if (state == MoralState.Best)
            {
                //TODO: handle choice between +2 and +heart
                throw new NotImplementedException();
            }
            else
            {
                var numberOfTokens = ConvertMoralToValue(state);
                var activePlayer = PlayerStorage.GetActivePlayer();
                var character = activePlayer.GetCharacter();
                character.ChangeMoralTokenValueBy(numberOfTokens);
            }

            EndStage();
        }
    }
}   
