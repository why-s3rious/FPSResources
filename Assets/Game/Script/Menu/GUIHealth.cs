using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIHealth : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player, Vector3.up);
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
