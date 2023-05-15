using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryingAgainFood : MonoBehaviour
{
    public bool mino;
    public bool medu;

    public Image steak;
    public Image bowl;

    public int managae;
    // Start is called before the first frame update
    void Start()
    {
        mino = false;
        medu = false;

        steak.enabled = false;
        bowl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mino && managae > 0)
        {
            steak.enabled = true;
        }
        else if(!mino)
        {
            steak.enabled = false;
        }

        if (medu && managae > 0)
        {
            bowl.enabled = true;
        }
        else if (!medu)
        {
            bowl.enabled = false;
        }
    }
}
