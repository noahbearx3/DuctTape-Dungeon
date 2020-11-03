using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void OnStartGame()
    {
        int maxRange = SceneManager.sceneCountInBuildSettings - 2;
        int randomLevel = Random.Range(2, maxRange);
        SceneManager.LoadScene(randomLevel); 
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
