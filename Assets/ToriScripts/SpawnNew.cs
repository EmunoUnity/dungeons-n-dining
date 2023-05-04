using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNew : MonoBehaviour
{
    private GameObject Customer;
    public GameObject New;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyUp(KeyCode.K))
        {
            Spawn();
        }*/
        
        if(Customer.GetComponent<RequestingFood>().leave == true) 
        { 
            Spawn(); 
        }
    }

    void Spawn()
    {
        Customer = Instantiate(New, transform.position, transform.rotation);
    }
}
