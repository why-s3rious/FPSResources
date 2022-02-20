using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory : MonoBehaviour
{
    public static Skill GetSkillByType(SkillType type)
    {
        switch (type)
        {
            case SkillType.SLOW_TIME:
                return new SkillSlowTime();
            default:
                return null;
        }
    }
}
