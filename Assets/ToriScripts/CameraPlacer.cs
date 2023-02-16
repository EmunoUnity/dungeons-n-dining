using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacer : MonoBehaviour
{
    private Transform placer;
    private GameObject mainCamera;

    public GameObject unseen;
    public GameObject sawSeen;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        placer = transform.Find("CameraPlacer");

        //unseen = GameObject.Find("MiniMapUnseen");
        //sawSeen = GameObject.Find("MiniMapSeen");

        unseen.SetActive(true);
        sawSeen.SetActive(false);
        
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

            sawSeen.SetActive(true);
            unseen.SetActive(false);

        }
    }
}