using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards
{
    public static class EventCard_Stack
    {
        private static Stack<IEventCard> currentCardStack;
        private static Dictionary<string, IEventCard> CardReferences;

        public static void Init()
        {
            //TODO: remove later, or find a better method to init the stack 
            currentCardStack = new Stack<IEventCard>();
            CardReferences = new Dictionary<string, IEventCard>(); //Is that even needed????

            //Add all cards that are used during this game to the dictionary, so they can be loaded when needed
            CardReferences.Add("EventCard_WinterDepression", new EventCard_WinterDepression());

            //Build card stack here, maybe cards are available more than one time
            for(int i = 0; i < 12; i++)
            {
                currentCardStack.Push(new EventCard_WinterDepression());
            }
        }

        public static void Draw()
        {
            var eventCard = currentCardStack.Pop();
            var eventCardObject = new GameObject_Card();
            eventCardObject.eventCard = eventCard;
        }

        public static void Shuffle()
        {

        }

        public static void PutOnStack(IEventCard card)
        {

        }
    }
}
