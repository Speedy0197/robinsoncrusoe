using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_DeckCard_Show : MonoBehaviour
{
    public GameObject popUp;

    public Text cardNameText;
    public RawImage cardFaceContainer;
    public Text descriptionText;
    public Button confirmButton;
    public GameObject discardButton;

    private ICard myCard;
    private Texture2D myCardTexture;
    private bool hastToCallNextProcess;
    private void Start()
    {
        confirmButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Destroy(popUp);

        SpecialCardActions();

        var mainDeck = FindObjectOfType<EventCard_Deck>();
        mainDeck.PushAndShuffel(myCard);

        if (hastToCallNextProcess)
        {
            FindObjectOfType<ActionProcesser>().ProcessNextAction();
        }
    }

    private void SpecialCardActions()
    {
        if (myCard.ToString() == "End of Source")
        {
            FindObjectOfType<GatheringActions_Processing>().EndOfSource();
        }
        else
        {
            myCard.ExecuteEvent();
        }
    }

    public void SetCard(ICard card, bool processHelper)
    {
        hastToCallNextProcess = processHelper;
        myCard = card;
        myCardTexture = GetCardTexture();
        cardFaceContainer.texture = myCardTexture;

        if (myCard.HasDiscardOption())
        {
            discardButton.SetActive(true);
            discardButton.GetComponent<Button>().onClick.AddListener(OnDiscardClick);
        }

        cardNameText.text = myCard.ToString();
        descriptionText.text = myCard.GetCardDescription();
    }

    private void OnDiscardClick()
    {
        Destroy(popUp);

        if (hastToCallNextProcess)
        {
            FindObjectOfType<ActionProcesser>().ProcessNextAction();
        }
    }

    private Texture2D GetCardTexture()
    {
        if (myCard is IBuildingCard)
        {
            var buildingDeck = FindObjectOfType<BuildingCard_Deck>();
            return buildingDeck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
        if (myCard is IGatheringCard)
        {
            var gatheringDeck = FindObjectOfType<GatheringCard_Deck>();
            return gatheringDeck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
        if (myCard is IExploringCard)
        {
            var exploringDeck = FindObjectOfType<ExploringCard_Deck>();
            return exploringDeck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
        throw new Exception("Texture not found");
    }
}
