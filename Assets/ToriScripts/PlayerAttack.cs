using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public BoxCollider wepCollider;
    public PlayKeys playKeys;

    private GameObject player;

    // Start is called before the first frame update

    //public GameObject hand;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playKeys = player.GetComponent<PlayKeys>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playKeys.attack1 == true || playKeys.attack2 == true || playKeys.attack3 == true)
        {
            wepCollider.enabled = true;
        }
        else
        {
            wepCollider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Requested" || collision.gameObject.tag == "Roaming")
        {
            Debug.Log("I have hit the Enemy!!");
        }
    }
}
