using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventphase : MonoBehaviour
{
    public GameObject cardShow_Prefab;
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
            var eventDeck = FindObjectOfType<EventCard_Deck>();
            var card = eventDeck.Draw();

            //Show Card in Popup
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            var instance = Instantiate(cardShow_Prefab, ui.transform);
            var show = instance.GetComponent<PopUp_Card_Show>();
            show.SetCard(card);
        }
    }

    public void DrawAgain()
    {
        //Draw Event Card
        var eventDeck = FindObjectOfType<EventCard_Deck>();
        var card = eventDeck.Draw();

        //Show Card in Popup
        var ui = FindObjectOfType<GetUIBase>().GetUI();
        var instance = Instantiate(cardShow_Prefab, ui.transform);
        var show = instance.GetComponent<PopUp_Card_Show>();
        show.SetCard(card);
    }
}
