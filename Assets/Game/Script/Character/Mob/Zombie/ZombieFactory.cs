using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    public static Zombie GetZombieByType(ZombieType type)
    {
        switch(type)
        {
            case ZombieType.BOMBER:
                return new ZombieBomber();
                break;
            case ZombieType.NORMAL:
                return new ZombieNormal();
                break;
            case ZombieType.VIRAL:
                return new ZombieViral();
                break;
            default:
                return new ZombieNormal();
        }

    }
}
