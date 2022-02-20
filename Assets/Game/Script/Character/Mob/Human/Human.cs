using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : Mob
{
    [SerializeField]
    private SkillType skillType;
    [SerializeField]
    private Skill skill;

    // Start is called before the first frame update
    public void InitSkill(float duration,float timeCoolDown,Transform player)
    {
        this.gameObject.AddComponent(SkillFactory.GetSkillByType(skillType).GetType());
        skill = this.GetComponent<Skill>();
        skill.Init(duration, timeCoolDown, player);
    }

    // Update is called once per frame
    private void Update()
    {
        CheckUseSkill();
    }

    public void CheckUseSkill()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            skill.Activate();
        }
    }
}
