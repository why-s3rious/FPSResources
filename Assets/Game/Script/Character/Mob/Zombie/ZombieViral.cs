using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieViral : Zombie
{
    public override void InitZombie(float health, float damage, float distant, float percentageBoost, float frequency)
    {
        base.InitZombie(health, damage, distant, percentageBoost, frequency);
        this.InitAbility(damage, distant, percentageBoost, frequency, FrequencyType.ONCE, AbilityType.VIRAL);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    
}
