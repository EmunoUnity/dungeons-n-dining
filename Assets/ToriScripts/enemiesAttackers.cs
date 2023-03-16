using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesAttackers : MonoBehaviour
{
    private Heart hitsss;
    private PlayKeys playKeys;
    // Start is called before the first frame update
    void Start()
    {
        hitsss = FindObjectOfType<Heart>();
        playKeys = FindObjectOfType<PlayKeys>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && playKeys.canbeHit1 == true)
        {
            Debug.Log("I have hit the player!!");
            hitsss.myHeath -= 1;
        }
    }
}
