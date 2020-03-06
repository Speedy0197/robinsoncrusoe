using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_Card : MonoBehaviour
{
    public IEventCard eventCard;

    // Start is called before the first frame update
    void Start()
    {
        ButtonHandler.Btn_ChangeStageClicked += OnContinueClicked;

        this.GetComponent<MeshRenderer>().material = eventCard.GetMaterial();

        var SpawnPoint = GameObject.Find("Card_Position_0").transform;
        Instantiate(this, SpawnPoint);
    }

    private void OnContinueClicked(object sender, System.EventArgs e)
    {
        ButtonHandler.Btn_ChangeStageClicked -= OnContinueClicked;
        eventCard.ExecuteActiveThreat();
        //TODO: Move Card
    }

    private void OnDestroy()
    {
        
    }
}
