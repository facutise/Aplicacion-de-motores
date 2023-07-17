using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TP2-"Facundo Sebastian Tisera"

public class VigorDeck : MonoBehaviour, IDeckable
{

    [SerializeField]
    public VigorCardsDisplay[] VigorCardDisplaysScripts;

    [SerializeField]
    public bool[] SlotBools;

    public VigorCards[] DeckOfTheVigorDeck;
    public bool[] EquipOrUnequipTheCardBool;
    [SerializeField]
    private List<VigorCards> TrueVigorDeckInCombat = new List<VigorCards>();

    public void CreateListOfMyCardBuildForCombat()
    {
        foreach (VigorCards objeto in DeckOfTheVigorDeck)
        {
            if (objeto != null)
            {
                TrueVigorDeckInCombat.Add(objeto);
            }
        }
        TrueVigorDeckInCombat.RemoveAll(item => item == null);//COMENTADO
    }

    public void EmptyListOfMyVigorCardsBuildForCombat()
    {
        for (int i = 0; i < TrueVigorDeckInCombat.Count; i++)
        {
            TrueVigorDeckInCombat[i] = null;
        }
    }

    public void BuildMyDeck(VigorCards browser, int ThePlaceInArray)
    {

        if (EquipOrUnequipTheCardBool[ThePlaceInArray] == false)
        {
            DeckOfTheVigorDeck[ThePlaceInArray] = browser;
            EquipOrUnequipTheCardBool[ThePlaceInArray] = true;
        }
        else if (EquipOrUnequipTheCardBool[ThePlaceInArray] == true)
        {
            DeckOfTheVigorDeck[ThePlaceInArray] = null;
            EquipOrUnequipTheCardBool[ThePlaceInArray] = false;
        }
    }

    public int PermissionToLeaveTheInventoryMinimumVigorDeckCards(VigorCards[] deckOfTheVigorDeck)
    {
        int contadorNoNulos = 0;
        foreach (VigorCards objeto in deckOfTheVigorDeck)
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


        if (TrueVigorDeckInCombat.Count >= 1)
        {
            for (int i = 3; i <= 5; i++)
            {
                VigorCards randomCard = TrueVigorDeckInCombat[Random.Range(0, TrueVigorDeckInCombat.Count)];
                if (i == 3 && !SlotBools[i])
                {

                    VigorCardDisplaysScripts[i].Card = randomCard;
                    VigorCardDisplaysScripts[i].UpdateUiCardInfo();
                    SlotBools[i] = true;
                }

                else if (i == 4 && !SlotBools[i])
                {

                    VigorCardDisplaysScripts[i].Card = randomCard;
                    VigorCardDisplaysScripts[i].UpdateUiCardInfo();
                    SlotBools[i] = true;
                }
                else if (i == 5 && !SlotBools[i])
                {

                    VigorCardDisplaysScripts[i].Card = randomCard;
                    VigorCardDisplaysScripts[i].UpdateUiCardInfo();
                    SlotBools[i] = true;
                }

            }
        }


    }

}
