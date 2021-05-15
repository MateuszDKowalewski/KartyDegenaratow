using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barkaQuest : Quest
{
    //public Quest Quest;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (isActive == true)
        {
            Debug.Log("OOOOOOOOOO PAAAANIEEEE, TO TY NA MNIE SPOOOOOOJRZAAAŁEEEŚ");
            Debug.Log("Brawo, zaśpiewałeś barkę z papieżem");
            questwindow.SetActive(false);
        }
        else if (isActive == false)
        {
            questwindow.SetActive(true);
            titleText.text = title;
            descriptionText.text = description;
        }
    }
}
