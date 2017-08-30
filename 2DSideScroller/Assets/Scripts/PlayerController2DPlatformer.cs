using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController2DPlatformer : MonoBehaviour
{

    VirtualPlayerController controller;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<VirtualPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D)) { controller.WalkRight(); }
            if (Input.GetKey(KeyCode.A)) { controller.WalkLeft(); }
        }
        else
        {
            controller.HaltHorizontal();
        }

        if (Input.GetKeyDown(KeyCode.Space)) { controller.Jump(); }
    }
}
