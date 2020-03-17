using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Generic.Dice
{
    public static class WeatherDice_Simulation
    {
        /// <summary>
        /// Rolls the orange Weather-Dice, no value interpretation.
        /// </summary>
        public static WeatherDice_Normal RollOrangeWeather()
        {
            Random r = new Random();
            int result = r.Next(1, 60) % 6;

            if (result == 1) return WeatherDice_Normal.Snow;
            if (result == 2 || result == 5) return WeatherDice_Normal.StrongRain;
            return WeatherDice_Normal.Rain;
        }

        /// <summary>
        /// Rolls the white Weather-Dice, no value interpretation.
        /// </summary>
        public static WeatherDice_Advanced RollWhiteWeather()
        {
            Random r = new Random();
            int result = r.Next(1, 60) % 6;

            if (result == 1 || result == 4) return WeatherDice_Advanced.Snow;
            if (result == 2 || result == 0) return WeatherDice_Advanced.StrongRain;
            return WeatherDice_Advanced.StrongSnow;
        }

        /// <summary>
        /// Rolls the Environmental-Dice, no value interpretation.
        /// </summary>
        public static EnvironmentalDice RollEnvironment()
        {
            Random r = new Random();
            int result = r.Next(1, 60) % 6;

            if (result == 1) return EnvironmentalDice.Animal;
            if (result == 2 || result == 0) return EnvironmentalDice.PalisadeDamage;
            if (result == 4) return EnvironmentalDice.FoodLoss;
            else return EnvironmentalDice.Nothing;
        }
    }
}
