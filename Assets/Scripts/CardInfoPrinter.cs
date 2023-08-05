using UnityEngine;

public class CardInfoPrinter : MonoBehaviour
{
    private void Update()
    {
        //CARTAS NORMALES
        if (Input.GetKeyDown(KeyCode.J))
        {
            PrintCardInfo();
        }
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            PrintVigorCardInfo();
        }*/
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
       /* VigorCardsDisplay[] vigorCardsDisplays = FindObjectOfType<VigorCardsDisplay>();

        for (int i = 0; i < vigorCardsDisplays.Length; i++)
        {
            VigorCardsDisplay vigorCardsDisplayss = vigorCardsDisplays[i];
            string vigorCardInfo = $"Vigor card{ i + 1}: Name: { vigorCardsDisplayss.Card.name}, Description: { vigorCardsDisplayss.Card.description}, Attack: { vigorCardsDisplayss.Card.vigorcost}";
            Debug.Log(vigorCardInfo);
        }
       */
    }
}