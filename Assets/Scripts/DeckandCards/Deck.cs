using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IDeckable
{
    
    public void CreateListOfMyCardBuildForCombat();

    public void DrawCards();

}

public class Deck : MonoBehaviour,IDeckable
{
    //public Card[] _deck;



    /*public CardDisplay Slot1;
    public CardDisplay Slot2;
    public CardDisplay Slot3;*/
    
    public CardDisplay[] CarddisplaysScriptsInTheSlots;

    /*public bool SlotBool1 = false;
    public bool SlotBool2 = false;
    public bool SlotBool3 = false;*/

    public bool[] SlotBools;

    public Card[] DeckOfTheDeck;

    public bool[] EquipOrUnequipTheNormalCardBool;
    [SerializeField]
    private List<Card> TrueDeckInCombat = new List<Card>();

    /* private void Awake()
     {
         //_deck = Resources.FindObjectsOfTypeAll<Card>();
     }*/
    

    public void BuildMyDeck(Card browser, int ThePlaceInArray)
    {
        if (!EquipOrUnequipTheNormalCardBool[ThePlaceInArray])
        {
            DeckOfTheDeck[ThePlaceInArray] = browser;
            EquipOrUnequipTheNormalCardBool[ThePlaceInArray] = true;
        }
        else
        {
            DeckOfTheDeck[ThePlaceInArray] = null;
            EquipOrUnequipTheNormalCardBool[ThePlaceInArray] = false;
        }
    }

    public void CreateListOfMyCardBuildForCombat()
    {
        foreach (Card objeto in DeckOfTheDeck)
        {
            if (objeto != null)
            {
                TrueDeckInCombat.Add(objeto);
            }
        }
    }

    public int PermissionToLeaveTheInventory(Card[] deckOfTheDeck)
    {
        int contadorNoNulos = 0;
        foreach (Card objeto in deckOfTheDeck)
        {
            if (objeto != null)
            {
                contadorNoNulos++;
            }
        }
        return contadorNoNulos;
    }

    /*public void UltimateDrawCards(int MyPlace)
    {
        if (TrueDeckInCombat.Count >= 1)
        {
            for (int i = 0; i <= 3; i++)
            {
                Card randomCard = TrueDeckInCombat[Random.Range(0, TrueDeckInCombat.Count)];
                if (i == 0 && !SlotBools[i])
                {
                    CarddisplaysScriptsInTheSlots[i].Card = randomCard;
                    CarddisplaysScriptsInTheSlots[i].TheVigorCostOfMyCard();
                    SlotBools[i] = true;
                }

                else if (i == 2 && !SlotBools[i])
                {
                    CarddisplaysScriptsInTheSlots[i].Card = randomCard;
                    CarddisplaysScriptsInTheSlots[i].TheVigorCostOfMyCard();
                    SlotBools[i] = true;
                }
                else if (i == 3 && !SlotBools[i])
                {
                    CarddisplaysScriptsInTheSlots[i].Card = randomCard;
                    CarddisplaysScriptsInTheSlots[i].TheVigorCostOfMyCard();
                    SlotBools[i] = true;
                }

            }
        }

    }*/

    public void DrawCards()
    {
        /*if (TrueDeckInCombat.Count >= 1)
        {
            for (int i = 0; i <= availableCardSlots; i++)
            {
                Card randomCard = TrueDeckInCombat[Random.Range(0, TrueDeckInCombat.Count)];
                if (i == 0 && !SlotBool1)
                {
                    Slot1.Card = randomCard;
                    Slot1.TheVigorCostOfMyCard();
                    SlotBool1 = true;
                }
                else if (i == 1 && !SlotBool2)
                {
                    Slot2.Card = randomCard;
                    Slot2.TheVigorCostOfMyCard();
                    SlotBool2 = true;
                }
                else if (i == 2 && !SlotBool3)
                {
                    Slot3.Card = randomCard;
                    Slot3.TheVigorCostOfMyCard();
                    SlotBool3 = true;
                }
            }
        }*/
        if (TrueDeckInCombat.Count >= 1)
        {
            for (int i = 0; i <= 2; i++)
            {
                Card randomCard = TrueDeckInCombat[Random.Range(0, TrueDeckInCombat.Count)];
                if (i == 0 && !SlotBools[i])
                {
                   
                    CarddisplaysScriptsInTheSlots[i].Card = randomCard;
                    CarddisplaysScriptsInTheSlots[i].UpdateUiCardInfo();
                    SlotBools[i] = true;
                }

                else if (i == 1 && !SlotBools[i])
                {
                    CarddisplaysScriptsInTheSlots[i].Card = randomCard;
                    CarddisplaysScriptsInTheSlots[i].UpdateUiCardInfo();
                    SlotBools[i] = true;
                }
                else if (i == 2 && !SlotBools[i])
                {
                    CarddisplaysScriptsInTheSlots[i].Card = randomCard;
                    CarddisplaysScriptsInTheSlots[i].UpdateUiCardInfo();
                    SlotBools[i] = true;
                }

            }
        }

    }
}
