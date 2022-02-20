using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBomber : Ability
{
    protected override void Tick()
    {
        base.Tick();
        GameObject ob = GameObject.FindGameObjectWithTag("Player");
        ob.GetComponent<Mob>().TakeDamage(this.damage);
        this.zombie.TakeDamage(this.zombie.GetCurrentHealth());
    }
}
