using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGatheringCard_Material : MonoBehaviour
{
    public Material cardBack;
    public Material cardFront;

    private MeshRenderer meshRenderer;
    private IGatheringCard cardClass;
    private GameObject instance;

    //TODO: is it necessary to provide the option to change the viewpoint of the card?
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        var deck = FindObjectOfType<GatheringCard_Deck>();

        cardClass = deck.GetDrawnEventClass();
        cardFront = deck.GetMaterialFromName(name);
        instance = deck.GetInstantiatedEventClass();

        isVisible = true;

        ButtonHandler.Btn_ChangeStageClicked += OnContinueButtonPressed;
    }

    private void OnContinueButtonPressed(object sender, System.EventArgs e)
    {
        ButtonHandler.Btn_ChangeStageClicked -= OnContinueButtonPressed;
        var eventCard = cardClass as IEventCard;
        eventCard.ExecuteActiveThreat();
        Destroy(instance);
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
