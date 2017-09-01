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

public class VirtualPlayerController : MonoBehaviour
{


    public float moveSpeed;
    public float jumpHeight;

    private Rigidbody2D PlayerBody;
    public bool landed = false;
    private bool jump = false;

    private Dictionary<Direction, EdgeCollider2D> EdgeTriggers = new Dictionary<Direction, EdgeCollider2D>();

    // Use this for initialization
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        EdgeTriggers[Direction.up] = transform.Find("EdgeTriggers/TopTrigger").gameObject.GetComponent<EdgeCollider2D>();
        EdgeTriggers[Direction.down] = transform.Find("EdgeTriggers/BottomTrigger").gameObject.GetComponent<EdgeCollider2D>();
        EdgeTriggers[Direction.left] = transform.Find("EdgeTriggers/LeftTrigger").gameObject.GetComponent<EdgeCollider2D>();
        EdgeTriggers[Direction.right] = transform.Find("EdgeTriggers/RightTrigger").gameObject.GetComponent<EdgeCollider2D>();
    }

    public void HaltHorizontal()
    {
        Vector2 velocity = PlayerBody.velocity;
        velocity.x = 0;
        PlayerBody.velocity = velocity;
    }

    public void WalkRight()
    {
        Vector2 velocity = PlayerBody.velocity;
        velocity.x = Vector2.right.x * moveSpeed;
        PlayerBody.velocity = velocity;
    }

    public void WalkLeft()
    {
        Vector2 velocity = PlayerBody.velocity;
        velocity.x = Vector2.left.x * moveSpeed;
        PlayerBody.velocity = velocity;
    }

    public void Jump()
    {
        if (landed)
        {
            landed = false;
            jump = true;
        }
    }

    // Update is called once per frame
    // TODO: Make a collision handler class to do this
    void FixedUpdate()
    {
        if (EdgeTriggers[Direction.down].IsTouchingLayers(1 << LayerMask.NameToLayer("Ground")))
        {
            landed = true;
        }
        if (jump)
        {
            jump = false;
            PlayerBody.velocity += Vector2.up * jumpHeight;
        }
    }
}
