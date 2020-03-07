using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards;
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
    private int Position;

    //TODO: is it necessary to provide the option to change the viewpoint of the card?
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        Position = 0;

        meshRenderer = GetComponent<MeshRenderer>();
        var deck = FindObjectOfType<EventCard_Deck>();
        cardClass = deck.GetDrawnEventClass();
        instance = deck.GetInstantiatedEventClass();

        if (cardClass is IGatheringCard)
        {
            var gatheringDeck = FindObjectOfType<GatheringCard_Deck>();
            cardFront = gatheringDeck.GetMaterialFromName(name);
        }
        else if(cardClass is IBuildingCard)
        {
            var buildingDeck = FindObjectOfType<BuildingCard_Deck>();
            cardFront = buildingDeck.GetMaterialFromName(name);
        }
        else if(cardClass is IExploringCard)
        {
            var buildingDeck = FindObjectOfType<ExploringCard_Deck>();
            cardFront = buildingDeck.GetMaterialFromName(name);
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
        else if(cardClass is IBuildingCard)
        {
            cardClass.ExecuteFutureThreat();
            Destroy(instance);
        }
        else if(cardClass is IExploringCard)
        {
            cardClass.ExecuteFutureThreat();
            Destroy(instance);
        }
        else
        {
            cardClass.ExecuteActiveThreat();

            Move_EventCard.MoveEvent += OnMoveEvent;
            Move_EventCard.RequestMove();
        }
    }

    private void OnMoveEvent(object sender, System.EventArgs e)
    {
        Move();
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

    private void Move()
    {
        if (Position > 1)
        {
            cardClass.ExecuteFutureThreat();
            Move_EventCard.MoveEvent -= OnMoveEvent;
            Destroy(instance);
        }
        else
        {
            var cardMover = FindObjectOfType<Move_EventCard>();
            cardMover.MoveCardOnPosition(instance, Position);
            Position++;
        }
    }
}
