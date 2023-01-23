using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private bool gameOver = false;
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
        if (gameOver == true)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        print("The game is restarted");
        gameOverMenu.SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
