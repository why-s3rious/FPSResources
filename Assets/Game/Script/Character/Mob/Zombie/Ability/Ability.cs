using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    protected Zombie zombie;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float distantToActivate;
    [SerializeField]
    protected float percentageBoost;
    [SerializeField]
    protected float frequency;
    [SerializeField]
    protected bool isActive = false;
    [SerializeField]
    protected FrequencyType frequencyType;

    public bool IsActive { get => isActive; set => isActive = value; }
    public float DistantToActivate { get => distantToActivate; set => distantToActivate = value; }

    public void InitAbility(Zombie zombie, float damage, float distantToActivate, float percentageBoost, float frequency, FrequencyType frequencyType)
    {
        this.zombie = zombie;
        this.damage = damage;
        this.distantToActivate = distantToActivate;
        this.percentageBoost = percentageBoost;
        this.frequency = frequency;
        this.frequencyType = frequencyType;
    }

    private void Update()
    {
        if (this.zombie.IsDead()) 
            return;

        
        if(isActive)
        {
          switch(this.frequencyType)
            {
                case FrequencyType.ALWAY:
                    Alway();
                    break;
                case FrequencyType.ONCE:
                    Once();
                    break;
                case FrequencyType.FREQUENCY:
                    Frequency();
                    break;
            }
        }
    }

    protected virtual void Tick() { }
    
    private void Alway()
    {
        Tick();
    }
    private void Frequency()
    {
        Tick();
    }
    private void Once()
    {
        Tick();
        this.IsActive = false;
    }
}
