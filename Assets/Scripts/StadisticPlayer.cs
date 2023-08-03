using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//TP2-"Facundo Sebastian Tisera"


public class StadisticPlayer : MonoBehaviour
{
    public int health = 30;
    public int vigor = 1;
    public int defense;
    public GameManager _myGM;
    public int spiritGrowthStacks;//NUEVO PONER EN EL UML
    public int protectionTottemStacks;// NUEVO PONER EN EL UML 

    public Dictionary<string, CardDisplay> cardDisplayPassives = new Dictionary<string, CardDisplay>();
    public CardDisplay[] cardDisplaysPassives;

    public void Update()
    {
        if (health > 30)
        {
            health = 30;
        }

        if (health <= 0)
        {
            PlayerDies();
        }
    }

    public void PlayerDies()
    {
        SceneManager.LoadScene("MainScene");
    }
}
