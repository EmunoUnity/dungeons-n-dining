using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject hand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = hand.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Requested" || collision.gameObject.tag == "Roaming")
        {
            Debug.Log("I have hit the Enemy!!");
        }
    }
}
