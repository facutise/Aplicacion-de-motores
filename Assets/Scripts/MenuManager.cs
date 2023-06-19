using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TP2 - Santiago Andres Sanchez Barrio

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject MenuTutorial;
    public GameObject MenuCredits;

    public void loadscene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Restartscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
