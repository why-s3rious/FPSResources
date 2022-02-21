using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Zombie : Mob
{
    [SerializeField]
    protected int distantToFollow = 5;
    [SerializeField]
    protected NavMeshAgent agent;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Ability ability;
    [SerializeField]
    protected AbilityType abilityType;
    [SerializeField]
    protected GameObject explodePrefab;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected GUIHealth guiHealth;

    public void SetExplodePrefab(GameObject explodePrefab)
    {
        this.explodePrefab = explodePrefab;
    }

    // Start is called before the first frame update


    void Awake()
    {

    }


    public virtual void InitZombie(float health)
    {
        this.Init(health);
        this.animator = GetComponent<Animator>();
        this.agent = GetComponent<NavMeshAgent>();
    }
    public void InitAbility(float damage, float distantToActivate, float percentageBoost, float frequency, FrequencyType frequencyType,AbilityType abilityType)
    {
        gameObject.AddComponent(AbilityFactory.GetAbility(abilityType).GetType());
        this.ability = GetComponent<Ability>();
        this.ability.InitAbility(this, damage, distantToActivate, percentageBoost, frequency, frequencyType);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            return;
        }
    }

    public void CheckCanUseSpecial(float distant)
    {
        if (distant <= this.ability.DistantToActivate)
        {
            ActiveAbility();
        }
    }

    private void WalkToWalkPlayer()
    {

    }

    public void MoveToTarget(Transform target)
    {
        agent.Resume();
        agent.SetDestination(target.position);
    }

    public void StopMovement()
    {
        agent.Stop();
    }

    public void Explode()
    {
        try
        {   if(this.isDead)
            {
                Debug.Log("Bomber Explode");
                GameObject ob = Instantiate(explodePrefab, this.transform.position, this.transform.rotation).gameObject;
                ob.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                //Destroy bullet object
                Destroy(ob, 0.5f);
            }
        }
        catch
        {

        }
       

    }
    public void ActiveAbility()
    {
        if(IsDead())
        {
            return;
        }

        if(!this.ability.IsActive)
        {
            this.ability.IsActive = true;
        }
    }
  
    protected override void OnDead()
    {
        animator.SetBool("isDead",true);
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public float GetDamage()
    {
        return this.damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.transform.tag == "Explode")
        {
            if(this.gameObject != other)
            {
                SetDead();
            }
        }
    }

    public void ApplyDamage(Transform target)
    {
        target.GetComponent<Mob>().TakeDamage(this.damage);
    }

    public virtual void InitZombie(float health, float damage, float distant,float percentageBoost, float frequency)
    {
        InitZombie(health);
    }
    public void SetGuiHealth(GameObject gui)
    {
        GUIHealth guiHealth = Instantiate(gui, this.transform).GetComponent<GUIHealth>();
        this.guiHealth = guiHealth;
        this.guiHealth.Init(this.health);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        this.guiHealth.SetValueHealthBar(this.health);
    }
}
