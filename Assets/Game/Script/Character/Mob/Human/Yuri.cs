using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuri : Human
{
    // Start is called before the first frame update
    void Start()
    {
        this.Init(10f);
        InitSkill(1,2,this.transform);
    }
   

}
