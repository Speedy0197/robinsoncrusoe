using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
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

        var weatherContainer = FindObjectOfType<WeatherContainer>();
        foreach (var token in weatherContainer.TokenList)
        {
            if (token == WeatherToken.Snow)
            {
                GetRidOfSnow(1);
            }
            if (token == WeatherToken.Storm)
            {
                Wall.DowngradeWallBy(1);
            }
            if (token == WeatherToken.Rain)
            {
                GetRidOfRain(1);
            }
        }

        if (InventionStorage.IsAvailable(Invention.Furnance)) GetRidOfSnow(-1);

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


        GetRidOfEnvironment();
        HandleRessourceCosts();

        var phaseView = FindObjectOfType<PhaseView>();
        FindObjectOfType<WeatherContainer>().ResetTokens();
        phaseView.NextPhase();
    }

    private EnvironmentalDice result_Environment;

    private int amountRoofLeft;
    private void RollDices(DiceSet weatherDice)
    {
        amountRoofLeft = Roof.RoofState;

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
        }
        if (weatherDice.environmentalDice)
        {
            diceObject_3.SetActive(true);
            var result = WeatherDice_Simulation.RollEnvironment();
            result_Environment = result;
            if (result == EnvironmentalDice.Animal)
            {
                dice_3.texture = redDiceTexture[0];
            }
            if (result == EnvironmentalDice.Nothing) dice_3.texture = redDiceTexture[1];
            if (result == EnvironmentalDice.FoodLoss)
            {
                dice_3.texture = redDiceTexture[2];
                amountFoodGone += 1;
            }
            if (result == EnvironmentalDice.PalisadeDamage)
            {
                dice_3.texture = redDiceTexture[3];
            }
            result_Environment = result;
        }
    }

    private void GetRidOfEnvironment()
    {
        if (weatherDice.environmentalDice)
        {
            if (result_Environment == EnvironmentalDice.Animal)
            {
                if (WeaponPower.currentWeaponPower < 3)
                {
                    var activeChar = PartyActions.GetActiveCharacter();
                    int difference = 3 - WeaponPower.currentWeaponPower;
                    CharacterActions.DamageCharacterBy(difference, activeChar);
                }
            }
            if (result_Environment == EnvironmentalDice.PalisadeDamage)
            {
                Wall.DowngradeWallBy(1);
            }
        }
    }

    private void HandleRessourceCosts()
    {
        Debug.Log("Wood " + amountWoodGone);
        Debug.Log("Food " + amountFoodGone);

        if (amountWoodGone > 0)
        {
            Wood.DecreaseWoodBy(amountWoodGone);
        }
        if(amountFoodGone > 0)
        {
            if (FoodStorage.GetTotal() < amountFoodGone)
            {
                int difference = amountFoodGone - FoodStorage.GetTotal();
                FoodStorage.Consume(FoodStorage.GetTotal());
                PartyActions.DamageAllPlayers(difference);
            }
            else
            {
                FoodStorage.Consume(amountFoodGone);
            }
        }
    }

    private void GetRidOfSnow(int amount)
    {
        amountWoodGone += amount;
        GetRidOfRain(amount);
    }

    private void GetRidOfRain(int amount)
    {
        if (amount == amountRoofLeft) amountRoofLeft = 0;
        else if (amount > amountRoofLeft)
        {
            int difference = amount - amountRoofLeft;
            if (difference <= 0) return;
            amountFoodGone += difference;
            amountWoodGone += difference;
            amountRoofLeft = 0;
        }
        else if (amount < amountRoofLeft) amountRoofLeft -= amount;
    }
    private void ShowDamage()
    {
        int foodText = 0 - amountFoodGone;
        int woodText = 0 - amountWoodGone;

        textFoodDice_1.SetActive(true);
        textFoodDice_1.GetComponent<Text>().text = foodText.ToString();
        foodDice_1.SetActive(true);
        textWoodDice_1.SetActive(true);
        textWoodDice_1.GetComponent<Text>().text = woodText.ToString();
        woodDice_1.SetActive(true);
    }
}
