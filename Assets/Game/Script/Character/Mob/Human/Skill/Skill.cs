using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isActive = false;
    private bool canUseSkill = false;

    private float timeDuration;
    private float timeCoolDown;
    private Transform player;
    private float countTimeCoolDown;
    private float countTimeDuration;


    public void Init(float timeActive,float timeCoolDown, Transform player)
    {
        this.timeDuration = timeActive;
        this.timeCoolDown = timeCoolDown;
        this.player = player;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActiveSkill();
    }

    public void Activate() 
    {
        if(!this.isActive)
        {   
            this.isActive = true;
            this.canUseSkill = false;
            this.countTimeDuration = 0;
            this.countTimeCoolDown = 0;
            Debug.Log("Activate Skill");
        }
    }
    public void ActiveSkill()
    {
        if(isActive)
        {
            Tick();
            this.countTimeDuration += Time.deltaTime;
            if(this.countTimeDuration > timeDuration)
            {
                isActive = false;
                UnActive();
            }
        }
        if (!canUseSkill)
        {
            this.countTimeCoolDown += Time.deltaTime;
            if (this.countTimeCoolDown > timeCoolDown)
            {
                canUseSkill = true;
            }
        }
    }
    protected virtual void Tick() { }
    protected virtual void UnActive() { }

}
