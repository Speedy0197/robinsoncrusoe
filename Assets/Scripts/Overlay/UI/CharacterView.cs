using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    public GameObject[] previews;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        foreach(var character in PartyHandler.PartySession)
        {
            previews[index].SetActive(true);
            previews[index].GetComponent<SmallCharacterView>().SetCharacter(character);
            index++;
        }
    }
}
