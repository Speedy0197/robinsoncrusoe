using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Weather_Show : MonoBehaviour
{
    public RawImage dice_1;
    public GameObject diceObject_1;
    public RawImage dice_2;
    public GameObject diceObject_2;
    public RawImage dice_3;
    public GameObject diceObject_3;
    public GameObject foodDice_1;
    public GameObject woodDice_1;
    public GameObject textFoodDice_1;
    public GameObject textWoodDice_1;
    public Text descriptionText;

    public Texture2D[] orangeDiceTexture;
    public Texture2D[] whiteDiceTexture;
    public Texture2D[] redDiceTexture;

    public Button confirm;
    public GameObject popUp;
    private DiceSet weatherDice;

    private int amountFoodGone = 0;
    private int amountWoodGone = 0;
    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);
        /*if (WeatherContainer not empty){
         *  if (token == snow)
         *  {
         *      GetRidOfSnow(1);
         *  }
         *  if (token == storm)
         *  {
         *      Wall.DecreaseBy(1);
         *  }
         *  if (token == rain)
         *  {
         *      GetRidOfRain(1);
         *  }
         * 
         * }
         */
        weatherDice = RoundSystem.instance.GetWeatherDices();
        RollDices(weatherDice);
        ShowText(weatherDice);
    }

    private void ShowText(DiceSet weatherDice)
    {
        if(!weatherDice.weatherDice_Normal && !weatherDice.weatherDice_Advanced && !weatherDice.environmentalDice)
        {
            descriptionText.text = "Weit und breit ist keine einzige Wolke zu sehen";
            return;
        }
        descriptionText.text = "Über der Insel braut sich ein Sturm zusammen";
        ShowDamage();
    }

    private void TaskOnClick()
    {
        Destroy(popUp);
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
    }

    private WeatherDice_Normal result_Normal;
    private WeatherDice_Advanced result_Advanced;
    private EnvironmentalDice result_Environment;
    private void RollDices(DiceSet weatherDice)
    {
        if (weatherDice.weatherDice_Normal)
        {
            diceObject_1.SetActive(true);
            var result = WeatherDice_Simulation.RollOrangeWeather();
            if (result == WeatherDice_Normal.Rain)
            {
                dice_1.texture = orangeDiceTexture[0];
                GetRidOfRain(1);
            }
            if (result == WeatherDice_Normal.StrongRain)
            {
                dice_1.texture = orangeDiceTexture[1];
                GetRidOfRain(2);
            }
            if (result == WeatherDice_Normal.Snow)
            {
                dice_1.texture = orangeDiceTexture[2];
                GetRidOfSnow(1);
            }
            result_Normal = result;
        }
        if (weatherDice.weatherDice_Advanced)
        {
            diceObject_2.SetActive(true);
            var result = WeatherDice_Simulation.RollWhiteWeather();
            if (result == WeatherDice_Advanced.StrongRain)
            {
                dice_2.texture = whiteDiceTexture[0];
                GetRidOfRain(2);
            }
            if (result == WeatherDice_Advanced.Snow)
            {
                dice_2.texture = whiteDiceTexture[1];
                GetRidOfSnow(1);
            }
            if (result == WeatherDice_Advanced.StrongSnow) 
            { 
                dice_2.texture = whiteDiceTexture[2];
                GetRidOfSnow(2);
            }
            result_Advanced = result;
        }
        if (weatherDice.environmentalDice)
        {
            diceObject_3.SetActive(true);
            var result = WeatherDice_Simulation.RollEnvironment();
            if (result == EnvironmentalDice.Animal)
            {
                dice_3.texture = redDiceTexture[0];
                if(WeaponPower.currentWeaponPower < 3)
                {
                    var activeChar = PartyActions.GetActiveCharacter();
                    int difference = 3 - WeaponPower.currentWeaponPower;
                    CharacterActions.DamageCharacterBy(difference, activeChar);
                }
            }
            if (result == EnvironmentalDice.Nothing) dice_3.texture = redDiceTexture[1];
            if (result == EnvironmentalDice.FoodLoss)
            {
                dice_3.texture = redDiceTexture[2];
                amountFoodGone -= 1;
                PerishableFood.DecreaseBy(1);
            }
            if (result == EnvironmentalDice.PalisadeDamage)
            {
                dice_3.texture = redDiceTexture[3];
                Wall.DowngradeWallBy(1);
            }
            result_Environment = result;
        }
    }

    private void GetRidOfSnow(int amount)
    {
        amountWoodGone -= amount;
        Wood.DecreaseWoodBy(amount);
        GetRidOfRain(amount);
    }

    private void GetRidOfRain(int amount)
    {
        if (amount > Roof.RoofState)
        {
            int difference = amount - Roof.RoofState;
            amountFoodGone -= difference;
            amountWoodGone -= difference;
            PerishableFood.DecreaseBy(difference);
            Wood.DecreaseWoodBy(difference);
        }
    }
    private void ShowDamage()
    {
        textFoodDice_1.SetActive(true);
        textFoodDice_1.GetComponent<Text>().text = amountFoodGone.ToString();
        foodDice_1.SetActive(true);
        textWoodDice_1.SetActive(true);
        textWoodDice_1.GetComponent<Text>().text = amountWoodGone.ToString();
        woodDice_1.SetActive(true);
    }
}
