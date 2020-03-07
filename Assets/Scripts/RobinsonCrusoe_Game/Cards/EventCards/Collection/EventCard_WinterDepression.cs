using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_WinterDepression : IEventCard
    {
        public void ExecuteActiveThreat()
        {
            Moral.LowerMoral();
        }

        public void ExecuteCompletionEvent()
        {
            var player = Player.PlayerStorage.GetActivePlayer();
            player.GetCharacter().ChangeMoralTokenValueBy(1);
        }

        public void ExecuteFutureThreat()
        {
            foreach(Player.Player player in Player.PlayerStorage.allPlayers)
            {
                if(player != null)
                {
                    player.GetCharacter().ChangeMoralTokenValueBy(-1);
                }
            }
        }

        public int GetMaterialNumber()
        {
            return 4;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.None;
        }

        public bool IsCardTypeBook()
        {
            return false;
        }

        public override string ToString()
        {
            return "WinterDepression;" + GetMaterialNumber();
        }
    }
}
