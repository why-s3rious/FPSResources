using InfimaGames.LowPolyShooterPack.Interface;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementHealth : ElementText
{
    #region METHODS
    [SerializeField]
    private Slider healthBar;

    protected override void Start()
    {
        //Base.
        healthBar.maxValue = Military.instance.GetCurrentHealth();
        healthBar.minValue = 0;

        healthBar.value = Military.instance.GetCurrentHealth();
    }

    protected override void Tick()
    {
        //Change text to match the time scale!
        textMesh.text = Military.instance.GetCurrentHealth().ToString();
        healthBar.value = Military.instance.GetCurrentHealth();
    }

    #endregion
}
