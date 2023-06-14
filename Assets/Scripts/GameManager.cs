using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Player player;
    public Image combatUI;
    public Image Inventory;
    public bool cardsEquiped = false;
    public bool inventoryactive = false;
    //Variables del mazo
    public List<Card> deck = new List<Card>();
    public Transform[] cardslots;
    public bool[] availableCardSlots;
    public Text deckSizeText;
    //private bool activatePauseMenu = false;   ME DICE EL CONSOLE QUE ESTA VARIABLE NUNCA SE USA Y LO COMENT�  ~Facu


    public bool gameispaused;
    public Image PauseMenu;
    public GameObject Menu;
    public GameObject controls;
    public MyCamera camerascript;
    public Rigidbody playerRB;


    //PROFE si ve esto  es solo prueba del script de mazo, nada m�s
    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randomCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    // randomCard.gameObject.setActive(true);
                    //randomCard.transform.position = cardslots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randomCard);
                    return;
                }
            }
        }

        //  void Update()
        //{
        //deckSizeText.text = deck.Count.ToString();
        //}
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
        {
            return player;
        }
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
