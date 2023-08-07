using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
//TPFINAL-"Facundo Sebastian Tisera"
public interface IDeckable
{
    
    public void CreateListOfMyCardBuildForCombat();

    public void DrawCards();

}

public class Deck : MonoBehaviour,IDeckable
{
    [FormerlySerializedAs("CarddisplaysScriptsInTheSlots")]
    [SerializeField]
    private CardDisplay[] carddisplaysScriptsInTheSlots;

    
    public bool[] slotBools;

    [FormerlySerializedAs("DeckOfTheDeck")]
    public Card[] deckOfTheDeck;

    [FormerlySerializedAs("EquipOrUnequipTheNormalCardBool")]
    public bool[] equipOrUnequipTheNormalCardBool;
    [SerializeField]
    private List<Card> trueDeckInCombat = new List<Card>();


    public void BuildMyDeck(Card browser, int ThePlaceInArray)
    {
        if (!equipOrUnequipTheNormalCardBool[ThePlaceInArray])
        {
            deckOfTheDeck[ThePlaceInArray] = browser;
            equipOrUnequipTheNormalCardBool[ThePlaceInArray] = true;
        }
        else
        {
            deckOfTheDeck[ThePlaceInArray] = null;
            equipOrUnequipTheNormalCardBool[ThePlaceInArray] = false;
        }
    }

    public void CreateListOfMyCardBuildForCombat()
    {
        foreach (Card objeto in deckOfTheDeck)
        {
            if (objeto != null)
            {
                trueDeckInCombat.Add(objeto);
            }
        }
        trueDeckInCombat.RemoveAll(item => item == null);//COMENTADO
    }

    public void EmptyListOfMyCardsBuildForCombat()
    {
        for (int i = 0; i < trueDeckInCombat.Count; i++)
        {
            trueDeckInCombat[i] = null;
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
        
        if (trueDeckInCombat.Count >= 1)
        {
            for (int i = 0; i <= 2; i++)
            {
                Card randomCard = trueDeckInCombat[Random.Range(0, trueDeckInCombat.Count)];
                if (i == 0 && !slotBools[i])
                {
                   
                    carddisplaysScriptsInTheSlots[i].Card = randomCard;
                    carddisplaysScriptsInTheSlots[i].UpdateUiCardInfo();
                    slotBools[i] = true;
                }

                else if (i == 1 && !slotBools[i])
                {
                    carddisplaysScriptsInTheSlots[i].Card = randomCard;
                    carddisplaysScriptsInTheSlots[i].UpdateUiCardInfo();
                    slotBools[i] = true;
                }
                else if (i == 2 && !slotBools[i])
                {
                    carddisplaysScriptsInTheSlots[i].Card = randomCard;
                    carddisplaysScriptsInTheSlots[i].UpdateUiCardInfo();
                    slotBools[i] = true;
                }

            }
        }

    }
}
