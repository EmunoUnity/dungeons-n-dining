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

    
    // Start is called before the first frame update
    void Start()
    {
        Minotaur = false;
        Gorgon = false;
        Cyclops = false;

        drop = string.Empty;
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
            drop = "Monster 1";
        }
        
    }
}
