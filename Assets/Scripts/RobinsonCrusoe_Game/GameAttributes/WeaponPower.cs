﻿using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class WeaponPower
    {
        public static event EventHandler WeaponPowerChanged;

        public static int currentWeaponPower { get; private set; } = 0;

        public static void SetStartValue(int start)
        {
            if (start < 0) start = 0;
            if (start > 10) start = 10;

            currentWeaponPower = start;
            WeaponPowerChanged?.Invoke(currentWeaponPower, new EventArgs());
        }

        public static void RaiseWeaponPowerBy(int value)
        {
            currentWeaponPower += value;
            if (currentWeaponPower > 10) currentWeaponPower = 10;

            WeaponPowerChanged?.Invoke(currentWeaponPower, new EventArgs());
        }

        public static void LowerWeaponPowerBy(int value)
        {
            currentWeaponPower -= value;
            if (currentWeaponPower < 0)
            {
                int dmg = Math.Abs(currentWeaponPower);
                PartyActions.DamageAllPlayers(dmg);

                currentWeaponPower = 0;
            }

            WeaponPowerChanged?.Invoke(currentWeaponPower, new EventArgs());
        }
    }
}
