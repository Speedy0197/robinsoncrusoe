using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text FromWood;
    public Text FromFood;
    public Text FromPermanentFood;
    public Text FromHealth;
    public Text FromWeapon;
    public Text FromRoof;
    public Text FromWall;
    public Text FromVictory;
    public Text Total;

    // Start is called before the first frame update
    void Start()
    {
        FromWood.text = Score.FromWood.ToString();
        FromFood.text = Score.FromFood.ToString();
        FromPermanentFood.text = Score.FromPermanentFood.ToString();
        FromHealth.text = Score.FromHealth.ToString();
        FromWeapon.text = Score.FromWeapon.ToString();
        FromRoof.text = Score.FromRoof.ToString();
        FromWall.text = Score.FromWall.ToString();
        FromWeapon.text = Score.FromWeapon.ToString();
        FromVictory.text = Score.FromVictory.ToString();
        Total.text = Score.Total.ToString();
    }
}
