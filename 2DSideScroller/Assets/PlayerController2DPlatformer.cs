using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    up,
    down,
    left,
    right
}

public class PlayerController2DPlatformer : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    private Rigidbody2D PlayerBody;
    public bool landed = false;

    private Dictionary<Direction, EdgeCollider2D> EdgeTriggers = new Dictionary<Direction, EdgeCollider2D>();

	// Use this for initialization
	void Start () {
        PlayerBody = GetComponent<Rigidbody2D>();
        EdgeTriggers[Direction.up] = transform.Find("EdgeTriggers/TopTrigger").gameObject.GetComponent<EdgeCollider2D>();
        EdgeTriggers[Direction.down] = transform.Find("EdgeTriggers/BottomTrigger").gameObject.GetComponent<EdgeCollider2D>();
        EdgeTriggers[Direction.left] = transform.Find("EdgeTriggers/LeftTrigger").gameObject.GetComponent<EdgeCollider2D>();
        EdgeTriggers[Direction.right] = transform.Find("EdgeTriggers/RightTrigger").gameObject.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        print(1 << LayerMask.NameToLayer("Ground"));
        if (EdgeTriggers[Direction.down].IsTouchingLayers(1 << LayerMask.NameToLayer("Ground")))
        {
            landed = true;
        }
		if (landed && Input.GetKeyDown(KeyCode.Space))
        {
            landed = false;
            PlayerBody.velocity += Vector2.up * jumpHeight;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Vector2 velocity = PlayerBody.velocity;
            velocity.x = 0;
            
            if (Input.GetKey(KeyCode.D))
            {
                velocity.x += Vector2.right.x * moveSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x += Vector2.left.x * moveSpeed;
            }
            PlayerBody.velocity = velocity;
        }

	}
}
