using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodMore : MonoBehaviour
{

    public Image Bowl;
    public Image Steak;

    public bool mino;
    public bool medu;

    // Start is called before the first frame update
    void Start()
    {
        Bowl.enabled = false;
        Steak.enabled = false;

        mino = false;
        medu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mino == true)
        {
            Steak.enabled = true;
        }

        if(medu == true)
        {
            Bowl.enabled = true;
        }
    }
}
