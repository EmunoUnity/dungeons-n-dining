using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    private int dangerRange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        dangerRange = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= dangerRange)
        {
            Debug.Log("Player in range");

            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
