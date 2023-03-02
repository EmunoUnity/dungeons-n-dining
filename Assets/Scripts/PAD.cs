using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PAD : MonoBehaviour
{
    public float horizontalInput;
    public float verticleInput;
    public float speed = 5f;
    public float rotationSpeed = 2f;

    public Animator animator1;


    public bool canbeHit, isDashing, isMoving, imtrue1, imtrue2, imtrue3;

    public MeshRenderer meshRend;

    public Transform target;
    public int distance = 20;
    public GameObject test;
    public GameObject player;

    public GameObject image1, image2, image3;

    // Start is called before the first frame update
    void Start()
    {
        animator1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;


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
        if (gamepad.circleButton.wasPressedThisFrame && isMoving == true && isDashing == false)
        {
            StartCoroutine(Dash());
        }



        if (gamepad.circleButton.wasPressedThisFrame && isMoving == true && isDashing == true)
        {

            if (isDashing == true)
            {
                isDashing = false;
                canbeHit = true;
            }
        }


        if (horizontalInput == 0 && verticleInput == 0)
        {
            isMoving = false;
            animator1.SetBool("Walk", false);
        }
        else
        {
            isMoving = true;
            animator1.SetBool("Walk", true);
        }

        if (canbeHit == false)
        {

        }

        if (isDashing == true)
        {
            speed = 15;
            animator1.SetBool("Run", true);

        }
        else
        {
            speed = 5;
            animator1.SetBool("Run", false);
        }

        //Attacking

        if (gamepad.squareButton.wasPressedThisFrame)
        {
            animator1.Play("ATTACK");
        }

        if (gamepad.rightShoulder.wasPressedThisFrame)
        {
            animator1.Play("ROLL");
        }
    }



    IEnumerator Dash()
    {
        canbeHit = false;
        yield return new WaitForSeconds(.01f);
        isDashing = true;
        yield return new WaitForSeconds(1);
        canbeHit = true;
        isDashing = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            image1.SetActive(true);
            imtrue1 = true;

        }

        if (collision.gameObject.CompareTag("Food") && imtrue1 == true)
        {
            image2.SetActive(true);
            imtrue2 = true;
        }

        if (collision.gameObject.CompareTag("Food") && imtrue1 == true && imtrue2 == true)
        {
            image3.SetActive(true);
            imtrue3 = true;
        }
    }


}
