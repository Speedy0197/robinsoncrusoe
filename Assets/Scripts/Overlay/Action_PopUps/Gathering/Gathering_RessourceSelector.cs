using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gathering_RessourceSelector : MonoBehaviour
{
    public RawImage ressource_1;
    public RawImage ressource_2;

    private bool r1_Active;
    private bool r2_Active;

    private void Start()
    {
        r1_Active = true;
        r2_Active = false;
    }

    public void ChangeSelection()
    {
        if (r1_Active)
        {
            r1_Active = false;
            ressource_1.color = new Color(255, 255, 255, 100);
            r2_Active = true;
            ressource_2.color = new Color(255, 255, 255, 255);
        }
        else
        {
            r2_Active = false;
            ressource_2.color = new Color(255, 255, 255, 100);
            r1_Active = true;
            ressource_1.color = new Color(255, 255, 255, 255);
        }
    }
}
