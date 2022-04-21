using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setPause();

        }
    }

    public void setPause()
    {
        if(!isPaused)
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }

        isPaused = !isPaused;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
       
    }

}
