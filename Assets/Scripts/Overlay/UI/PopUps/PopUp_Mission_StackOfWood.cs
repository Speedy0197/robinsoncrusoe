using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using Assets.Scripts.RobinsonCrusoe_Game.Level;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Mission_StackOfWood : MonoBehaviour
{
    public Button saveWood;
    public GameObject[] blockOfWood;
    public GameObject torch;

    public Texture2D okWood;

    private static int StackNumber = 1;
    private static int CurrentAmountSpend = 0;
    private static int CurrentIndex = 0;
    private static bool finishedStack = false;

    // Start is called before the first frame update
    void Start()
    {
        saveWood.onClick.AddListener(TaskOnClick);

        UpdateTextures();
    }

    private void TaskOnClick()
    {
        if(Wood.currentAmountOfWood > 1 && 
            !finishedStack &&
            StackNumber < 6)
        {
            CurrentAmountSpend++;
            Wood.DecreaseWoodBy(1);

            var obj = blockOfWood[CurrentIndex];
            obj.GetComponent<RawImage>().texture = okWood;
            CurrentIndex++;

            if(CurrentAmountSpend == StackNumber)
            {
                finishedStack = true;

                CurrentAmountSpend = 0;
                StackNumber++;

                if(StackNumber > 5)
                {
                    var level = RoundSystem.instance.myLevel;
                    var castaways = (Castaways)level;
                    castaways.StackOfWood_Completed();
                }
            }
        }
    }

    private void UpdateTextures()
    {
        if (InventionStorage.IsAvailable(Invention.Fire))
        {
            torch.SetActive(true);
        }

        int index = GetTotalValue();

        for (int i = 0; i < index; i++)
        {
            var obj = blockOfWood[i];
            obj.GetComponent<RawImage>().texture = okWood;
        }
    }

    public static int GetTotalValue()
    {
        int index = 0;
        for (int i = 0; i < StackNumber; i++)
        {
            index += i;
        }
        index += CurrentAmountSpend;
        return index;
    }

    public static void OnRoundChange()
    {
        finishedStack = false;
    }
}
