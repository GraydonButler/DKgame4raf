using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenumanager : MonoBehaviour
{
   public void Startgame()
    {
        SceneManager.LoadScene("mainscene");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
