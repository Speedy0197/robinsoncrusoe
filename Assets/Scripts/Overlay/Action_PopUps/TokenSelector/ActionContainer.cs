﻿using Assets.Scripts.RobinsonCrusoe_Game.Characters;
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
        public Character ExecutingCharacter { get; set; }
        public MonoBehaviour ReferingObject { get; set; }
        public ActionType ActionType { get; set; }

        public ActionContainer()
        {
            CharacterTokensSpend = new Dictionary<Character, int>();
            foreach(var c in Player.PartyHandler.PartySession)
            {
                AddParameterSet(c, 0);
            }
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
    }
}
