using UnityEngine;

public class CardInfoPrinter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PrintCardInfo();
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
}