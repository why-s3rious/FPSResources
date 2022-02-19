using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    protected float health;
    protected Animator animator;
    [SerializeField]
    protected GUIHealth guiHealth;
    [SerializeField]
    private GameObject bloodEffect;

    public void Init(float health,Animator animator)
    {
        this.health = health;
        guiHealth.Init(health);
        this.animator = animator;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CheckDead()
    {
        if(health <= 0)
        {
            return true;
        }
        return false;
    }
    public void TakeDamage(float damage)
    {
        float offset = health - damage;
        health = offset < 0 ? 0 : offset;
        guiHealth.SetValueHealthBar(health);
        if (CheckDead())
        {
            OnDead();
        }
    }
    public void SpawnBlood(Transform transform)
    {
        GameObject obj = Instantiate(bloodEffect, transform.position, Quaternion.LookRotation(Vector3.forward, Vector3.down));
        Destroy(obj, 1f);
    }

    private void OnDead()
    {
        this.animator.SetBool("isDead", true);
    }

}
