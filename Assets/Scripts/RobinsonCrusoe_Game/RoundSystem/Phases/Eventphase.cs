using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventphase : MonoBehaviour
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
        if(myView.currentPhase == E_Phase.Event)
        {
            //Draw Event Card
            //Show Card in Popup
            //Wait for player confirmation
            //Close popUp
            //Execute Immediate Effekt
            //IF card is not "real" event card -> Draw again
            //Move Card onto threat stack
        }
    }
}
