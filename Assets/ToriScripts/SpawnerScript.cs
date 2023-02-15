using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Spawner;
    //public int x;
    private int y;
    public bool spawn;
    // Start is called before the first frame update
    void Start()
    {
        //x = 0;
        y = 1;

        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn)
        {
            GameObject gameObject = Instantiate(Spawner, transform.position, transform.rotation);
            gameObject.name = "Monster " + y;
            y++;
            spawn = false;
        }
    }
}
