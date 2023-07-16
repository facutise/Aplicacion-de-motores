using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP2-"Facundo Sebastian Tisera"
public class InventoryDisplayer : MonoBehaviour
{
    public Card card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;
    public Text attacktext;
    public int MyPlaceOnTheArray;
    public Deck DeckScript;
    public bool VigorCardEquipedEffectBool;
    public Image EquipedEffectVigor;

    private Dictionary<string, string> cardData; // Diccionario para almacenar los datos

    private void Awake()
    {
        InitializeCardData();
    }

    private void Start()
    {
        InitializeCardData();
    }

    private void Update()
    {
        InitializeCardData();
        if (Input.GetKeyDown(KeyCode.K))
        {
            PrintCardData();
        }
    }

    public void InitializeCardData()
    {
        cardData = new Dictionary<string, string>(); // Reinicia el diccionario

        cardData["Name"] = card.name;
        cardData["Description"] = card.description;
        cardData["Attack"] = card.attack.ToString();
    }

    public void PrintCardData()
    {
        foreach (var entry in cardData)
        {
            Debug.Log(entry.Key + ": " + entry.Value);
        }
    }

    public void CardEffectFunction()
    {
        VigorCardEquipedEffectBool = !VigorCardEquipedEffectBool;
        EquipedEffectVigor.gameObject.SetActive(VigorCardEquipedEffectBool);
    }

    public void AddCardToMyDeck()
    {
        DeckScript.BuildMyDeck(card, MyPlaceOnTheArray);
        CardEffectFunction();
    }

  
}