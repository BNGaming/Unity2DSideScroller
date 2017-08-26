using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerExactly : MonoBehaviour {

    GameObject player;

    public Vector3 Offset = Vector3.zero;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + Offset;
	}
}
