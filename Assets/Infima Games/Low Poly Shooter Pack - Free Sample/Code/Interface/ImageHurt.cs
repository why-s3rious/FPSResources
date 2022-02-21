using InfimaGames.LowPolyShooterPack.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHurt : Element
{
    // Start is called before the first frame update
    [SerializeField]
    private Image image;
    [SerializeField]
    private float speed = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Human.opacityHurt > 0)
        {
            Human.opacityHurt -= Time.deltaTime * speed;
            var tempColor = this.image.color;
            tempColor.a = Human.opacityHurt;
            this.image.color = tempColor;
        }

    }
}
