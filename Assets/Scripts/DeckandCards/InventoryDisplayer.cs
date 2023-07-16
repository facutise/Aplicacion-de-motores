using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public Canvas cardInfoCanvas; // Referencia al Canvas que muestra la información de la tarjeta
    public TMP_Text tmpText; // Componente TextMeshProUGUI para mostrar los datos de la tarjeta

    private Dictionary<string, string> cardData;

    private void Awake()
    {
        InitializeCardData();
    }

    private void Start()
    {
        InitializeCardData();
    }

    public void InitializeCardData()
    {
        cardData = new Dictionary<string, string>();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DisplayCardInfo();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            CloseCardInfo();
        }
    }

    public void DisplayCardInfo()
    {
        cardInfoCanvas.gameObject.SetActive(true); // Activa el Canvas para mostrar la información
        tmpText.text = GetFormattedCardData(); // Establece el texto en el componente TMP_Text con los datos de la tarjeta
    }

    public void CloseCardInfo()
    {
        cardInfoCanvas.gameObject.SetActive(false); // Desactiva el Canvas que muestra la información
    }

    private string GetFormattedCardData()
    {
        string formattedData = "";
        foreach (var entry in cardData)
        {
            formattedData += entry.Key + ": " + entry.Value + "\n";
        }
        return formattedData;
    }
}