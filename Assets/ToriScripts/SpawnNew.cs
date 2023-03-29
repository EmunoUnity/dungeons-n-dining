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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Customer = Instantiate(New, transform.position, transform.rotation);
    }
}
