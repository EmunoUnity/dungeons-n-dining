using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestingFood : MonoBehaviour
{
    private GameObject meal;
    private GameObject player;
    private bool ordered;
    private string dinner;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        meal = GameObject.FindGameObjectWithTag("Roaming");
        player = GameObject.FindGameObjectWithTag("Player");
        ordered = false;

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(meal);

        if (Vector3.Distance(this.transform.position, player.transform.position) <= 3)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!ordered)
                {
                    if (meal.GetComponent<Requested>().open == 0)
                    {
                        meal.GetComponent<Requested>().open = 1;
                    }

                    Debug.Log("I am ordering the " + meal);
                    dinner = meal.name;
                    ordered = true;
                }
                else if(ordered && gameManager.drop == dinner)
                {
                    Debug.Log("Thank you!");
                }
            }
        }
    }
}
