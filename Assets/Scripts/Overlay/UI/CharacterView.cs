using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    public GameObject characterContainerPrefab;
    public Transform position;

    public int spaceBetween = 30;

    // Start is called before the first frame update
    void Start()
    {
        List<Character> chars = new List<Character>() { new Cook(), new Cook(), new Cook() };

        Transform tempPosition = position;
        foreach(var character in chars)
        {
            var instance = Instantiate(characterContainerPrefab, tempPosition);
            instance.transform.Translate(0, spaceBetween, 0);
            tempPosition = instance.transform;
        }
    }
}
