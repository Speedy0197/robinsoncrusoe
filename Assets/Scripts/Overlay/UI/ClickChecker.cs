using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChecker : MonoBehaviour
{
    public bool clickAllowed = true;

    private int openPopUps = 0;

    public void NewPopUp()
    {
        openPopUps++;
    }

    public void ClosePopUp()
    {
        openPopUps--;
    }

    private void UpdateState()
    {
        if(openPopUps > 0)
        {
            clickAllowed = false;
            return;
        }
        clickAllowed = true;
    }
}
