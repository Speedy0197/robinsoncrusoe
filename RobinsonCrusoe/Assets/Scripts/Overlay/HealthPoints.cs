using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    public Text healthPointsText;

    // Start is called before the first frame update
    void Start()
    {
        Character character = PlayerHelper.Instance().GetCharacter();
        healthPointsText.text = character.GetCurrentHealth().ToString();
        character.HealthLoss += Character_HealthLoss;
    }

    private void Character_HealthLoss(object sender, System.EventArgs e)
    {
        var character = sender as Character;
        healthPointsText.text = character.GetCurrentHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
