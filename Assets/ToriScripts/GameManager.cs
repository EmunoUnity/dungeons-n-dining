using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool Minotaur;
    public int mini;
    public string drop;

    public bool Gorgon;
    public bool Cyclops;

    private int GoalMoney;
    public int GoalAmount;

    public TextMeshProUGUI goaly;


    // Start is called before the first frame update
    void Start()
    {
        Minotaur = false;
        Gorgon = false;
        Cyclops = false;

        drop = string.Empty;
        GoalMoney = Random.Range(2000, 3690);
        GoalAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        goaly.text = GoalAmount + " / " + GoalMoney;

        if (Minotaur == true)
        {
            mini++;
            Minotaur = false;
        }

        if(mini <= 1) 
        {
            drop = "Minotaur";
            //drop = "Mino_UnWrapped";
        }

        if(GoalAmount == GoalMoney)
        {
            Debug.Log("You win!");
        }
        
    }
}
