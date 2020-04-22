using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public static class EndGame
    {
        public static void Victory()
        {
            Score.CalculatePoints(true);

            var param = new Dictionary<string, object>();
            param.Add("FromWood", Score.FromWood);
            param.Add("FromFood", Score.FromFood);
            param.Add("FromPermanentFood", Score.FromPermanentFood);
            param.Add("FromHealth", Score.FromHealth);
            param.Add("FromRoof", Score.FromRoof);
            param.Add("FromWall", Score.FromWall);
            param.Add("FromWeapon", Score.FromWeapon);
            param.Add("FromVictory", Score.FromVictory);
            param.Add("Total", Score.Total);

            Analytics.CustomEvent("GameVictory", param);
            SceneManager.LoadScene("GameVictory");
        }

        public static void Defeat()
        {
            Score.CalculatePoints(false);

            var param = new Dictionary<string, object>();
            param.Add("FromWood", Score.FromWood);
            param.Add("FromFood", Score.FromFood);
            param.Add("FromPermanentFood", Score.FromPermanentFood);
            param.Add("FromHealth", Score.FromHealth);
            param.Add("FromRoof", Score.FromRoof);
            param.Add("FromWall", Score.FromWall);
            param.Add("FromWeapon", Score.FromWeapon);
            param.Add("FromVictory", Score.FromVictory);
            param.Add("Total", Score.Total);

            Analytics.CustomEvent("GameOver", param);
            SceneManager.LoadScene("GameOver");
        }
    }

    public static class Score
    {
        public static int FromWood { get; private set; }
        public static int FromFood { get; private set; }
        public static int FromPermanentFood { get; private set; }
        public static int FromHealth { get; private set; }
        public static int FromRoof { get; private set; }
        public static int FromWall { get; private set; }
        public static int FromWeapon { get; private set; }
        public static int FromVictory { get; private set; } = 0;
        public static int Total { get; private set; }

        public static void CalculatePoints(bool victorious)
        {
            FromWood = Wood.currentAmountOfWood;
            FromFood = FoodStorage.Food;
            FromPermanentFood = FoodStorage.PermanentFood;

            FromHealth = 0;
            foreach(var c in PartyHandler.PartySession)
            {
                FromHealth += c.CurrentHealth > 0? c.CurrentHealth : 0;
            }

            FromRoof = Roof.RoofState * 3;
            FromWall = Wall.WallState * 2;
            FromWeapon = WeaponPower.currentWeaponPower * 2;

            if (victorious) FromVictory = 8;

            Total = FromWood + FromFood + FromPermanentFood + FromHealth + FromRoof + FromWall + FromWeapon + FromVictory;
        }
    }
}
