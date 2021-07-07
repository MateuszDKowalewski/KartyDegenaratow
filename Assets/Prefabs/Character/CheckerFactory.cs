using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerFactory : MonoBehaviour
{
    public GameObject CheckerPrefab;
    
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
            Debug.Log(prefab.code);
            _allCharacters.Add(prefab.code, prefab);
        }
    }

    public GameObject instantiateChecker(string name, Vector3 position, Vector3 scale)
    {
        if (!_allCharacters.ContainsKey(name))
        {
            return null;
        }
        GameObject checker = Instantiate(CheckerPrefab, position, Quaternion.identity);
        CheckerScript script = checker.GetComponent(typeof(CheckerScript)) as CheckerScript;
        script.initailize(_allCharacters[name]);
        checker.transform.SetParent(transform);
        checker.transform.localScale = scale;
        return checker;
    }

    public List<string> getCheckerNames()
    {
        List<string> result = new List<string>();
        foreach (var checker in _allCharacters)
        {
            result.Add(checker.Key);
        }
        return result;
    } 
    
    
}
