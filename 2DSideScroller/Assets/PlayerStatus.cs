using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int health = 6;
    public int maxHealth = 6;
    public bool isAlive { get; private set; }

    public void Awake()
    {
        isAlive = true;
    }

    public void Damage(int amount)
    {
        health -= amount;
        if ( health <= 0)
        {
            health = 0;
            isAlive = false;
        }
    }

    public void Heal(int amount)
    {
        health = (health + amount > maxHealth) ? maxHealth : health + amount;
        if ( health >= 0)
        {
            isAlive = true;
        }
    }
}
