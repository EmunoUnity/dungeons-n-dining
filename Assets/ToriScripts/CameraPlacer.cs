using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacer : MonoBehaviour
{
    private Transform placer;
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        placer = transform.Find("CameraPlacer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mainCamera.transform.position = placer.position;
        }
    }
}
