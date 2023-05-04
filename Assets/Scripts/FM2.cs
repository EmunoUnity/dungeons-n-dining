using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class FM2 : MonoBehaviour
{
    private GameObject target;
    private float speed = 60;
    public GameManager manager;

    private Transform pickupOne, pickupTwo, pickupThree;

    private PlayerController pController;

    private FoodMovement fMove;

    public bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        if (isDashing == true)
        {
            step = step * 3;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash2());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.Minotaur = true;
            speed = 10f;
            pickupTwo = other.transform;
        }

        if(other.gameObject.CompareTag("Diner"))
        {
            Destroy(gameObject);
        }

    }

    IEnumerator Dash2()
    {

        isDashing = true;
        yield return new WaitForSeconds(1);
        isDashing = false;
    }
}
