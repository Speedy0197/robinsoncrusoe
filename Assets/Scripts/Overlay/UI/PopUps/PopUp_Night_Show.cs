using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Night_Show : MonoBehaviour
{
    public Button confirm;
    public Text infoText;
    public GameObject popUp;
    public static bool CampMoved;

    // Start is called before the first frame update
    void Start()
    {
        CampMoved = false;

        confirm.onClick.AddListener(TaskOnClick);
        infoText.text = "Die Nacht senkt sich über die Insel.\r\nDie Gruppe isst " + PartyHandler.PartySize.ToString() + " Einheiten Nahrung";

        //TODO: check if enough food is available, let the players choose who starves
    }

    private void TaskOnClick()
    {
        PartyActions.Sleep();
        if(Tent.Status == TentStatus.Fireplace)
        {
            PartyActions.DamageAllPlayers(1);
        }

        if (InventionStorage.IsAvailable(Invention.Cellar))
        {
            var food = FoodStorage.Food;
            FoodStorage.DecreaseFoodBy(food);
            FoodStorage.IncreasePermantFoodBy(food);
        }

        if (CampMoved)
        {
            Wall.HalfValue_Ceiling();
            Roof.HalfValue_Ceiling();
        }

        FoodStorage.DiscardFood();

        Destroy(popUp);
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
        RoundSystem.instance.increaseRound();
    }
}
