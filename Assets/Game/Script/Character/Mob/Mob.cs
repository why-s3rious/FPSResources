using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    // Start is called before the first frame update
    protected float health;
    protected bool isDead = false;


    public void Init(float health)
    {
        this.health = health;
    }
    public float GetCurrentHealth()
    {
        return this.health;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        health = health < 0 ? 0 : health; 
        if(health <= 0)
        {
            isDead = true;
            OnDead();
        }
    }
    public bool IsDead()
    {
        return isDead;
    }

    protected virtual void OnDead()
    {
    }


}
