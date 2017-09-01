using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpcastCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        SendMessageUpwards("OnCollisionStayFromChild2D", collision, SendMessageOptions.DontRequireReceiver);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SendMessageUpwards("OnCollisionStayFromEnter2D", collision, SendMessageOptions.DontRequireReceiver);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SendMessageUpwards("OnCollisionStayExitChild2D", collision, SendMessageOptions.DontRequireReceiver);
    }
}
