using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : Person
{
    public static Military instance;

    [SerializeField]
    private float magic = 10;
    [SerializeField]
    private SlowTIme slowTime;

    private void Awake()
    {
        instance = this;
        this.Init(10f);
        this.magic = 10;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            this.magic -= Time.deltaTime;
            slowTime.Action();
        }
    }
    public float GetCurrentHealth()
    {
        return this.health;
    }
    public float GetCurrentMagic()
    {
        return this.magic;
    }




}
