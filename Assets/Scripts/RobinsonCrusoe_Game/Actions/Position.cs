using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    private Dictionary<string, float> dictionary = null;
    private Dictionary<string, dynamic> dictionary2 = null;

    public Position()
    {
        dictionary = new Dictionary<string, float>();
        foreach (var character in PartyHandler.PartySession)
        {
            dictionary.Add(character.CharacterName, 0);
        }
        
        dictionary2 = new Dictionary<string, dynamic>();
        foreach (var character in PartyHandler.PartySession)
        {
            dynamic d1 = new System.Dynamic.ExpandoObject();
            dictionary2[character.CharacterName] = d1;
            dictionary2[character.CharacterName].food = 0;
            dictionary2[character.CharacterName].wood = 0;
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

    public Dictionary<string, dynamic> GetCollectData()
    {
        return dictionary2;
    }

    public void SetCollectData(string name, string collectType, float value)
    {
        if (collectType == "Food") dictionary2[name].food = value;
        if (collectType == "Wood") dictionary2[name].wood = value;
    }
}