using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] int health = 3;
    public Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    [Header ("Pause Game")]
    public GameObject gameOverUI;
    public GameObject playerController;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    [Header ("iFrames")]
    [SerializeField] float iFramesDuration;
    [SerializeField] int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Timer")]
    [SerializeField] float levelNumber = 1f;
    private float time = 0f;
    public Text timer;
    public Text highscore;
    bool isCounting;

    

    void Awake() //first to run in unity, faster than start
        {
            spriteRend = GetComponent<SpriteRenderer>();
            
            int numGameSessions = FindObjectsOfType<GameSession>().Length; //create an array cuz it finds all the things
            if (numGameSessions > 1)
            {
                Destroy(gameObject);
            }
            

            // if (PlayerPrefs.HasKey("Highscore") == true)
            // {
            //     highscore.text = PlayerPrefs.GetFloat("Highscore" + levelNumber).ToString();
            // }
            // else 
            // {
            //     highscore.text = "Record: ";    
            // }
            UpdateHighScore();
        }

    void Update()
    {

        if(isCounting)
        {
            time += Time.deltaTime; 
        }
        timer.text = time.ToString();


        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        
    }

    public void StartTimer() 
    {
        isCounting = true;
    }

    public void StopTimer(bool stop)
    {
        isCounting = stop;
        if (PlayerPrefs.GetFloat("Highscore" + levelNumber) == 0)
        {
            PlayerPrefs.SetFloat("Highscore" + levelNumber, 100f);
        }
        if (time < PlayerPrefs.GetFloat("Highscore" + levelNumber))
        {
            SetHighscore();
        }
    }

    public void SetHighscore()
    {
        PlayerPrefs.SetFloat("Highscore" + levelNumber, time);
        highscore.text = PlayerPrefs.GetFloat("Highscore" + levelNumber).ToString();
        PlayerPrefs.Save();
    }

    public void UpdateHighScore()
    {
        highscore.text = $"Record: {PlayerPrefs.GetFloat("Highscore" + levelNumber ,0.0f)}";
    }

    public void ProcessPlayerDeath()
    {
        if (health > 1)
        {
            TakeLife(1);
        }
        else
        {
            gameOver();
        }
        

    }

    void TakeLife(int value)
    {
        health -= value;
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(currentSceneIndex);
        //animator na nadadamage
    }

    public void AddLife(int value)
    {
        health += value;
    }
    
    // THE GAME OVER PANEL CODE
    void gameOver()
    {
        gameOverUI.SetActive(true);
        playerController.SetActive(false);
    }


    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Destroy(gameObject);
    }


    public void restartScene() // repeat the level because you failed
    {
        Invoke("ResetGameSession", 1.5f);
    }

    public void quit()
    {
        Application.Quit();
    }


    // PAUSE PANEL CODE
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart() // restart the level by your own choice
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // SETTINGS PANEL CODE

    public void settings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void closeSettings()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
        
    // MAIN MENU PANEL CODE

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 0;
    }
}
