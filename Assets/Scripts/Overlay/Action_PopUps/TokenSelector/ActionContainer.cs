using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Overlay.Action_PopUps.TokenSelector
{
    public class ActionContainer
    {
        public Dictionary<Character, int> CharacterTokensSpend { get; private set; }
        public MonoBehaviour ReferingObject { get; set; }
        public ActionType ActionType { get; set; }
        public RessourceType CollectRessource { get; set; }
        public int ActionCosts { get; set; }
        public bool HasStoredAction { get; set; } = false;

        public ActionContainer(int actionCosts)
        {
            CharacterTokensSpend = new Dictionary<Character, int>();
            foreach(var c in Player.PartyHandler.PartySession)
            {
                AddParameterSet(c, 0);
            }

            ActionCosts = actionCosts;
        }

        public void SetValue(Character character, int spendTokens)
        {
            CharacterTokensSpend[character] = spendTokens;
        }

        private void AddParameterSet(Character c, int tokensSpend)
        {
            CharacterTokensSpend.Add(c, tokensSpend);
        }

        public int GetValue(Character c)
        {
            return CharacterTokensSpend[c];
        }

        public int GetNumberOfTokens()
        {
            int tokens = 0;
            foreach(var kvp in CharacterTokensSpend)
            {
                tokens += kvp.Value;
            }
            return tokens;
        }

        public Character GetExecutingCharacter()
        {
            foreach(var kvp in CharacterTokensSpend)
            {
                if(kvp.Value == 1)
                {
                    return kvp.Key;
                }
                else if(kvp.Value == 2)
                {
                    return kvp.Key;
                }
            }
            return null;
        }
    }
}
