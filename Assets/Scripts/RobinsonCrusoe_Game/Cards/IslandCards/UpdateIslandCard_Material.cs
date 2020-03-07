using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateIslandCard_Material : MonoBehaviour
{
    public Material cardBack;
    public Material cardFront;

    private MeshRenderer meshRenderer;
    private IIslandCard cardClass;

    //TODO: is it necessary to provide the option to change the viewpoint of the card?
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        var deck = FindObjectOfType<IslandCard_Deck>();

        cardClass = deck.GetDrawnEventClass();
        cardFront = deck.GetMaterialFromName(name);

        isVisible = true;

        ButtonHandler.Btn_ChangeStageClicked += OnContinueButtonPressed;
    }

    private void OnContinueButtonPressed(object sender, System.EventArgs e)
    {
        ButtonHandler.Btn_ChangeStageClicked -= OnContinueButtonPressed;
        var islandCard = cardClass as IIslandCard;
        islandCard.Explore();
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
