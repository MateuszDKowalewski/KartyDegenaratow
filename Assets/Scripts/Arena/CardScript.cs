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

    public double baseScale = 0.18;
    public double previewScale = 0.25;
    
    void Start()
    {
        artwork.sprite = prefab.cardArtwork;
        name.text = prefab.name;
        description.text = prefab.skillDescription;
        health.text = prefab.health.ToString();
        attack.text = prefab.strength.ToString();
        cost.text = prefab.cost.ToString();
    }

    void Update()
    {
        
    }
}
