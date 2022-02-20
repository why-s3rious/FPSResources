using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBomber : Zombie
{
    // Start is called before the first frame update
    [SerializeField]
    private float distantToExplode = 5f;

    protected override void OnDead()
    {
        base.OnDead();
        this.Explode();
    }

    void Start()
    {
        this.InitZombie(1f);
        this.InitAbility(10f, distantToExplode, 0, 0, FrequencyType.ONCE, AbilityType.BOMBER);
    }



}
