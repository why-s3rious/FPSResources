using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject vfxBloodExplode;
    public GameObject guiHealthForZombie;


    public int score = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Level level = (Level)Random.Range(0, System.Enum.GetValues(typeof(Level)).Length);
        transform.Find(level.ToString()).gameObject.SetActive(true);
    }
        // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        this.score += 1;
        PlayerMenu.instance.SetScore(this.score);
    }
}
