using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour {

    public int Health;
    public int Max;
    public int IFrames;
    public int FlickerFrames;
    public int FlickerHalfPeriod;
    public bool Vulnerable;

    private bool isTakingDamage = false;
    private int damageToTake = 0;

    private bool isHealing = false;
    private int healingToTake = 0;

    private int IFrameCounter = 0;
    public int FlickerCounter = 0;

    SpriteRenderer sprite;
    public bool isSpriteEnabled = true;
    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Damage(int val)
    {
        if (Vulnerable && IFrameCounter == 0)
        {
            isTakingDamage = true;
            damageToTake += val;
        }
    }

    public void Heal(int val) {
        isHealing = true;
        healingToTake += val;
    }

	// Update is called once per frame
	void Update () {
        IFrameCounter = (IFrameCounter > 0) ? IFrameCounter - 1 : IFrameCounter;
        
        if (FlickerCounter > 0)
        {
            if (FlickerCounter % FlickerHalfPeriod == 0)
            {
                isSpriteEnabled = !isSpriteEnabled;
                sprite.enabled = isSpriteEnabled;
            }
            FlickerCounter -= 1;
        }
        else
        {
            sprite.enabled = true;
            isSpriteEnabled = true;
        }

		if (isTakingDamage)
        {
            Health = (Health - damageToTake < 0) ? 0 : Health - damageToTake;
            damageToTake = 0;
            isTakingDamage = false;
            IFrameCounter = IFrames;
            FlickerCounter = FlickerFrames;
        }
        if (isHealing)
        {
            Health = (Health + healingToTake > Max) ? Max : Health + healingToTake;
            healingToTake = 0;
            isHealing = false;
        }
	}
}
