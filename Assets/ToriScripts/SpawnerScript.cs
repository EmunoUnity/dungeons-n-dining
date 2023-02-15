using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Spawner;
    //public int x;
    private int y;
    public bool spawn;

    public bool test;
    private bool moreTest;

    private GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        //x = 0;
        y = 1;

        spawn = false;
        moreTest = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn)
        {
            SpawnMonster();
        }

        if (Monster == null && moreTest)
        {
            StartCoroutine(SpawnDelay());
            moreTest = false;
        }

        if (test)
        {
            Destroy(Monster);
            moreTest = true;
            test = false;
            
        }

        
    }

    void SpawnMonster()
    {
        Monster = Instantiate(Spawner, transform.position, transform.rotation);
        Monster.name = "Monster " + y;
        y++;
        spawn = false;
    }

    private IEnumerator SpawnDelay()
    {
        Debug.Log("Working");
        yield return new WaitForSeconds(10);
        spawn = true;
        
    }
}
