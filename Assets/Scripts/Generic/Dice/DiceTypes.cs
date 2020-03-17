using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Generic.Dice
{
    public enum SuccessDice
    {
        Success,
        Determination
    }

    public enum DamageDice
    {
        Damage,
        Nothing
    }

    public enum CardDice
    {
        Card,
        Nothing
    }

    public enum WeatherDice_Normal
    {
        Snow,
        Rain,
        StrongRain,
    }
    public enum WeatherDice_Advanced
    {
        Snow,
        StrongSnow,
        StrongRain
    }
    public enum EnvironmentalDice
    {
        Animal,
        PalisadeDamage,
        FoodLoss,
        Nothing
    }
}
