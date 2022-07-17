using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardData : ScriptableObject
{
    public new string name;
    public Sprite artwork;
    public string description;
    public int endurance;
    public int attack;
    public int defense;
}
