using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieViral : Zombie
{
    // Start is called before the first frame update
    void Start()
    {
        this.InitZombie(1f);
        this.InitAbility(5f, 10f, 1.5f, 0, FrequencyType.ONCE, AbilityType.VIRAL);
    }
}
