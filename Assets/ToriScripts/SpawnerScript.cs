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
    public bool moreTest;

    private GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        //x = 0;
        y = 1;

        spawn = false;
        moreTest = false;

        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {

        if(spawn)
        {
            SpawnMonster();
        }

        if (moreTest)
        {
            StartCoroutine(SpawnDelay());
            moreTest = false;
        }

        if (test)
        {
            Destroy(Monster);
        }

        
    }

    void SpawnMonster()
    {
        Monster = Instantiate(Spawner, transform.position, transform.rotation);
        Monster.transform.SetParent(transform);
        Monster.name = "Minotaur";
        y++;
        spawn = false;
    }

    public IEnumerator SpawnDelay()
    {
        Debug.Log("Working");
        yield return new WaitForSeconds(30);
        spawn = true;
        
    }
}
