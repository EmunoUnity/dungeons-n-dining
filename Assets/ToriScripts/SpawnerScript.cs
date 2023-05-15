using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Mino;
    public GameObject Medu;
    //public int x;
    private int y;
    public bool spawn;

    public bool test;
    public bool moreTest;

    public int monsterPicker;

    private GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        //x = 0;
        y = 1;
        monsterPicker = Random.Range(1, 3);

        spawn = false;
        moreTest = false;

        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {

        if(spawn)
        {
            monsterPicker = Random.Range(1, 3);
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
        if (monsterPicker == 1)
        {
            Monster = Instantiate(Mino, transform.position, transform.rotation);
            Monster.transform.SetParent(transform);
            Monster.name = "Minotaur";
            y++;
            spawn = false;
        }
        else if(monsterPicker == 2)
        {
            Monster = Instantiate(Medu, transform.position, transform.rotation);
            Monster.transform.SetParent(transform);
            Monster.name = "Medusa";
            y++;
            spawn = false;
        }
    }

    public IEnumerator SpawnDelay()
    {
        Debug.Log("Working");
        yield return new WaitForSeconds(30);
        spawn = true;
        
    }
}
