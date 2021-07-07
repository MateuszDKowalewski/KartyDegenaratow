using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{

    List<GameObject> cards = new List<GameObject>();
    public CardFactory cardFactory;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            string randomCard = cardFactory.getCardsNames()[0];
            cards.Add(cardFactory.instantiateCard(randomCard, transform, transform.position));
        }

        updateHorizontalPos();
    }

    private void updateHorizontalPos()
    {
        int n = 0;
        foreach(GameObject card in cards)
        {
            Vector2 temp = new Vector2(-200f + 50 * n++ ,card.transform.position.y);
            card.transform.position = temp;
        }
    }
}
