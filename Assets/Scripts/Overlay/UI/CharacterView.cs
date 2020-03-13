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
        List<Character> chars = new List<Character>() { new Cook(), new Soldier(), new Explorer() };
        chars[1].TakePointsOfDamage(2, DamageType.Damage);
        Transform tempPosition = position;
        foreach(var character in chars)
        {
            var instance = Instantiate(characterContainerPrefab, tempPosition);
            instance.transform.Translate(0, spaceBetween, 0);
            tempPosition = instance.transform;

            var view = instance.GetComponent<SmallCharacterView>();
            view.SetCharacter(character);
        }
    }
}
