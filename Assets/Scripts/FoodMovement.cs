using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 0;

    public bool onePickup, twoPickup, threePickup = false;
    public bool isDashing;
    public Transform pickupOne, pickupTwo, pickupThree;

    private PlayerController pController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (isDashing == true)
        {
            step = step * 3;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash1());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speed = 4.75f;
            pickupOne = other.transform;
            onePickup = true;
        }
        
    }

    IEnumerator Dash1()
    {

        isDashing = true;
        yield return new WaitForSeconds(1);
        isDashing = false;
    }

}
