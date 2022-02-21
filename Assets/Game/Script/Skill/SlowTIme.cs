using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTIme : MonoBehaviour
{

    [SerializeField]
    private float timeSlow = 0.2f;
    [SerializeField]
    private float timeSlowDuration = 2f;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale += (1f/ timeSlowDuration)*Time.deltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void Action()
    {
        Time.timeScale = timeSlow;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
