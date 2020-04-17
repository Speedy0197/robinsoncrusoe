using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenKeeper : MonoBehaviour
{
    public ActionContainer CurrentAction;
    public ActionType ActionType;
    public GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAction = new ActionContainer();
        CurrentAction.ActionType = ActionType;
    }
}
