using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float loadTime = 2f;
    [SerializeField] GameObject nextLevelMenu;
    
    [Header("GameSession")]

    [SerializeField] GameObject gameS;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameSession>().StopTimer(false);
            UnlockNewLevel();
            nextLevelMenu.SetActive(true);
            Time.timeScale = 0;  
            // SceneController.instance.NextLevel();      
        }
    }


    public void NextLevel()
    {
        nextLevelMenu.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<PlayerMovement>().HoldKey(false);
        StartCoroutine(LoadSceneDelay());  // proceed to the next level
    }

    // public void restartScene() // restart scene after you finished the level
    // {
        

    //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    //     SceneManager.LoadScene(currentSceneIndex);
    //     nextLevelMenu.SetActive(false);
    //     Time.timeScale = 1;
    // }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSecondsRealtime(loadTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
