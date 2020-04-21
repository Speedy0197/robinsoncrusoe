using Assets.Scripts.Generic.Dice;
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
    public Text descriptionText;

    public Texture2D[] orangeDiceTexture;
    public Texture2D[] whiteDiceTexture;
    public Texture2D[] redDiceTexture;

    public Button confirm;
    public GameObject popUp;
    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);
        var weatherDice = RoundSystem.instance.GetWeatherDices();
        RollDices(weatherDice);
        ShowText(weatherDice);
    }

    private void ShowText(DiceSet weatherDice)
    {
        if(!weatherDice.weatherDice_Normal && !weatherDice.weatherDice_Advanced && !weatherDice.environmentalDice)
        {
            descriptionText.text = "Weit und breit ist keine einzigste Wolke zu sehen";
            return;
        }
        descriptionText.text = "Über der Insel braut sich ein Sturm zusammen";
    }

    private void TaskOnClick()
    {
        //TODO: interpret results

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
            if (result == WeatherDice_Normal.Rain) dice_1.texture = orangeDiceTexture[0];
            if (result == WeatherDice_Normal.StrongRain) dice_1.texture = orangeDiceTexture[1];
            if (result == WeatherDice_Normal.Snow) dice_1.texture = orangeDiceTexture[2];
            result_Normal = result;
        }
        if (weatherDice.weatherDice_Advanced)
        {
            diceObject_2.SetActive(true);
            var result = WeatherDice_Simulation.RollWhiteWeather();
            if (result == WeatherDice_Advanced.StrongRain) dice_2.texture = whiteDiceTexture[0];
            if (result == WeatherDice_Advanced.Snow) dice_2.texture = whiteDiceTexture[1];
            if (result == WeatherDice_Advanced.StrongSnow) dice_2.texture = whiteDiceTexture[2];
            result_Advanced = result;
        }
        if (weatherDice.environmentalDice)
        {
            diceObject_3.SetActive(true);
            var result = WeatherDice_Simulation.RollEnvironment();
            if (result == EnvironmentalDice.Animal) dice_3.texture = redDiceTexture[0];
            if (result == EnvironmentalDice.Nothing) dice_3.texture = redDiceTexture[1];
            if (result == EnvironmentalDice.FoodLoss) dice_3.texture = redDiceTexture[2];
            if (result == EnvironmentalDice.PalisadeDamage) dice_3.texture = redDiceTexture[3];
            result_Environment = result;
        }
    }
}
