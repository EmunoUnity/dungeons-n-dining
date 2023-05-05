using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int myHeath;
    public int Harts;
    public Image[] Heahht;
    public Sprite full;
    public Sprite empty;

    private PlayKeys play;
    // Start is called before the first frame update
    void Start()
    {
        play = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayKeys>();
    }

    // Update is called once per frame
    void Update()
    {
        heartsystem();

        working();
    }

    public void heartsystem()
    {
        if(myHeath >= Harts)
        {
            myHeath = Harts;
        }

        if(myHeath <= 0)
        {
            myHeath = 0;

        }

        for (int i = 0; i < Heahht.Length; i++)
        {
            if(i < myHeath)
            {
                Heahht[i].sprite = full;
            }
            else
            {
                Heahht[i].sprite = empty;
            }

            if (i < Harts)
            {
                Heahht[i].enabled = true;
            }
            else
            {
                Heahht[i].enabled = false;
            }
        }
        
    }

    public void working()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            myHeath -= 1;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            myHeath += 1;
        }
    }
}
