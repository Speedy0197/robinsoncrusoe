using Assets.Scripts.Generic;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    public RawImage characterImageContainer;

    // Start is called before the first frame update
    void Start()
    {
        Character character = PlayerHelper.Instance().GetCharacter();

        characterImageContainer.color = new Color(255, 255, 255, 255);
        string filePath = "Assets/Materials/" + character.GetCharacterName() + ".png";
        characterImageContainer.texture = ImageLoader.LoadPNG(filePath);

        RoundSystem.init();
            }

    // Update is called once per frame
    void Update()
    {
        
    }
}
