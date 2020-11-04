using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void OnStartGame()
    {
        int maxRange = SceneManager.sceneCountInBuildSettings - 2;
        int randomLevel = Random.Range(3, maxRange);
        SceneManager.LoadScene(randomLevel); 
    }

    public void OnCutscene()
    {
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
