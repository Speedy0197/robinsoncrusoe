using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    private Dictionary<string, float> dictionary = null;

    public Position()
    {
        dictionary = new Dictionary<string, float>();
        foreach (var character in PartyHandler.PartySession)
        {
            dictionary.Add(character.CharacterName, 0);
        }
    }

    public Dictionary<string, float> GetDictionary()
    {
        return dictionary;
    }

    public void SetDictionary(string name, float value)
    {
        dictionary[name] = value;
    }
}