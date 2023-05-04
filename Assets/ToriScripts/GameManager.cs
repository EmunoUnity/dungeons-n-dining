using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Minotaur;
    private int mini;

    public bool Gorgon;
    public bool Cyclops;

    public string drop;
    // Start is called before the first frame update
    void Start()
    {
        Minotaur = false;
        Gorgon = false;
        Cyclops = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Minotaur == true)
        {
            mini++;
            Minotaur = false;
        }

        if(mini == 1) 
        {
            drop = "Mino_Rig";
            mini = 0;
        }
        else if (mini == 2)
        {
            drop = "Mino_Rig";
            mini = 1;
        }
        else if (mini == 3)
        {
            drop = "Mino_Rig";
            mini = 2;
        }
        else if (mini == 4)
        {
            mini = 3;
        }
        
    }
}
