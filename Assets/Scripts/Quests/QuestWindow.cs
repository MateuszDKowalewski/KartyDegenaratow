using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class QuestWindow : MonoBehaviour
{
    public GameObject questwindow;
    // Start is called before the first frame update
    void Start()
    {

        questwindow = GameObject.Find("questwindow");
        if (questwindow != null)
        {
            Debug.Log("dzialam");
            questwindow.SetActive(false);
            Debug.Log("dzialam");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
