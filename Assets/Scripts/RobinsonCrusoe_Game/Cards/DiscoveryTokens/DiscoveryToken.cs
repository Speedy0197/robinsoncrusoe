using Assets.Scripts.RobinsonCrusoe_Game.Cards.DiscoveryTokens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryToken : MonoBehaviour
{
    public IDiscoveryToken currentToken;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetMaterial(Material m)
    {
        var mesh = GetComponent<MeshRenderer>();
        mesh.material = m;
    }
}
