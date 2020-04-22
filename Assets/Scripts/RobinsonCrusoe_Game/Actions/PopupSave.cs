using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSave : MonoBehaviour
{
    public event EventHandler SaveButtonClicked;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (hasMinValue)
        {
            var total = FindObjectOfType<PopUp_Methods>().GetComponent<PopUp_Methods>().GetTotalValue();
            if (total != minValue && total != 0)
            {
                return;
            }
        }
        SaveButtonClicked?.Invoke(this, new EventArgs());
    }

    private bool hasMinValue = false;
    private int minValue = 0;
    public void SetMinValue(int min)
    {
        minValue = min;
        hasMinValue = true;
    }
}
