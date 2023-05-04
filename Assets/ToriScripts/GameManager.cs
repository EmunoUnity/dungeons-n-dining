using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Minotaur;
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
        if (Minotaur)
        {
            drop = "Mino_Rig";
        }
    }
}
