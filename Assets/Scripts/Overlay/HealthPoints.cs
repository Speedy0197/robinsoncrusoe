using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    public Text healthPointsText;
    public RawImage moralArrow;

    // Start is called before the first frame update
    void Start()
    {
        Character character = PlayerHelper.Instance().GetCharacter();
        healthPointsText.text = character.GetCurrentHealth().ToString();
        character.HealthLoss += Character_HealthLoss;
        character.PreLowerMoral += Character_PreLowerMoral;
        character.PreRaiseMoral += Character_PreRaiseMoral;
        character.NoMoralChange += Character_NoMoralChange;
    }

    private void Character_NoMoralChange(object sender, System.EventArgs e)
    {
        moralArrow.color = new Color(255, 255, 255, 0);
    }

    private void Character_PreRaiseMoral(object sender, System.EventArgs e)
    {
        SetArrowTo(Direction.Left);
    }

    private void Character_PreLowerMoral(object sender, System.EventArgs e)
    {
        SetArrowTo(Direction.Right);
    }

    private void SetArrowTo(Direction direction)
    {
        Vector3 rotation = moralArrow.transform.rotation.eulerAngles;
        var rotateAngle = 0;
        if(direction == Direction.Left)
        {
            //Angle 0 == Left
            if (rotation.y >= 100) rotateAngle = 180;
        }
        else
        {
            //Angle 180 == Right
            if (rotation.y < 100) rotateAngle = 180;
        }
        moralArrow.color = new Color(255, 255, 255, 255);
        moralArrow.transform.Rotate(0, rotateAngle, 0);
    }

    private void Character_HealthLoss(object sender, System.EventArgs e)
    {
        var character = sender as Character;
        healthPointsText.text = character.GetCurrentHealth().ToString();
    }
    private enum Direction
    {
        Left,
        Right,
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
