using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_CharSettings : MonoBehaviour
{
    public Text charName;
    public Slider charTokens;

    public Character Character { get; private set; }
    private int startValue;
    private int maxValue;
    private PopUp_Methods parent;

    // Start is called before the first frame update
    void Start()
    {
        charTokens.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float arg0)
    {
        float totalValue = parent.GetTotalValue();
        float totalMaxValue = parent.GetTotalMaxValue();

        if (arg0 > maxValue //Cant spend more points than character has available
            || totalValue > totalMaxValue) //Cant spend more points than the actions costs
        {
            charTokens.value = Math.Min(arg0 - (totalValue - totalMaxValue), maxValue);
        }
    }

    internal void SetCharacter(Character key)
    {
        Character = key;
    }

    public void SetName(string charname)
    {
        charName.text = charname;
    }

    public void SetSliderValue(int value)
    {
        startValue = value;
        charTokens.value = value;

        maxValue = value + Character.CurrentNumberOfActions;
    }

    public void SetSliderMaxValue(int max)
    {
        charTokens.maxValue = max;
    }

    public void SetParent(PopUp_Methods parent)
    {
        this.parent = parent;
    }

    public float GetCurrentSliderValue()
    {
        return charTokens.value;
    }

    public int GetDifference()
    {
        return startValue - Convert.ToInt32(GetCurrentSliderValue());
    }

    public bool ValueChanged()
    {
        int current = Convert.ToInt32(GetCurrentSliderValue());
        if(current == startValue)
        {
            return false;
        }
        return true;
    }
}
