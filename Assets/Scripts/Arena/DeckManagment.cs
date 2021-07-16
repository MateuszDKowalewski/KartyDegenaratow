using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManagment : MonoBehaviour
{
    
    private List<string> deck = new List<string>();
    
    void Start()
    {
        var prefabs = Resources.LoadAll<CharacterPrefab>("Redy");
        foreach (var characterPrefab in prefabs)
        {
            int amount = Random.Range(1, 4);
            for (int i = 0; i < amount; i++)
            {
                deck.Add(characterPrefab.code);
            }
        }
        deck = tasowanie(deck);
    }

    public string getCard()
    {
        string response = deck[0];
        deck.RemoveAt(0);
        return response;
    }
    
    private List<string> tasowanie(List<string> kartas)
    {
        for(int i=0; i<kartas.Count; i++)
        {
            string K = kartas[i];
            kartas.Remove(kartas[i]);
            int losowe = Random.Range(0, kartas.Count);
            kartas.Insert(losowe, K);
        }
        return kartas;
    }
}
