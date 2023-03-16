using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesAttackers : MonoBehaviour
{
    private Heart hitsss;
    // Start is called before the first frame update
    void Start()
    {
        hitsss = FindObjectOfType<Heart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I have hit the player!!");
            hitsss.myHeath -= 1;
        }
    }
}
