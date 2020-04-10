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
    public Text text0;
    public Text text1;
    public Text text2;
    public Text text3;
    public RawImage image;

    private float startValue1;
    private float maxValue1;
    private float startValue2;
    private float maxValue2;
    private float startValue3;
    private float maxValue3;
    private float totalValue;
    private float totalMaxValue = 2;

    // Start is called before the first frame update
    void Start()
    {
        totalValue = 0;
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
        totalValue = arg0 + slider1.value + slider2.value;

        if (arg0 > maxValue3 || totalValue > totalMaxValue)
        {
            slider3.value = Math.Min(arg0 - (totalValue - totalMaxValue), maxValue3);
        }
    }

    private void Slider2OnValueChanged(float arg0)
    {
        totalValue = arg0 + slider1.value + slider3.value;

        if (arg0 > maxValue2 || totalValue > totalMaxValue)
        {
            slider2.value = Math.Min(arg0 - (totalValue - totalMaxValue), maxValue2);
        }
    }

    private void Slider1OnValueChanged(float arg0)
    {
        totalValue = arg0 + slider2.value + slider3.value;

        if (arg0 > maxValue1 || totalValue > totalMaxValue)
        {
            slider1.value = Math.Min(arg0 - (totalValue - totalMaxValue), maxValue1);
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
        if (sliderNr == 1) slider1.value = value;
        if (sliderNr == 2) slider2.value = value;
        if (sliderNr == 3) slider3.value = value;
    }

    public void SetText(int textNr, string text)
    {
        if (textNr == 0) text0.text = text;
        if (textNr == 1) text1.text = text;
        if (textNr == 2) text2.text = text;
        if (textNr == 3) text3.text = text;
    }
    public void SetImage(RawImage image)
    {
        this.image.texture = image.texture;
    }

    public string GetImageName()
    {
        return image.texture.name;
    }

}
