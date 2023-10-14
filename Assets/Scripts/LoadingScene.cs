using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] float timeToComplete = 10f;
    public GameObject LoadingScreen;
    public GameObject NextButton;
    public GameObject LoadingBar;
    public GameObject Trivia;
    public Image LoadingBarfill;
    public float timerValue;
    public float fillFraction;

    void Update()
    {
        Time.timeScale = 1;
        LoadingBarfill.fillAmount = fillFraction;
        UpdateTimer();

        if(fillFraction > 1)
        {
            LoadingBar.SetActive(false);
            Trivia.SetActive(false);
            NextButton.SetActive(true);
        }
    }

    void UpdateTimer()
    {
        timerValue += Time.deltaTime;
        
        if(timerValue > 0)
        {
            fillFraction = timerValue / timeToComplete;
        }

    }

    // public void LoadScene(int sceneId)
    // {
    //     StartCoroutine(LoadSceneAsync(sceneId));
    // }

    // IEnumerator LoadSceneAsync(int sceneId)
    // {
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

    //     LoadingScreen.SetActive(true);

    //     while (!operation.isDone)
    //     {
    //         float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

    //         LoadingBarfill.fillAmount = progressValue;

    //         yield return null;
    //     }
    // }
}
