using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupAction : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        slider1.onValueChanged.AddListener(Slider1OnValueChanged);
        slider2.onValueChanged.AddListener(Slider2OnValueChanged);
        slider3.onValueChanged.AddListener(Slider3OnValueChanged);
    }

    private void Slider3OnValueChanged(float arg0)
    {
        throw new NotImplementedException();
    }

    private void Slider2OnValueChanged(float arg0)
    {
        throw new NotImplementedException();
    }

    private void Slider1OnValueChanged(float arg0)
    {
        throw new NotImplementedException();
    }

    public float GetSliderValue(int sliderNr)
    {
        if (sliderNr == 1) return slider1.value;
        if (sliderNr == 2) return slider2.value;
        if (sliderNr == 3) return slider3.value;
        return 0;
    }

}
