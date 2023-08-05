using UnityEngine;

//TP2 - Santiago Andres Sanchez Barrio
public class CardInfoPrinter : MonoBehaviour
{
    private void Update()
    {
        //CARTAS NORMALES
        if (Input.GetKeyDown(KeyCode.J))
        {
            PrintCardInfo();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PrintVigorCardInfo();
        }
    }

    private void PrintCardInfo()
    {
        CardDisplay[] cardDisplays = FindObjectsOfType<CardDisplay>();

        for (int i = 0; i < cardDisplays.Length; i++)
        {
            CardDisplay cardDisplay = cardDisplays[i];
            string cardInfo = $"Card {i + 1}: Name: {cardDisplay.Card.name}, Description: {cardDisplay.Card.description}, Attack: {cardDisplay.Card.attack}";
            Debug.Log(cardInfo);
        }
    }
    private void PrintVigorCardInfo()
    {
        VigorCardsDisplay[] vigorCardDisplays = FindObjectsOfType<VigorCardsDisplay>();

        for (int i = 0; i < vigorCardDisplays.Length; i++)
        {
            VigorCardsDisplay vigorCardDisplay = vigorCardDisplays[i];
            string cardInfo = $"Card {i + 1}: Name: {vigorCardDisplay.Card.name}, Description: {vigorCardDisplay.Card.description}, Vigor Cost: {vigorCardDisplay.Card.vigorcost}";
            Debug.Log(cardInfo);
        }
    }
}