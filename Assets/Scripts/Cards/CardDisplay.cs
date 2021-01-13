using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public CardPrefabrd cardPrefabrd;

    public Text cardName;
    public Text description;

    public Image artwork;

    public Text health;
    public Text strength;
    public Text cost;

    void Start()
    {
        cardName.text = cardPrefabrd.name;
        description.text = cardPrefabrd.description;
        artwork.sprite = cardPrefabrd.artwork;
        health.text = cardPrefabrd.health.ToString();
        strength.text = cardPrefabrd.strength.ToString();
        cost.text = cardPrefabrd.cost.ToString();
    }
}
