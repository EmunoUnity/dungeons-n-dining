using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody rb;

    private PlayKeys playKeys;

    private int dangerRange;
    public int enemyAttack;

    public GameObject attackCollider;

    private bool sigh, moving;

    public Animator minoAnim;

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
                moving = true;
                transform.LookAt(player.transform);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
            }

            if(moving == true && sigh == false)
            {
                minoAnim.Play("MINO_WALK");
            }
        }

            
     
    }

    private IEnumerator Mino()
    {
        moving = false;
        sigh = true;
        attackCollider.SetActive(true);
        minoAnim.Play("Mino_Attack");
        yield return new WaitForSeconds(5);
        attackCollider.SetActive(false);
        sigh = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            StartCoroutine(MinoDeath());
        }

       
    }

    private IEnumerator MinoDeath()
    {
        minoAnim.Play("Mino_Death");
        yield return new WaitForSeconds(1.25f);
        Destroy(gameObject);
    }
}
