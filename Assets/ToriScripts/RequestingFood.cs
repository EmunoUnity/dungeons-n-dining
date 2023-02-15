using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestingFood : MonoBehaviour
{
    private GameObject meal;
    // Start is called before the first frame update
    void Start()
    {
        meal = GameObject.FindGameObjectWithTag("Roaming");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(meal);

        if(meal.GetComponent<Requested>().open == 0)
        {
            meal.GetComponent<Requested>().open = 1;
            Debug.Log(meal);
        }
    }
}
