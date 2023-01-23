using System.Timers;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject gameOverMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameOver == true)
        {
            print("kjkjhkjhkjh");
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }*/
    }

    public void Restart()
    {   print("The game is restarted");
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

    }

    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
