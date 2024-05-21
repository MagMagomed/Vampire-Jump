using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuController : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToResults()
    {
        SceneManager.LoadScene("Results");
    }
}
