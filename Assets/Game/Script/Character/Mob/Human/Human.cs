using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : Mob
{
    public static float opacityHurt = 0f;
    [SerializeField]
    protected SkillType skillType;
    [SerializeField]
    protected Skill skill;

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

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        opacityHurt = 1f;
        PlayerMenu.instance.TakeDamage(this.GetCurrentHealth());
    }

    protected override void OnDead()
    {
        base.OnDead();
    }
}
