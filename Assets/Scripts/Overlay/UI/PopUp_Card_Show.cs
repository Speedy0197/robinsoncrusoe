using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Card_Show : MonoBehaviour
{
    public Texture2D[] eventCardFaces;
    public Texture2D[] gatheringCardFaces;
    public Texture2D[] buildingCardFaces;
    public Texture2D[] exploringCardFaces;

    public Text cardNameText;
    public RawImage cardFaceContainer;
    public Text descriptionText;

    private IEventCard myCard;
    public void SetCard(IEventCard card)
    {
        myCard = card;
        cardFaceContainer.texture = GetCardTexture();
        cardNameText.text = GetNameWithoutID();
        descriptionText.text = myCard.GetDescriptionText();
    }

    private Texture2D GetCardTexture()
    {
        if(myCard is IGatheringCard)
        {
            return gatheringCardFaces[myCard.GetMaterialNumber()];
        }
        else if(myCard is IBuildingCard)
        {
            return buildingCardFaces[myCard.GetMaterialNumber()];
        }
        else if(myCard is IExploringCard)
        {
            return exploringCardFaces[myCard.GetMaterialNumber()];
        }
        else
        {
            return eventCardFaces[myCard.GetMaterialNumber()];
        }
    }

    private string GetNameWithoutID()
    {
        string[] splitted = myCard.ToString().Split(';');
        return splitted[0];
    }
}
