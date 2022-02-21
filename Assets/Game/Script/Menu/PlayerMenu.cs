using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    public static PlayerMenu instance;


    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Image damageUI;
    [SerializeField]
    private float opacity;
    [SerializeField]
    private GameObject playerUI;
    [SerializeField]
    private GameObject pauseMenu;
    private bool isPauseGame = false;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(opacity > 0)
        {
            opacity -= Time.deltaTime;
            var tempColor = this.damageUI.color;
            tempColor.a = opacity;
            this.damageUI.color = tempColor;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPauseGame = !isPauseGame;
            OnPauseGame(isPauseGame);
        }

    }

    public void Init(float health)
    {
        this.healthBar.maxValue = health;
        this.healthBar.value = health;
        this.scoreText.text = "0";
    }
    public void TakeDamage(float health)
    {
        this.healthBar.value = health;
        this.opacity = 1;
    }
    public void SetScore(int score)
    {
        this.scoreText.text = score.ToString();
    }

    public void OnPauseGame(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        PauseOrContinute(isPause);
    }

    public void PauseOrContinute(bool isPause)
    {
        playerUI.SetActive(!isPause);
        pauseMenu.SetActive(isPause);

    }

}
