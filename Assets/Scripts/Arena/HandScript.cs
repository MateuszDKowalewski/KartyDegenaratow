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
            List<string> result = cardFactory.getCardsNames();
            foreach (string r in result)
            {
                Debug.Log(r);
            }
        }
    }
}
