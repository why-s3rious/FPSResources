using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    public static PlayerMenu instance;


    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private TextMeshProUGUI healthText ;

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
    [SerializeField]
    private TextMeshProUGUI resultText;

    [SerializeField]
    private TextMeshProUGUI contentText;

    [SerializeField]
    private GameObject resultScreen;

    [SerializeField]
    private Button btnContinute;
    [SerializeField]
    private Slider progressLoading;

    private bool isDead = false;
    AsyncOperation operation;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        btnContinute.onClick.AddListener(OnClickContinute);
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
        healthText.text = health.ToString();
        healthImage.fillAmount = 1;
        this.scoreText.text = "0";
    }
    public void TakeDamage(float health)
    {
        healthText.text = health.ToString();
        healthImage.fillAmount = health/10;
        this.opacity = 1;
    }
    public void SetScore(int score)
    {
        this.scoreText.text = score.ToString();
    }

    public void OnPauseGame(bool isPause)
    {

        if(isDead)
        {
            return;
        }
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

    public void PlayerDieResult()
    {
        isDead = true;
        Time.timeScale = 0;
        resultScreen.SetActive(true);
        int highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        bool isWin = GameManager.instance.score > highestScore ? true : false;
        highestScore = GameManager.instance.score > highestScore ? GameManager.instance.score : highestScore;
        string tiltle = isWin ? "You Win" : "You lost";
        string content = isWin ? String.Format("You have highest score {0}", highestScore) : "You need practise more";
        resultText.text = tiltle;
        contentText.text = content;
        progressLoading.gameObject.SetActive(true);
        //Time.timeScale = 1;
        LoadingScene(0);

    }

    private async void LoadingScene(int index)
    {
        operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false;
        do
        {
            await Task.Delay(100);
            progressLoading.value += operation.progress;

        } while (operation.progress < 0.9f);
        await Task.Delay(1000);
        progressLoading.value = 1;
        btnContinute.gameObject.SetActive(true);
    }

    private void OnClickContinute()
    {
        operation.allowSceneActivation = true;
    }
}
