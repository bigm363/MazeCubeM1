using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    public void GotoPlayground()
    {
        SceneManager.LoadScene("playground");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
