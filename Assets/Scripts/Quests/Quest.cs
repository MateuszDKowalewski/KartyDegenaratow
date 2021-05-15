using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Quest : MonoBehaviour
{
    public bool isActive = false;

    public string title;
    public string description;

    public PlayerStats statstyki;
    public QuestGoal goal;

    public GameObject questwindow;
    public Text titleText;
    public Text descriptionText;


    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.collider.name);

        if (isActive == false)
         {
            questwindow.SetActive(true);
            titleText.text = title;
            descriptionText.text = description;
         }

    }

    public void AcceptQuest()
    {
        Debug.Log("dzialam");
        questwindow.SetActive(false);
        isActive = true;
        
    }



}