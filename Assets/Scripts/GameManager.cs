using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP2-Marco Lavacchielli
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Player player;
    [SerializeField] private Image combatui;
    [SerializeField] private Image inventory;
    public bool cardsequiped = false;
    public bool inventoryactive = false;
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private Transform[] cardslots;
    [SerializeField] private bool[] availablecardslots;
    [SerializeField] private Text decksizetext;
    public bool gameispaused;
    [SerializeField] private Image pausemenu;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;
    [SerializeField] private MyCamera camerascript;
    [SerializeField] private Rigidbody playerRB;

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randomCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availablecardslots.Length; i++)
            {
                if (availablecardslots[i] == true)
                {
                    availablecardslots[i] = false;
                    deck.Remove(randomCard);
                    return;
                }
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        player = FindObjectOfType<Player>();
    }

    public Player Player()
    {
        return player;
    }

    public static Transform PlayerTransform
    {
        get
        {
            return instance.player.transform;
        }
    }

    public void ActiveUI()
    {
        cardsequiped = !cardsequiped;
        combatui.gameObject.SetActive(cardsequiped);
    }

    public void Activeinventory()
    {
        PauseGame();
        inventory.gameObject.SetActive(true);
    }

    public void DesactivateInventory()
    {
        PlayGame();
        inventory.gameObject.SetActive(false);
    }

    public void Menuactivate()
    {
        PauseGame();
        menu.gameObject.SetActive(true);
    }

    public void Menudesactivate()
    {
        PlayGame();
        menu.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
    }

    public void Showcontrols()
    {
        controls.gameObject.SetActive(true);
    }

    public void Hidecontrols()
    {
        controls.gameObject.SetActive(false);
    }
}
