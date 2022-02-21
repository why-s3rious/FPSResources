using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject groupBtn;

    [SerializeField]
    private Button btnPlay;

    [SerializeField]
    private Button btnContinute;

    [SerializeField]
    private Slider progressLoading;

    [SerializeField]
    private TextMeshProUGUI loadingText;
    AsyncOperation operation;

    // Start is called before the first frame update
    void Start()
    {
        this.btnPlay.onClick.AddListener(OnClickStart);
        this.btnContinute.onClick.AddListener(OnClickContinute);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickStart()
    {
        groupBtn.SetActive(false);
        progressLoading.gameObject.SetActive(true);
        LoadingScene(1);
    }
    private void OnClickContinute()
    {
        operation.allowSceneActivation = true;
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
        loadingText.gameObject.SetActive(false);
        btnContinute.gameObject.SetActive(true);

        //if 100 
        // countinute
    }



}
