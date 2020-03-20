using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moralephase : MonoBehaviour
{
    private PhaseView myView;

    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponent<PhaseView>();
        myView.currentPhaseChanged += OnPhaseChange;
    }

    private void OnPhaseChange(object sender, System.EventArgs e)
    {
        if(myView.currentPhase == E_Phase.Morale)
        {
            //Open Popup
            //Get Current Morale Value
            //if value is best -> Let player choose
            //wait for player confirmation
            //Close Popup
            //apply changes to active character
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
