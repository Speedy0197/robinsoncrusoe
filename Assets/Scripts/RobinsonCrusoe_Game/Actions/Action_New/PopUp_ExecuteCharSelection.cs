using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_ExecuteCharSelection : MonoBehaviour
{
    public Dropdown dropdown;

    private bool isEmpty = true;
    private Dictionary<Character, Dropdown.OptionData> data;

    private void Start()
    {
        data = new Dictionary<Character, Dropdown.OptionData>();
    }
    public void AddOption(Character c)
    {
        data.Add(c, new Dropdown.OptionData(c.CharacterName));

        dropdown.options.Add(data[c]);

        if (isEmpty)
        {
            isEmpty = false;
            //change current selection
        }
    }

    public void RemoveOption(Character c)
    {
        dropdown.options.Remove(data[c]);
        data.Remove(c);
    }

    public Character GetCurrentSelection()
    {
        return null;
    } 


}
