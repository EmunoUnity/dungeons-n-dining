using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Minotaur;
    public int mini;
    public string drop;

    public bool Gorgon;
    public bool Cyclops;

    private int GoalMoney;
    public int GoalAmount;


    // Start is called before the first frame update
    void Start()
    {
        Minotaur = false;
        Gorgon = false;
        Cyclops = false;

        drop = string.Empty;
        GoalMoney = 1000;
        GoalAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Minotaur == true)
        {
            mini++;
            Minotaur = false;
        }

        if(mini <= 1) 
        {
            //drop = "Monster 1";
            drop = "Mino_UnWrapped";
        }

        if(GoalAmount == GoalMoney)
        {
            Debug.Log("You win!");
        }
        
    }
}
