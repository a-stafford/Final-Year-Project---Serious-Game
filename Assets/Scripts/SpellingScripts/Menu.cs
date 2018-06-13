using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    //plays the game when play is pressed
    public void PlayLevel()
    {
        SceneManager.LoadScene("SpellingMain");
    }

    //starts the English level
    public void StartLevel()
    {
        SceneManager.LoadScene("SpellingGuide");
    }

    //returns to hub world when exit is pressed
   public void ExitLevel()
    {
        SceneManager.LoadScene("HubMain");
    }
}
