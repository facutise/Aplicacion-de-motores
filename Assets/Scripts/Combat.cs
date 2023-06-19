using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TP2-"Facundo Sebastian Tisera"

/*Hola buen día profe, le comento que he tratado de cambiar ls variables para que estén en pascalCase como con los demás integrantes
 pero creo que debo tener un error en mi monitor entre unity y visual ya que cuando lo intentaba(click derecho->cambiarnombre->incluir en cadenas y comentarios)
 en unity perdía la referencia y no me dejaba incorporarla nuevamente, pero creo que el error se debe a visual, ya que no sólo perdía la referencia, sino que en inspector
dichos nombres permanecían en PascalCase. Cabe aclarar que al hacerlo otras veces nisiquiera se perdía la referencia, he eliminado el repositorio e intentado nuevamente pero
lleva al mismo resultado, mil disculpas, espero que me haya explicado apropiadamente, saludos.*/
public class Combat : MonoBehaviour
{
    
    [SerializeField]
    private CardDisplay[] CardDisplayScriptsInTheSlots;


    
    [SerializeField]
    private VigorCardsDisplay[] VigorCardDisplayScriptsInTheSlots;


   
    [SerializeField]
    private Image[] OrangeCards;


    
    [SerializeField]
    private Button[] ButtonsofSlot;

   
    [SerializeField]
    private bool[] CardsHadBeenUsed;


    public CanvasGroup[] TheCanvasesForFade;

    [SerializeField]
    private Button PassButton;

    private bool EnemyAttack = false;
    [SerializeField]
    private VigorDeck VigorDeckScript;
    [SerializeField]
    private StadisticPlayer PlayerStadisticsScript;
    [SerializeField]
    private Enemy Enemy;
    private int PlayerCountDown;
    [SerializeField]
    private Deck DeckScript;
   
    public object WaitForSeconds3 { get; private set; }

    public void ActivateOrDeactivateCardInTheSlot(int MyCardOrangeAndCardUsedInTheArray)                            //NUEVO METODO PARA REEMPLAZAR LO DE ABAJO
    {
        CardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray] = !CardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray];
        OrangeCards[MyCardOrangeAndCardUsedInTheArray].gameObject.SetActive(CardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray]);

        if (ButtonsofSlot[0].interactable == true)
        {
            
        }
    }
   

    public void setenemy(Enemy enemy)
    {
        Enemy = enemy;
    }
    public void Enemydealsdamage()
    {
        if (EnemyAttack == true)
        {
            for (int i = 0; i < 6; i++)                                                   //NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                ButtonsofSlot[i].interactable = true;
            }

            PlayerStadisticsScript.vigor += 1;
           
            Enemy.Enemyturn();
            PlayerCountDown = 0;
            DeckScript.DrawCards();
            VigorDeckScript.DrawCards();

            for (int i = 0; i < 6; i++)                                                          //NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                if (CardsHadBeenUsed[i] == false)
                {
                    ActivateOrDeactivateCardInTheSlot(i);
                }
            }

           
            EnemyAttack = false;
            Debug.Log("Final del turno");
            Debug.Log("Inicio el siguiente turno");
        }
    }
    public void EndOfCombat()
    {
        if (EnemyAttack == true)
        {
            PlayerStadisticsScript.vigor += 1;

            for (int i = 0; i < 6; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                ButtonsofSlot[i].interactable = true;
            }

            
           
            PlayerCountDown = 0;
            DeckScript.DrawCards();
            VigorDeckScript.DrawCards();

            for (int i = 0; i < 6; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                if (CardsHadBeenUsed[i] == false)
                {
                    ActivateOrDeactivateCardInTheSlot(i);
                }
            }
            EnemyAttack = false;

           

        }
    }

    public void UltimateClickOnSlot(int MySlot)  //PRUEBA RENDIMIENTO
    {
        StartCoroutine(CardFunctionAndFade(MySlot));

    }
    IEnumerator CardFunctionAndFade(int TheSlotClicked)                    //FUNCIÓN AÚN EN PRUEBA PARA REEMPLAZAR LOS FadeAnimSlot
    {
       
        if (TheSlotClicked <= 2 && PlayerCountDown == 0)
        {
            float AlphaFloat = 1;

            while (AlphaFloat >= 0)
            {
                AlphaFloat -= 0.1f;
                yield return new WaitForEndOfFrame();
                TheCanvasesForFade[TheSlotClicked].alpha = AlphaFloat;
            }

            DeckScript.SlotBools[TheSlotClicked] = false;
            int carddmgtrue = CardDisplayScriptsInTheSlots[TheSlotClicked].Thecarddmg();
            Enemy.health -= carddmgtrue;
            CardDisplayScriptsInTheSlots[TheSlotClicked].ExecuteCardPassive();
            //particulas
            EnemyAttack = true;
            PlayerCountDown = 1;
            DeckScript.DrawCards();
            ActivateOrDeactivateCardInTheSlot(TheSlotClicked);
            ButtonsofSlot[TheSlotClicked].interactable = false;
            TheCanvasesForFade[TheSlotClicked].alpha = 1;

        }
        else if (TheSlotClicked > 2 && PlayerStadisticsScript.vigor >= VigorCardDisplayScriptsInTheSlots[TheSlotClicked].TheVigorCostOfMyCard())
        {
            float AlphaFloat = 1;

            while (AlphaFloat >= 0)
            {
                AlphaFloat -= 0.1f;
                yield return new WaitForEndOfFrame();
                TheCanvasesForFade[TheSlotClicked].alpha = AlphaFloat;
            }
            PlayerStadisticsScript.vigor -= VigorCardDisplayScriptsInTheSlots[TheSlotClicked].TheVigorCostOfMyCard();
            VigorCardDisplayScriptsInTheSlots[TheSlotClicked].ExecuteCardPassive();
            ActivateOrDeactivateCardInTheSlot(TheSlotClicked);
            ButtonsofSlot[TheSlotClicked].interactable = false;
            VigorDeckScript.SlotBools[TheSlotClicked] = false;
            //damagePartciles
            TheCanvasesForFade[TheSlotClicked].alpha = 1;

        }
        yield return null;
    }

}
