using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barkaQuest : Quest
{
    public Quest Quest;

    public void papajQuestAktywacja(Collision2D col)
    {
        if (Quest.isActive == true)
        {
            Debug.Log("OOOOOOOOOO PAAAANIEEEE, TO TY NA MNIE SPOOOOOOJRZAAAŁEEEŚ");
            Debug.Log("Brawo, zaśpiewałeś barkę z papieżem");
            Quest.isActive = false;
        }
    }
}
