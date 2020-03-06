using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEventCard_Material : MonoBehaviour
{
    public Material cardBack;
    public Material cardFront;

    private EventCard_Deck deck;
    private MeshRenderer meshRenderer;
    private IEventCard cardClass;

    //TODO: is it necessary to provide the option to change the viewpoint of the card?
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        deck = FindObjectOfType<EventCard_Deck>();

        cardFront = deck.GetMaterialFromName(name);
        cardClass = deck.GetDrawnEventClass();

        meshRenderer = GetComponent<MeshRenderer>();

        isVisible = true;
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

    private void OnMouseDown()
    {
        cardClass.ExecuteActiveThreat();
        Destroy(this);
    }
}
