using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New character", menuName = "Character")]
public class CharacterPrefab : ScriptableObject
{
    public string code;
    
    // General
    public new string name;
    public string description;
    public string skillDescription;

    // Graphics
    public Sprite cardArtwork;
    public Sprite checkerArtwork;

    // Stats
    public int cost;
    public int health;
    public int strength;
    
    // Movement
    public Vector2Int[] possibleMoves;


}
