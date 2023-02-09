using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FM3 : MonoBehaviour
{
    public Transform target;
    public float speed = 0;

    private Transform pickupOne, pickupTwo, pickupThree;

    private PlayerController pController;

    private FoodMovement fMove;
    public bool isDashing;

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
            StartCoroutine(Dash3());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speed = 2.5f;
            pickupTwo = other.transform;
        }

    }

    IEnumerator Dash3()
    {
        isDashing = true;
        yield return new WaitForSeconds(1);
        isDashing = false;
    }
}
