using Assets.Scripts.Overlay.MainMenu;
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debug_Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Party party = new Party();
        party.cook = new Assets.Scripts.RobinsonCrusoe_Game.Characters.Cook();

        PartyHandler.CreateParty(party, 1);
        SceneManager.LoadScene("GameScene");
    }
}
