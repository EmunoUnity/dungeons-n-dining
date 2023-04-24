using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestingFood : MonoBehaviour
{
    private GameObject meal;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        meal = GameObject.FindGameObjectWithTag("Roaming");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(meal);

        if(meal.GetComponent<Requested>().open == 0)
        {
            meal.GetComponent<Requested>().open = 1;
            Debug.Log(meal);
        }

        if (Vector3.Distance(this.transform.position, player.transform.position) <= 3)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("I am ordering the " + meal);
            }
        }
    }
}
