using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIHealth : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(float defaultHealth)
    {
        this.slider.maxValue = defaultHealth;
        this.slider.value = defaultHealth;
    }

    public void SetValueHealthBar(float value)
    {
        this.slider.value = value;
    }

}
