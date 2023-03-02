using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayKeys : MonoBehaviour
{
    public float horizontalInput;
    public float verticleInput;
    public float speed = 5f;
    public float rotationSpeed = 2f;

    public bool canbeHit1, isDashing1, isMoving;

    public Animator animator;

    public Transform target1;
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

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticleInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        //Rotation
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && isMoving == true && isDashing1 == false)
        {
            StartCoroutine(Dash1());
        }



        if (Input.GetKeyDown(KeyCode.LeftShift) && isMoving == true && isDashing1 == false)
        {

            if (isDashing1 == true)
            {
                isDashing1 = false;
                canbeHit1 = true;
            }
        }


        if (horizontalInput == 0 && verticleInput == 0)
        {
            isMoving = false;
            animator.SetBool("Walk", false);
        }
        else
        {
            isMoving = true;
            animator.SetBool("Walk", true);
        }

        if (canbeHit1== false)
        {

        }

        if (isDashing1== true)
        {
            speed = 15;
            animator.SetBool("Run", true);

        }
        else
        {
            speed = 5;
            animator.SetBool("Run", false);

        }

        //Attacking

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("ATTACK");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.Play("ROLL");
        }


    }



    IEnumerator Dash1()
    {
        canbeHit1 = false;
        yield return new WaitForSeconds(.01f);
        isDashing1 = true;
        yield return new WaitForSeconds(1);
        canbeHit1 = true;
        isDashing1 = false;
    }
}
