using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool Minotaur;
    public int mini;

    public string drop;
    public string drop2;

    public bool Gorgon;
    public int gor;

    public bool Cyclops;

    private int GoalMoney;
    public int GoalAmount;

    public TextMeshProUGUI goaly;

    public Slider timer;
    private float number;
    public bool pause;



    // Start is called before the first frame update
    void Start()
    {
        Minotaur = false;
        Gorgon = false;
        Cyclops = false;

        drop = string.Empty;
        drop2 = string.Empty;
        GoalMoney = Random.Range(2000, 3690);
        GoalAmount = 0;

        timer.maxValue = 360;
        number = 360;

        mini = 0;

        pause = false;
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

        if (Gorgon == true)
        {
            gor++;
            Gorgon = false;
        }

        if (mini < 0)
        {
            mini = 0;
        }

        if (gor < 0)
        {
            gor = 0;
        }


        if (mini >= 1) 
        {
            drop = "Minotaur";
            //drop = "Mino_UnWrapped";
        }

        if (gor >= 2)
        {
            drop2 = "Medusa";
        }

        if (GoalAmount == GoalMoney)
        {
            Debug.Log("You win!");
            SceneManager.LoadScene("win");
        }

        
        
    }

    private void FixedUpdate()
    {
        if (number > 0 && !pause)
        {
            number -= Time.deltaTime;
            timer.value = number;
        }
        else if (number <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
