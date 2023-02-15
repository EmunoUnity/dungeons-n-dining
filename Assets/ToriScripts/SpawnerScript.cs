using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Spawner;
    public int x;
    private int y;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(x == y)
        {
            GameObject gameObject = Instantiate(Spawner, transform.position, transform.rotation);
            gameObject.name = gameObject.name + " " + y;
            y++;
        }
    }
}
