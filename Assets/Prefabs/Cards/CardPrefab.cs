using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Card")]
public class CardPrefabrd : ScriptableObject
{
    public new string name;
    public string description;
    public string skilsDescription;

    public Sprite artwork;

    public int cost;
    public int health;
    public int strength;

}
