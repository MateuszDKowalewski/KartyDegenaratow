using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{

    public CardFactory cardFactory;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            cardFactory.generateCard(CardEnum.KOLEGA_ASEKSUALNY);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            cardFactory.generateCard(CardEnum.KOLEGA_BISEKSUALNY);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            cardFactory.generateCard(CardEnum.KOLEGA_FEMBOY);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            cardFactory.generateCard(CardEnum.KOLEGA_FURRY);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            cardFactory.generateCard(CardEnum.KOLEGA_GEJ);
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            cardFactory.generateCard(CardEnum.KOLEGA_NIEBINARNY);
        }
    }

}
