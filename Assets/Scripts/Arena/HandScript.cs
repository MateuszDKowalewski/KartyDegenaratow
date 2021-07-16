using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{

    List<GameObject> cards = new List<GameObject>();
    public CardFactory cardFactory;
    public DeckManagment deck;
    
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string randomCard = deck.getCard();
            Debug.Log(randomCard);
            GameObject instantiateCard = cardFactory.instantiateCard(randomCard, transform, transform.position);
            Debug.Log("Instanted:");
            Debug.Log(instantiateCard);
            cards.Add(instantiateCard);
        }

        updateHorizontalPos();
    }

    private void updateHorizontalPos()
    {
        int n = 0;
        int min = -25 * cards.Count;
        // 50 per card seems good for now
        foreach(GameObject card in cards)
        {
            Vector2 temp = new Vector2(min + 50 * n++, card.transform.position.y);
            RectTransform rt = card.GetComponent<RectTransform>();
            rt.localPosition = temp;
        }
    }
}
