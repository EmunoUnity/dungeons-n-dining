using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requested : MonoBehaviour
{
    // Start is called before the first frame update
    public int open;
    void Start()
    {
        open = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (open == 1)
        {
            gameObject.tag = "Requested";
            open = 2;
        }
    }
}
