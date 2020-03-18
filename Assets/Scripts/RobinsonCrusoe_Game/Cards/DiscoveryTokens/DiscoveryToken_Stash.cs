using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.DiscoveryTokens;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.DiscoveryTokens.Collection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryToken_Stash : MonoBehaviour
{
    public Material tokenBack;
    public Material[] tokenFaces;
    public GameObject tokenPrefab;

    private List<IDiscoveryToken> tokenStash;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }
    private void PlayCards()
    {
        tokenStash = GenerateNewDeck();
        DeckActions.Shuffle(tokenStash);

        foreach (var token in tokenStash)
        {
            Debug.Log(token);
        }
    }
    private List<IDiscoveryToken> GenerateNewDeck()
    {
        List<IDiscoveryToken> newStash = new List<IDiscoveryToken>();

        //TODO: Change the following to include mutliple cards
        newStash.Add(new DiscoveryToken_Pots());

        return newStash;
    }

    public IDiscoveryToken Draw()
    {
        var token = tokenStash[0];
        tokenStash.RemoveAt(0);

        //TODO: create instance of prefab?? and asign token and material

        return token;
    }

    public Material GetMaterialFromID(int id)
    {
        return tokenFaces[id];
    }
}
