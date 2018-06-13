using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenHub : MonoBehaviour
{

    public Transform  Canvas, Portal1, Portal2;

    void Start()
    {
        //Canvas.gameObject.SetActive(false);
    }

    //pause screen is active when pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();

        }
    }

    //sets pause screen active and unactive when escape is pressed
    public void Resume()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {
           Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            Portal1.GetComponent<Spin>().enabled = false;
            Portal2.GetComponent<Spin>().enabled = false;
            //Player.GetComponent<PlayerShoot>().enabled = false;
            //Sounds.GetComponent<AudioSource>().Pause();
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Portal1.GetComponent<Spin>().enabled = true;
            Portal2.GetComponent<Spin>().enabled = true;
            //Player.GetComponent<PlayerShoot>().enabled = true;
            //Sounds.GetComponent<AudioSource>().Play();
        }


    }

    //exits back to the hub world
    public void ExitGame()
    {
        Application.Quit();
    }

    //restarts the game to play again
    public void Restart()
    {
        SceneManager.LoadScene("SpellingMain");

    }
}
