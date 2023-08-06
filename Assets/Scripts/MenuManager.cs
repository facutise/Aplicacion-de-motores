using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TP2 - Santiago Andres Sanchez Barrio

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menuTutorial;
    public GameObject menuCredits;

    public void loadscene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Restartscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
