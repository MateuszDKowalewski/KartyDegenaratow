using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    
    public GameObject cardPrefab;
    private static Dictionary<string, CharacterPrefab> _allCharacters;
    private static bool _isInitialized = _allCharacters != null;
    
    public void Start()
    {
        if (_isInitialized)
        {
            return;
        }
        var prefabs = Resources.LoadAll<CharacterPrefab>("Redy");
        _allCharacters = new Dictionary<string, CharacterPrefab>();
        foreach (var prefab in prefabs)
        {
            _allCharacters.Add(prefab.code, prefab);
        }
    }

    public GameObject instantiateCard(string name, Transform parent, Vector3 position)
    {
        if (!_allCharacters.ContainsKey(name))
        {
            // TODO: throw exception
            return null;
        }
        GameObject card = Instantiate(cardPrefab, position, Quaternion.identity);
        CardScript script = card.GetComponent(typeof(CardScript)) as CardScript;
        script.Init(_allCharacters[name]);
        card.transform.SetParent(transform);
        card.transform.localPosition = position;
        card.transform.parent = parent;
        card.transform.localScale = new Vector3(script.baseScale, script.baseScale, 1f);
        return card;
    }

    public List<string> getCardsNames()
    {
        List<string> result = new List<string>();
        foreach (var card in _allCharacters)
        {
            result.Add(card.Key);
        }
        return result;
    } 
    
}
