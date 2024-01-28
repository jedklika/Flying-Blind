using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject settingsMenu;

    public Playermove player;

    public bool GameIsPaused = false;


    private void Awake()
    {
        Time.timeScale = 1;
        settingsMenu.SetActive(false);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Time.timeScale = 0f;
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (!player.alive)
        {
            Invoke("Death", 2);
        }

    }

    public void Tutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void Death()
    {
        gameMusic.SetActive(false);
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void Apply()
    {
        settingsMenu.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void Restart(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1f;
    }
}
