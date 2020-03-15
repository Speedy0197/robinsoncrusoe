using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Generic
{
    public static class DiceSimulator
    {
        /// <summary>
        /// Rolls all three dices needed for an unsafe Action, no value interpretation.
        /// </summary>
        public static ActionDiceSet RollActionDice()
        {
            Random r = new Random();
            int value_1 = r.Next(1, 60) % 6;
            int value_2 = r.Next(1, 60) % 6;
            int value_3 = r.Next(1, 60) % 6;

            ActionDiceSet set = new ActionDiceSet();
            if (value_1 == 2 || value_1 == 3)
            {
                set.dice_1 = ActionDice_1.Determination;
            }
            else set.dice_1 = ActionDice_1.Success;

            if (value_2 == 3 || value_2 == 4)
            {
                set.dice_2 = ActionDice_2.Nothing;
            }
            else set.dice_2 = ActionDice_2.Damage;

            if (value_3 == 1 || value_3 == 3 || value_3 == 4)
            {
                set.dice_3 = ActionDice_3.QuestionMark;
            }
            else set.dice_3 = ActionDice_3.Nothing;

            return set;
        }

        /// <summary>
        /// Rolls the orange Weather-Dice, no value interpretation.
        /// </summary>
        public static WeatherDice_Normal RollOrangeWeather()
        {
            Random r = new Random();
            int value_1 = r.Next(1, 60) % 6;

            if (value_1 == 1) return WeatherDice_Normal.Snow;
            if (value_1 == 2 || value_1 == 5) return WeatherDice_Normal.StrongRain;
            return WeatherDice_Normal.Rain;
        }

        /// <summary>
        /// Rolls the white Weather-Dice, no value interpretation.
        /// </summary>
        public static WeatherDice_Advanced RollWhiteWeather()
        {
            Random r = new Random();
            int value_1 = r.Next(1, 60) % 6;

            if (value_1 == 1 || value_1 == 4) return WeatherDice_Advanced.Snow;
            if (value_1 == 2 || value_1 == 0) return WeatherDice_Advanced.StrongRain;
            return WeatherDice_Advanced.StrongSnow;
        }

        /// <summary>
        /// Rolls the Environmental-Dice, no value interpretation.
        /// </summary>
        public static EnvironmentalDice RollEnvironment()
        {
            Random r = new Random();
            int value_1 = r.Next(1, 60) % 6;

            if (value_1 == 1) return EnvironmentalDice.Animal;
            if (value_1 == 2 || value_1 == 0) return EnvironmentalDice.PalisadeDamage;
            if (value_1 == 4) return EnvironmentalDice.FoodLoss;
            else return EnvironmentalDice.Nothing;
        }
    }

    public enum ActionDice_1
    {
        Success,
        Determination,
    }
    public enum ActionDice_2
    {
        Damage,
        Nothing,
    }
    public enum ActionDice_3
    {
        QuestionMark,
        Nothing
    }
    public struct ActionDiceSet
    {
        public ActionDice_1 dice_1 { get; set; }
        public ActionDice_2 dice_2 { get; set; }
        public ActionDice_3 dice_3 { get; set; }
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
