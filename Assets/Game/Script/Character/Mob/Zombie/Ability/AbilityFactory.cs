using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour
{
    public static Ability GetAbility(AbilityType type)
    {
        switch(type)
        {
            case AbilityType.NORMAL:
                return new AbilityNormal();
                break;

            case AbilityType.VIRAL:
                return new AbilityViral();
                break;

            case AbilityType.BOMBER:
                return new AbilityBomber();
                break;

            default:
                return null;
        }

    }

}
