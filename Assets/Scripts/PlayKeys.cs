using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayKeys : MonoBehaviour
{
    public float horizontalInput;
    public float verticleInput;
    public float speed = 5f;
    public float rotationSpeed = 2f;

    public bool canbeHit1, isDashing1, isRolling, isMoving, attack1, attack2, attack3, canRoll, secondAttack;

    public Animator animator;

    public Transform target1;
    public int distance = 20;
    public GameObject test;
    public GameObject player;
    public GameObject weapon;

   




    // Start is called before the first frame update
    void Start()
    {
        canbeHit1 = true; //edited by Tori
    }

    // Update is called once per frame
    void Update()
    {




        //BasicPlayerMovement
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticleInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Vertical");
        verticleInput = Input.GetAxis("Horizontal");


        Vector3 movementDirection = new Vector3(-horizontalInput, 0, verticleInput);
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

        if (isDashing1== true && isRolling == false)
        {
            speed = 15;
            animator.SetBool("Run", true);

        }
        else
        {
            speed = 5;
            animator.SetBool("Run", false);

        }

        if (isRolling == true)
        {
            speed = 20;
        }
       

        //Attacking

        if (Input.GetKeyDown(KeyCode.Mouse0) && attack1 == false && attack2 == false && attack3 == false)
        {
            StartCoroutine(AttackCycle());
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && attack1 == true && attack2 == false)
        {
            StartCoroutine(AttackCycleSecond());
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && attack1 == false && attack2 == true && attack3 == false && secondAttack == false)
        {
            StartCoroutine(AttackCycleOver());
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canRoll == true && isRolling == false)
        {
            
            StartCoroutine(RollMech());
        }


    }



    IEnumerator Dash1()
    {
        isDashing1 = true;
        yield return new WaitForSeconds(1);
        isDashing1 = false;
    }

    IEnumerator AttackCycle()
    {
        animator.Play("ATTACK");
        yield return new WaitForSeconds(.1f);
        
        attack1 = true;
        yield return new WaitForSeconds(.4f);
        
        attack1 = false;

    }

    IEnumerator AttackCycleSecond()
    {
        animator.Play("LEFT_ATTACK");
        attack1 = false;
        secondAttack = true;
        yield return new WaitForSeconds(.2f);
        
        attack2 = true;
        yield return new WaitForSeconds(.1f);
        secondAttack = false;
        yield return new WaitForSeconds(.3f);
        
        attack2 = false;
        
    }

    IEnumerator AttackCycleOver()
    {
        animator.Play("OVERHEAD");
        attack2 = false;
        yield return new WaitForSeconds(.2f);
        
        attack3 = true;
        yield return new WaitForSeconds(.5f);
        
        attack3 = false;
    }

    IEnumerator RollMech()
    {
        isRolling = true;
        animator.Play("ROLL");
        canbeHit1 = false;
        Debug.Log("Do a Barrel Roll!");
        yield return new WaitForSeconds(.5f);
        canbeHit1 = true;
        isRolling = false;
        canRoll = false;
        yield return new WaitForSeconds(5);
        canRoll = true;
        
    }
}
