using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Player player;
    [SerializeField] private Image combatUI;
    [SerializeField] private Image Inventory;
    public bool cardsEquiped = false;
    public bool inventoryactive = false;
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private Transform[] cardslots;
    [SerializeField] private bool[] availableCardSlots;
    [SerializeField] private Text deckSizeText;
    public bool gameispaused;
    [SerializeField] private Image PauseMenu;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject controls;
    [SerializeField] private MyCamera camerascript;
    [SerializeField] private Rigidbody playerRB;

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randomCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    availableCardSlots[i] = false;
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

    public void activeUI()
    {
        cardsEquiped = !cardsEquiped;
        combatUI.gameObject.SetActive(cardsEquiped);
    }

    public void Activeinventory()
    {
        PauseGame();
        Inventory.gameObject.SetActive(true);
    }

    public void DesactivateInventory()
    {
        PlayGame();
        Inventory.gameObject.SetActive(false);
    }

    public void Menuactivate()
    {
        PauseGame();
        Menu.gameObject.SetActive(true);
    }

    public void Menudesactivate()
    {
        PlayGame();
        Menu.gameObject.SetActive(false);
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
