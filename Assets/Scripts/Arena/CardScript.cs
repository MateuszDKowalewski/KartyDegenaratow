using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{

    public CharacterPrefab prefab;
    public Image artwork;
    public new Text name;
    public Text description;
    public Text health;
    public Text attack;
    public Text cost;

    public float baseScale = 0.18f;
    public float previewScale = 0.25f;

    public void Init(CharacterPrefab characterPrefab)
    {
        prefab = characterPrefab;
        artwork.sprite = characterPrefab.cardArtwork;
        name.text = characterPrefab.name;
        description.text = characterPrefab.skillDescription;
        health.text = characterPrefab.health.ToString();
        attack.text = characterPrefab.strength.ToString();
        cost.text = characterPrefab.cost.ToString();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
