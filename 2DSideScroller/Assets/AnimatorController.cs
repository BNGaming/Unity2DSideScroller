using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    public Animator animator;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
    }
	
    public void SetParameter(string parameter, float val)
    {
        animator.SetFloat(Animator.StringToHash(parameter), val);
    }
    public void SetParameter(string parameter, int val)
    {
        animator.SetInteger(Animator.StringToHash(parameter), val);
    }
    public void SetParameter(string parameter, bool val)
    {
        animator.SetBool(Animator.StringToHash(parameter), val);
    }
    public void SetTrigger(string parameter)
    {
        animator.SetTrigger(Animator.StringToHash(parameter));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
