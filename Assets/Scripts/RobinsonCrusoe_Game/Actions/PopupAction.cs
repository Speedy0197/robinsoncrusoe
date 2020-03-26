using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Player;

public class PopupAction : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    private float startValue1;
    private float maxValue1;
    private float startValue2;
    private float maxValue2;
    private float startValue3;
    private float maxValue3;

    // Start is called before the first frame update
    void Start()
    {
        startValue1 = slider1.value;
        maxValue1 = PartyHandler.PartySession[0].CurrentNumberOfActions + startValue1;

        startValue2 = slider2.value;
        maxValue2 = PartyHandler.PartySession[1].CurrentNumberOfActions + startValue2;

        startValue3 = slider3.value;
        maxValue3 = PartyHandler.PartySession[2].CurrentNumberOfActions + startValue3;

        slider1.onValueChanged.AddListener(Slider1OnValueChanged);
        slider2.onValueChanged.AddListener(Slider2OnValueChanged);
        slider3.onValueChanged.AddListener(Slider3OnValueChanged);
    }

    private void Slider3OnValueChanged(float arg0)
    {
        if (arg0 > maxValue3)
        {
            slider3.value = maxValue3;
        }
    }

    private void Slider2OnValueChanged(float arg0)
    {
        if (arg0 > maxValue2)
        {
            slider2.value = maxValue2;
        }
    }

    private void Slider1OnValueChanged(float arg0)
    {
        if (arg0 > maxValue1)
        {
            slider1.value = maxValue1;
        }
    }

    public float GetSliderValue(int sliderNr)
    {
        if (sliderNr == 1) return slider1.value;
        if (sliderNr == 2) return slider2.value;
        if (sliderNr == 3) return slider3.value;
        return 0;
    }

    public float GetStartSliderValue(int sliderNr)
    {
        if (sliderNr == 1) return startValue1;
        if (sliderNr == 2) return startValue2;
        if (sliderNr == 3) return startValue3;
        return 0;
    }

    public void SetSliderValue(int sliderNr, float value)
    {
        if (sliderNr == 1)  slider1.value = value;
        if (sliderNr == 2)  slider2.value = value;
        if (sliderNr == 3)  slider3.value = value;
    }

}
