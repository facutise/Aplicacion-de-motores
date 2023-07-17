using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TP2-"Facundo Sebastian Tisera"
public interface IDeckable
{
    
    public void CreateListOfMyCardBuildForCombat();

    public void DrawCards();

}

public class Deck : MonoBehaviour,IDeckable
{
    
    public CardDisplay[] CarddisplaysScriptsInTheSlots;

    public bool[] SlotBools;

    public Card[] DeckOfTheDeck;

    public bool[] EquipOrUnequipTheNormalCardBool;
    [SerializeField]
    private List<Card> TrueDeckInCombat = new List<Card>();


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
        TrueDeckInCombat.RemoveAll(item => item == null);//COMENTADO
    }

    public void EmptyListOfMyCardsBuildForCombat()
    {
        for (int i = 0; i < TrueDeckInCombat.Count; i++)
        {
            TrueDeckInCombat[i] = null;
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

    

    public void DrawCards()
    {
        
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
