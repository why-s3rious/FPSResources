using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBomber : Zombie
{
    // Start is called before the first frame update
    public override void InitZombie(float health, float damage, float distant, float percentageBoost, float frequency)
    {
        base.InitZombie(health, damage, distant, percentageBoost, frequency);
        this.InitAbility(damage, distant, percentageBoost, frequency, FrequencyType.ONCE, AbilityType.BOMBER);

    }
    protected override void OnDead()
    {
        this.Explode();
        base.OnDead();
        
    }

}
