using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{

    public CardFactory cardFactory;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            string randomCard = cardFactory.getCardsNames()[0];
            cardFactory.instantiateCard(randomCard, transform, transform.position);
        }
    }
}
