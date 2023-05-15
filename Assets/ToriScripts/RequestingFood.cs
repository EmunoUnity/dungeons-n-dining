using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestingFood : MonoBehaviour
{
    private GameObject meal;
    private GameObject player;
    private bool ordered;
    private string dinner;
    public bool leave;

    public FoodMore food;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //meal = GameObject.FindGameObjectWithTag("Roaming");
        player = GameObject.FindGameObjectWithTag("Player");
        ordered = false;

        gameManager = FindObjectOfType<GameManager>();

        food = FindObjectOfType<FoodMore>();

        leave = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(meal);

        if (dinner == "Minotaur")
        {
            food.mino = true;
        }

        if (dinner == "Medusa")
        {
            food.medu = true;
        }

        if (Vector3.Distance(this.transform.position, player.transform.position) <= 5)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!ordered)
                {
                    meal = GameObject.FindGameObjectWithTag("Roaming");
                    if (meal.GetComponent<Requested>().open == 0)
                    {
                        meal.GetComponent<Requested>().open = 1;
                    }

                    Debug.Log("I am ordering the " + meal);
                    dinner = meal.name;

                    ordered = true;
                }
                else if(ordered && (gameManager.drop == dinner || gameManager.drop2 == dinner))
                {
                    if (dinner == "Minotaur")
                    {
                        gameManager.mini--;
                        Debug.Log("Thank you!");
                        transform.position = new Vector3(100, 100, 100);
                        gameManager.drop = "";
                        gameManager.GoalAmount += 200;
                        leave = true;
                    }
                    else if (dinner == "Medusa")
                    {
                        gameManager.gor--;
                        Debug.Log("Thank you!");
                        transform.position = new Vector3(100, 100, 100);
                        gameManager.drop2 = "";
                        gameManager.GoalAmount += 200;
                        leave = true;
                    }
                    
                }
                else
                {
                    Debug.Log("Get me Food!");
                }
            }
        }
    }
}
