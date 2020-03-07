using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEventCard_Material : MonoBehaviour
{
    public Material cardBack;
    public Material cardFront;

    private MeshRenderer meshRenderer;
    private IEventCard cardClass;
    private GameObject instance;

    //TODO: is it necessary to provide the option to change the viewpoint of the card?
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        var deck = FindObjectOfType<EventCard_Deck>();
        cardClass = deck.GetDrawnEventClass();
        instance = deck.GetInstantiatedEventClass();

        if (cardClass is IGatheringCard)
        {
            var gatheringDeck = FindObjectOfType<GatheringCard_Deck>();
            cardFront = gatheringDeck.GetMaterialFromName(name);
        }
        else
        {
            cardFront = deck.GetMaterialFromName(name);
        }

        isVisible = true;

        ButtonHandler.Btn_ChangeStageClicked += OnContinueButtonPressed;
    }

    private void OnContinueButtonPressed(object sender, System.EventArgs e)
    {
        ButtonHandler.Btn_ChangeStageClicked -= OnContinueButtonPressed;

        if(cardClass is IGatheringCard)
        {
            cardClass.ExecuteFutureThreat();
            Destroy(instance);
        }
        else
        {
            cardClass.ExecuteActiveThreat();

            //TODO: change this to move card
            Destroy(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            meshRenderer.material = cardFront;
        }
        else
        {
            meshRenderer.material = cardBack;
        }
    }
}
