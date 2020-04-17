using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TokenInteractions_FirstToken : MonoBehaviour, IPointerClickHandler
{
    public GameObject FollowerObj = null;
    public RawImage thisObj = null;

    public bool State = false;
    public GameObject selectorObj;

    private TokenInteractions_SecondToken follower;
    private ActionToken_Selector selector;
    // Start is called before the first frame update
    void Start()
    {
        follower = FollowerObj.GetComponent<TokenInteractions_SecondToken>();

        selector = selectorObj.GetComponent<ActionToken_Selector>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!State && selector.AvailableTokens >= 1)
        {
            State = true;
            selector.AvailableTokens--;
            selector.SpendTokens++;
            thisObj.color = new Color(255, 255, 255, 255);
        }
        else if (State && !follower.State)
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
