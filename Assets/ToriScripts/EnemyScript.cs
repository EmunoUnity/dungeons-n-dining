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

    private bool sigh, moving, isHit;

    public Animator minoAnim;

    public int health = 100;

    public bool isDead = false;

    public GameObject minoPart;
    public GameObject minoDrop;

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
    void FixedUpdate()
    {
            if (Vector3.Distance(this.transform.position, player.transform.position) <= dangerRange)
        {
            //Debug.Log("Player in range");

            if (Vector3.Distance(this.transform.position, player.transform.position) <= enemyAttack)
            {
                if (enemyAttack == 3 && !sigh && isHit == false && isDead == false)
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
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .12f);
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
        yield return new WaitForSeconds(1);
        attackCollider.SetActive(false);
        yield return new WaitForSeconds(2);
        sigh = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weapon" && health != 0 && isDead == false)
        {
            StartCoroutine(MinoHit());
        }

        if (collision.gameObject.tag == "Weapon" && health <= 0 && isDead == false)
        {
            StartCoroutine(MinoDeath());
        }

       
    }

    private IEnumerator MinoHit()
    {
        isHit = true;
        minoAnim.Play("Mino_Hit");
        yield return new WaitForSeconds(.5f);
        isHit = false;
        health -= 25;
    }

    private IEnumerator MinoDeath()
    {
        isDead = true;
        minoAnim.Play("Mino_Death");
        yield return new WaitForSeconds(.75f);
        Instantiate(minoPart, gameObject.transform.position, minoPart.transform.rotation);
        Instantiate(minoDrop, gameObject.transform.position, minoPart.transform.rotation);
        yield return new WaitForSeconds(.05f);
        Destroy(gameObject);
    }
}
