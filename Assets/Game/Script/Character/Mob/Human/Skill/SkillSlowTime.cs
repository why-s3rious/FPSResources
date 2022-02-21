using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlowTime : Skill
{
    [SerializeField]
    private float timeSlow = 0.2f;
    [SerializeField]
    private float timeSlowDuration = 2f;

    protected override void Tick()
    {
        Time.timeScale = timeSlow;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    protected override void UnActive()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        this.ActiveSkill();
    }

}
