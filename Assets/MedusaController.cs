using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody rb;

    private PlayKeys playKeys;

    private int dangerRange;
    public int enemyAttack;

    public GameObject attackCollider;

    private bool sigh, moving, isHit;

    public Animator medAnim;

    public int health = 100;

    public bool isDead = false;

    public GameObject medPart;
    public GameObject medDrop;

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

                    StartCoroutine(Medu());
                }
            }
            else
            {
                moving = true;
                transform.LookAt(player.transform);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .12f);
            }

            if (moving == true && sigh == false)
            {
                medAnim.Play("MED_WALK");
            }
        }



    }

    private IEnumerator Medu()
    {
        moving = false;
        sigh = true;
        attackCollider.SetActive(true);
        medAnim.Play("MED_KICK");
        yield return new WaitForSeconds(1);
        attackCollider.SetActive(false);
        yield return new WaitForSeconds(2);
        sigh = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon" && health != 0 && isDead == false)
        {
            StartCoroutine(MedHit());
        }

        if (collision.gameObject.tag == "Weapon" && health <= 0 && isDead == false)
        {
            StartCoroutine(MedDeath());
        }


    }

    private IEnumerator MedHit()
    {
        isHit = true;
        medAnim.Play("MED_KICK2");
        yield return new WaitForSeconds(.5f);
        isHit = false;
        health -= 25;
    }

    private IEnumerator MedDeath()
    {
        isDead = true;
        medAnim.Play("MED_Death");
        yield return new WaitForSeconds(.75f);
        Instantiate(medPart, gameObject.transform.position, medPart.transform.rotation);
        Instantiate(medDrop, gameObject.transform.position, medPart.transform.rotation);
        yield return new WaitForSeconds(.05f);
        Destroy(gameObject);
    }
}
