using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBomber : Ability
{
    protected override void Tick()
    {
        GameObject ob = GameObject.FindGameObjectWithTag("Player");
        this.zombie.TakeDamage(this.zombie.GetCurrentHealth());
        ob.GetComponent<Mob>().TakeDamage(this.damage);
    }
}
