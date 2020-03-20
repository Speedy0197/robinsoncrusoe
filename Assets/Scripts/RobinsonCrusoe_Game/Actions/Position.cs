using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    private Dictionary<string, int> dictionary = null;

    public Position()
    {
        dictionary = new Dictionary<string, int>();
        foreach (var character in PartyHandler.PartySession)
        {
            dictionary.Add(character.CharacterName, 0);
        }
    }

    public Dictionary<string, int> GetDictionary()
    {
        return dictionary;
    }
}