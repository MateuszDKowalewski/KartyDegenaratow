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
        drawCard();
        focusCard();
        updateHorizontalPos();
    }

    private void drawCard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string randomCard = deck.getCard();
            GameObject instantiateCard = cardFactory.instantiateCard(randomCard, transform, transform.position);
            cards.Add(instantiateCard);
        }
    }

    private void focusCard()
    {
        foreach (var card in cards)
        {
            BoxCollider2D cardCollider = card.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin,ray.direction, out hit))
            {
                BoxCollider2D hitObjest = hit.transform.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
                if (cardCollider.Equals(hitObjest))
                {
                    Debug.Log(card.name);
                }
            }
        }
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
