using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{

    public GameObject cardPrefab;

    public Canvas canvas;

    public CardPrefabrd kolegaAseksualny;
    public CardPrefabrd kolegaBiseksualny;
    public CardPrefabrd kolegaFemboy;
    public CardPrefabrd kolegaFurru;
    public CardPrefabrd kolegaGej;
    public CardPrefabrd kolegaNiebinarny;

    public void generateCard(CardEnum type)
    {
        switch(type)
        {
            case CardEnum.KOLEGA_ASEKSUALNY:
            generateCard(kolegaAseksualny);
                break;
                
            case CardEnum.KOLEGA_BISEKSUALNY:
                generateCard(kolegaBiseksualny);
                break;
                
            case CardEnum.KOLEGA_FEMBOY:
                generateCard(kolegaFemboy);
                break;
                
            case CardEnum.KOLEGA_FURRY:
                generateCard(kolegaFurru);
                break;
                
            case CardEnum.KOLEGA_GEJ:
                generateCard(kolegaGej);
                break;
                
            case CardEnum.KOLEGA_NIEBINARNY:
                generateCard(kolegaNiebinarny);
                break;
                
        }
    }

    private void generateCard(CardPrefabrd prefab) {
        GameObject card = Instantiate(cardPrefab);
        if(card.GetComponent<CardDisplay>())
        {
            card.GetComponent<CardDisplay>().cardPrefabrd = prefab;
        }
        card.transform.parent = canvas.transform;
    }
}
