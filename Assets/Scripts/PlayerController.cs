using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticleInput;
    public float speed = 5f;

    public bool canbeHit, isDashing, isMoving;

    public MeshRenderer meshRend;

    public Transform target;
    public int distance = 20;
    public GameObject test;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        

        //BasicPlayerMovement
        horizontalInput = Input.GetAxis("Horizontal");
        verticleInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.left * verticleInput * Time.deltaTime * speed);

        //Dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && isMoving == true)
        {
            StartCoroutine(Dash());
        }

      

        if ( horizontalInput == 0 && verticleInput == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (canbeHit == false)
        {

        }

        if(isDashing == true)
        {
            speed = 15;
        }
        else
        {
            speed = 5;
        }

        //Attacking

        
    }

    

    IEnumerator Dash()
    {
        canbeHit = false;
        isDashing = true;
        yield return new WaitForSeconds(1);
        canbeHit = true;
        isDashing = false;
    }

    
}
