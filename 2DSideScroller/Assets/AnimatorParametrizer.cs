using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParametrizer : MonoBehaviour {

    AnimatorController animatorController;
    Rigidbody2D PlayerBody;

    bool facingRight = true;

    // Use this for initialization
    void Start () {
        animatorController = GetComponent<AnimatorController>();
        PlayerBody = GetComponent<Rigidbody2D>();
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Update is called once per frame
    void FixedUpdate () {
        animatorController.SetParameter("Speed", Mathf.Abs(PlayerBody.velocity.x));
        if (PlayerBody.velocity.x > 0 && !facingRight) { Flip(); }
        else if (PlayerBody.velocity.x < 0 && facingRight) { Flip(); }
    }

}
