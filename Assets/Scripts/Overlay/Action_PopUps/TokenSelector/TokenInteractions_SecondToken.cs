using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TokenInteractions_SecondToken : MonoBehaviour, IPointerClickHandler
{
    public GameObject PredecessorObj = null;
    public RawImage thisObj = null;

    public bool State = false;
    public GameObject selectorObj;

    private TokenInteractions_FirstToken predecessor;
    private ActionToken_Selector selector;

    // Start is called before the first frame update
    void Start()
    {
        predecessor = PredecessorObj.GetComponent<TokenInteractions_FirstToken>();

        selector = selectorObj.GetComponent<ActionToken_Selector>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!State && selector.AvailableTokens >= 1 && predecessor.State)
        {
            State = true;
            selector.AvailableTokens--;
            selector.SpendTokens++;
            thisObj.color = new Color(255, 255, 255, 255);
        }
        else if (State)
        {
            State = false;
            selector.AvailableTokens++;
            selector.SpendTokens--;
            thisObj.color = new Color(255, 255, 255, 100);
        }
    }

    public void SetStartState(bool start)
    {
        if (start)
        {
            State = true;
            thisObj.color = new Color(255, 255, 255, 255);
            return;
        }
        State = false;
        thisObj.color = new Color(255, 255, 255, 100);
    }
}
