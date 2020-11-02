using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void OnStartGame()
    {
        int index = Random.Range(1, 2);
        SceneManager.LoadScene(index); 
    }


    public void OnExitGame()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
