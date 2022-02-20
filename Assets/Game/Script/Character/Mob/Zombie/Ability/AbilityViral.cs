using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityViral : Ability
{

    protected override void Tick()
    {
        //Viral will run faster and damage harder
        // run fast 
        this.zombie.GetAgent().speed = this.zombie.GetAgent().speed * this.percentageBoost;
        this.zombie.SetDamage(this.damage);
        // punch hard
        
    }

}
