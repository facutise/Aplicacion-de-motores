using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP2-Marco Lavacchielli
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Player player;
    [SerializeField] private Image combatUi;
    [SerializeField] private Image inventory;
    public bool cardsEquiped = false;
    public bool inventoryActive = false;
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private Transform[] cardSlots;
    [SerializeField] private bool[] availableCardSlots;
    [SerializeField] private Text deckSizeText;
    public bool gameIsPaused;
    [SerializeField] private Image pauseMenu;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;
    [SerializeField] private MyCamera cameraScript;
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

    public void ActiveUI()
    {
        cardsEquiped = !cardsEquiped;
        combatUi.gameObject.SetActive(cardsEquiped);
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
}
