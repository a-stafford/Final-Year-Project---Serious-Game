using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public Transform Player, Canvas, Sounds;

    void Start()
    {
        Canvas.gameObject.SetActive(false);
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
            Player.GetComponent<SpaceshipRotation>().enabled = false;
            Player.GetComponent<PlayerShoot>().enabled = false;
            Sounds.GetComponent<AudioSource>().Pause();
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Player.GetComponent<SpaceshipRotation>().enabled = true;
            Player.GetComponent<PlayerShoot>().enabled = true;
            Sounds.GetComponent<AudioSource>().Play();
        }


    }

    //exits back to the hub world
    public void ExitGame()
    {
        SceneManager.LoadScene("HubMain");
        Time.timeScale = 1;
    }

    //restarts the game to play again
    public void Restart()
    {
        SceneManager.LoadScene("MathMain");

    }
}
