using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void OnStartGame()
    {
    //    int index = Random.Range(2, 3);
        SceneManager.LoadScene(2); 
    }


    public void OnExitGame()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnInstruction()
    {
        SceneManager.LoadScene(1);
    }

}
