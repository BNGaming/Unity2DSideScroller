using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamage : MonoBehaviour {

    public int Damage;


	// Use this for initialization
	void Start () {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Entities"))
        {
            HasHealth hasHealth = collision.gameObject.GetComponent<HasHealth>();
            if (hasHealth != null) { hasHealth.Damage(Damage); }
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
