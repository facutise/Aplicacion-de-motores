using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
//TPFINAL-"Facundo Sebastian Tisera"

/*Hola buen día profe, le comento que he tratado de cambiar ls variables para que estén en pascalCase como con los demás integrantes
 pero creo que debo tener un error en mi monitor entre unity y visual ya que cuando lo intentaba(click derecho->cambiarnombre->incluir en cadenas y comentarios)
 en unity perdía la referencia y no me dejaba incorporarla nuevamente, pero creo que el error se debe a visual, ya que no sólo perdía la referencia, sino que en inspector
dichos nombres permanecían en PascalCase. Cabe aclarar que al hacerlo otras veces nisiquiera se perdía la referencia, he eliminado el repositorio e intentado nuevamente pero
lleva al mismo resultado, mil disculpas, espero que me haya explicado apropiadamente, saludos.*/
public class Combat : MonoBehaviour
{

    [FormerlySerializedAs("CardDisplayScriptsInTheSlots")]
    [SerializeField]
    private CardDisplay[] cardDisplayScriptsInTheSlots;


    [FormerlySerializedAs("VigorCardDisplayScriptsInTheSlots")]
    [SerializeField]
    private VigorCardsDisplay[] vigorCardDisplayScriptsInTheSlots;


    [FormerlySerializedAs("OrangeCards")]
    [SerializeField]
    private Image[] orangeCards;


    [FormerlySerializedAs("ButtonofSlot")]
    [SerializeField]
    private Button[] buttonsofSlot;

    [FormerlySerializedAs("CardsHadBeenUsed")]
    [SerializeField]
    private bool[] cardsHadBeenUsed;

    [FormerlySerializedAs("TheCanvasesForFade")]
    [SerializeField]
    private CanvasGroup[] theCanvasesForFade;

    [FormerlySerializedAs("PassButton")]
    [SerializeField]
    private Button passButton;

    private bool enemyAttack = false;

    [FormerlySerializedAs("VigorDeckScript")]
    [SerializeField]
    private VigorDeck vigorDeckScript;
    [SerializeField]
    private StadisticPlayer playerStadisticsScript;
    [SerializeField]
    private Enemy Enemy;
    private int playerCountDown;
    [SerializeField]
    private Deck deckScript;

    [SerializeField] private ParticleSystem[] particleEnemyArray;
    [SerializeField] private ParticleSystem[] particleEnemyArray2;
    [SerializeField] private ParticleSystem[] particleEnemyArray3;
    [SerializeField] private ParticleSystem[] particleEnemyArray4;

    public void ActivateOrDeactivateCardInTheSlot(int MyCardOrangeAndCardUsedInTheArray)                            //NUEVO METODO PARA REEMPLAZAR LO DE ABAJO
    {
        cardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray] = !cardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray];
        orangeCards[MyCardOrangeAndCardUsedInTheArray].gameObject.SetActive(cardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray]);

        if (buttonsofSlot[0].interactable == true)
        {
            
        }
    }
   

    public void SetEnemy(Enemy enemy)
    {
        Enemy = enemy;
    }
    public void Enemydealsdamage()
    {
        if (enemyAttack == true)
        {
            for (int i = 0; i < 6; i++)                                                   //NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                buttonsofSlot[i].interactable = true;
            }

            playerStadisticsScript.vigor += 1;
           
            Enemy.EnemyTurn();
            playerCountDown = 0;
            deckScript.DrawCards();
            vigorDeckScript.DrawCards();

            for (int i = 0; i < 6; i++)                                                          //NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                if (cardsHadBeenUsed[i] == false)
                {
                    ActivateOrDeactivateCardInTheSlot(i);
                }
            }

            int z = Random.Range(0, particleEnemyArray.Length);
            particleEnemyArray[z].Play();
            int n = Random.Range(0, particleEnemyArray2.Length);
            particleEnemyArray2[n].Play();
            int t = Random.Range(0, particleEnemyArray3.Length);
            particleEnemyArray3[t].Play();
            int d = Random.Range(0, particleEnemyArray4.Length);
            particleEnemyArray4[d].Play();
            enemyAttack = false;
            Debug.Log("Final del turno");
            Debug.Log("Inicio el siguiente turno");
        }
    }
    public void EndOfCombat()
    {
        if (enemyAttack == true)
        {
            playerStadisticsScript.vigor += 1;

            for (int i = 0; i < 6; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                buttonsofSlot[i].interactable = true;
            }

            
           
            playerCountDown = 0;
            deckScript.DrawCards();
            vigorDeckScript.DrawCards();

            for (int i = 0; i < 6; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                if (cardsHadBeenUsed[i] == false)
                {
                    ActivateOrDeactivateCardInTheSlot(i);
                }
            }
            enemyAttack = false;

           

        }
    }

    public void DrawCardsStartCombat()
    {
        deckScript.DrawCards();
        vigorDeckScript.DrawCards();
        for (int i = 0; i < 6; i++)
        {
            if (cardsHadBeenUsed[i] == false)
            {
                ActivateOrDeactivateCardInTheSlot(i);
            }
            buttonsofSlot[i].interactable = true;
            theCanvasesForFade[i].alpha = 1;
        }
    }
    public void EmptyHandAtEndOfCombat()
    {
        for (int i = 0; i < 6; i++)
        {
            if (cardsHadBeenUsed[i] == true)
            {
                ActivateOrDeactivateCardInTheSlot(i);
            }
            buttonsofSlot[i].interactable = false;
            theCanvasesForFade[i].alpha = 1;
        }

    }

    public void UltimateClickOnSlot(int MySlot)  //PRUEBA RENDIMIENTO
    {
        StartCoroutine(CardFunctionAndFade(MySlot));

    }
    IEnumerator CardFunctionAndFade(int TheSlotClicked)                    //FUNCIÓN AÚN EN PRUEBA PARA REEMPLAZAR LOS FadeAnimSlot
    {
       
        if (TheSlotClicked <= 2 && playerCountDown == 0)
        {
            float AlphaFloat = 1;

            while (AlphaFloat >= 0)
            {
                AlphaFloat -= 0.2f;
                yield return new WaitForEndOfFrame();
                theCanvasesForFade[TheSlotClicked].alpha = AlphaFloat;
            }

            deckScript.slotBools[TheSlotClicked] = false;
            int carddmgtrue = cardDisplayScriptsInTheSlots[TheSlotClicked].Thecarddmg();
            Enemy.health -= carddmgtrue;
            cardDisplayScriptsInTheSlots[TheSlotClicked].ExecuteCardPassive();
            //particulas
            enemyAttack = true;
            playerCountDown = 1;
            deckScript.DrawCards();
            ActivateOrDeactivateCardInTheSlot(TheSlotClicked);
            buttonsofSlot[TheSlotClicked].interactable = false;
            theCanvasesForFade[TheSlotClicked].alpha = 1;

        }
        else if (TheSlotClicked > 2 && playerStadisticsScript.vigor >= vigorCardDisplayScriptsInTheSlots[TheSlotClicked].TheVigorCostOfMyCard())
        {
            float AlphaFloat = 1;

            while (AlphaFloat >= 0)
            {
                AlphaFloat -= 0.2f;
                yield return new WaitForEndOfFrame();
                theCanvasesForFade[TheSlotClicked].alpha = AlphaFloat;
            }
            playerStadisticsScript.vigor -= vigorCardDisplayScriptsInTheSlots[TheSlotClicked].TheVigorCostOfMyCard();
            vigorCardDisplayScriptsInTheSlots[TheSlotClicked].ExecuteCardPassive();
            ActivateOrDeactivateCardInTheSlot(TheSlotClicked);
            buttonsofSlot[TheSlotClicked].interactable = false;
            vigorDeckScript.SlotBools[TheSlotClicked] = false;
            //damagePartciles
            theCanvasesForFade[TheSlotClicked].alpha = 1;

        }
        yield return null;
    }

}
