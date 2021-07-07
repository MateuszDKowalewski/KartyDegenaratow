using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class QuestGoal
{
    public GoalType goalType;
    public int potrzebnaIlosc;
    public int posiadanaIlosc;

    public bool czyUkonczony()
    {
        return (potrzebnaIlosc >= posiadanaIlosc);
    }
}

public enum GoalType
{
    quest,
    quest1,
    quest2
}
