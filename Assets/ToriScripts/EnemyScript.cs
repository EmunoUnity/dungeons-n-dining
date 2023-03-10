using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody rb;

    private int dangerRange;
    public int enemyAttack;

    public GameObject attackCollider;

    private bool sigh;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        //attackCollider = GetComponentInChildren<Collider>();

        attackCollider.SetActive(false);
        dangerRange = 15;

        sigh = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= dangerRange)
        {
            //Debug.Log("Player in range");

            if (Vector3.Distance(this.transform.position, player.transform.position) <= enemyAttack)
            {
                if(enemyAttack == 3 && !sigh)
                {
                    //Debug.Log("attacking Player");
                    rb.velocity = Vector3.zero;

                    StartCoroutine(Mino());
                }
            }
            else
            {
                transform.LookAt(player.transform);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
            }
        }
    }

    private IEnumerator Mino()
    {
        sigh = true;
        attackCollider.SetActive(true);
        yield return new WaitForSeconds(5);
        attackCollider.SetActive(false);
        sigh = false;
    }
}
