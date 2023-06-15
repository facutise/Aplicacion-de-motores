using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public ParticleSystem damageParticleSlot1;
    public ParticleSystem damageParticleSlot2;
    public ParticleSystem damageParticleSlot3;
    public ParticleSystem damageparticleSlot4;
    public ParticleSystem damageparticleSlot5;
    public ParticleSystem damageparticleSlot6;
    public ParticleSystem damageParticleSlot1Combate2;
    public ParticleSystem damageParticleSlot2Combate2;
    public ParticleSystem damageParticleSlot3Combate2;
    public ParticleSystem damageparticleSlot4Combate2;
    public ParticleSystem damageparticleSlot5Combate2;
    public ParticleSystem damageparticleSlot6Combate2;
    public ParticleSystem damageParticleSlot1_Combate3;
    public ParticleSystem damageParticleSlot2_Combate3;
    public ParticleSystem damageParticleSlot3_Combate3;
    public ParticleSystem damageparticleSlot4_Combate3;
    public ParticleSystem damageparticleSlot5_Combate3;
    public ParticleSystem damageparticleSlot6_Combate3;
    [SerializeField]
    private ParticleSystem[] DamageParticlesInTheCombats;



    public CardDisplay carddisplayscriptinSlot1;
    public CardDisplay carddisplayscriptinSlot2;
    public CardDisplay carddisplayscriptinSlot3;
    [SerializeField]
    private CardDisplay[] CardDisplayScriptsInTheSlots;


    public VigorCardsDisplay carddisplayscriptinSlot4;
    public VigorCardsDisplay carddisplayscriptinSlot5;
    public VigorCardsDisplay carddisplayscriptinSlot6;
    [SerializeField]
    private VigorCardsDisplay[] VigorCardDisplayScriptsInTheSlots;


    public Image cardOrange1;
    public Image cardOrange2;
    public Image cardOrange3;
    public Image cardOrange4;
    public Image cardOrange5;
    public Image cardOrange6;
    [SerializeField]
    private Image[] OrangeCards;


    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    [SerializeField]
    private Button[] ButtonsofSlot;

    private bool cartafueUsada = true;
    private bool cartafueUsada2 = true;
    private bool cartafueUsada3 = true;
    private bool cartafueUsada4 = true;
    private bool cartafueUsada5 = true;
    private bool cartafueUsada6 = true;
    [SerializeField]
    private bool[] CardsHadBeenUsed;


    public CanvasGroup[] TheCanvasesForFade;


    public Button passButton;
    private bool enemyattack = false;
    public VigorDeck VigorDeckScript;
    public StadisticPlayer PlayerStadisticsScript;
    public Enemy enemyy;
    int playercontador;
    public Deck deckscript;
    private Player player;
    public object WaitForSeconds3 { get; private set; }

    public void ActivateOrDeactivateCardInTheSlot(int MyCardOrangeAndCardUsedInTheArray)//Nuevo metodo para reemplazar los de abajo
    {
        CardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray] = !CardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray];
        OrangeCards[MyCardOrangeAndCardUsedInTheArray].gameObject.SetActive(CardsHadBeenUsed[MyCardOrangeAndCardUsedInTheArray]);
    }
    public void activaryDesactivarCartaAlUsarlaSlot1()
    {
        cartafueUsada = !cartafueUsada;
        cardOrange1.gameObject.SetActive(cartafueUsada);

    }
    public void activaryDesactivarCartaAlUsarlaSlot2()
    {
        cartafueUsada2 = !cartafueUsada2;
        cardOrange2.gameObject.SetActive(cartafueUsada2);

    }
    public void activaryDesactivarCartaAlUsarlaSlot3()
    {
        cartafueUsada3 = !cartafueUsada3;
        cardOrange3.gameObject.SetActive(cartafueUsada3);

    }

    public void activaryDesactivarCartaAlUsarlaSlot4()
    {
        cartafueUsada4 = !cartafueUsada4;
        cardOrange4.gameObject.SetActive(cartafueUsada4);

    }
    public void activaryDesactivarCartaAlUsarlaSlot5()
    {
        cartafueUsada5 = !cartafueUsada5;
        cardOrange5.gameObject.SetActive(cartafueUsada5);

    }
    public void activaryDesactivarCartaAlUsarlaSlot6()
    {
        cartafueUsada6 = !cartafueUsada6;
        cardOrange6.gameObject.SetActive(cartafueUsada6);

    }

    public void setenemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void Enemydealsdamage()
    {
        if (enemyattack == true)
        {
            for(int i = 0; i <= ButtonsofSlot.Length; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                ButtonsofSlot[i].interactable = true;
            }
            
            PlayerStadisticsScript.vigor += 1;
           /* button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
            button5.interactable = true;
            button6.interactable = true;*/

            enemyy.Enemyturn();
            playercontador = 0;
            deckscript.DrawCards();
            VigorDeckScript.DrawCards();

            for (int i = 0; i <= 6; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                if (CardsHadBeenUsed[i] == false)
                {
                    ActivateOrDeactivateCardInTheSlot(i);
                }
            }

            /*if (cartafueUsada == false)
            {
                activaryDesactivarCartaAlUsarlaSlot1();
            }
            if (cartafueUsada2 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot2();
            }
            if (cartafueUsada3 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot3();
            }
            if (cartafueUsada4 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot4();
            }
            if (cartafueUsada5 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot5();
            }
            if (cartafueUsada6 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot6();
            }
            */
            enemyattack = false;
            Debug.Log("Final del turno");
            Debug.Log("Inicio el siguiente turno");
        }
    }
    public void EndOfCombat()
    {
        if (enemyattack == true)
        {
            PlayerStadisticsScript.vigor += 1;

            for (int i = 0; i <= ButtonsofSlot.Length; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                ButtonsofSlot[i].interactable = true;
            }
            /*button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
            button5.interactable = true;
            button6.interactable = true;*/
            playercontador = 0;
            deckscript.DrawCards();
            VigorDeckScript.DrawCards();

            for (int i = 0; i <= 6; i++)//NUEVO FOR PARA REEMPLAZAR LO DE ABAJO
            {
                if (CardsHadBeenUsed[i] == false)
                {
                    ActivateOrDeactivateCardInTheSlot(i);
                }
            }
            enemyattack = false;

            /*if (cartafueUsada == false)
            {
                activaryDesactivarCartaAlUsarlaSlot1();
            }
            if (cartafueUsada2 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot2();
            }
            if (cartafueUsada3 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot3();
            }
            if (cartafueUsada4 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot4();
            }
            if (cartafueUsada5 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot5();
            }
            if (cartafueUsada6 == false)
            {
                activaryDesactivarCartaAlUsarlaSlot6();
            }*/


        }
    }

    /*IEnumerator CardFunctionAndFade(int TheSlotClicked)                    //FUNCI�N A�N EN PRUEBA PARA REEMPLAZAR LOS FadeAnimSlot
    {

    }
    */

    IEnumerator FadeAnimSlot1(int myplace)
    {
        float alpha = 1;

        while (alpha >= 0)
        {
            alpha -= 0.1f;
            yield return new WaitForEndOfFrame();
            TheCanvasesForFade[myplace].alpha = alpha;
        }
        deckscript.SlotBool1 = false;
        int carddmgtrue = carddisplayscriptinSlot1.Thecarddmg();
        enemyy.health -= carddmgtrue;
        carddisplayscriptinSlot1.ejecutarpasivadelacarta();
        damageParticleSlot1.Play();
        damageParticleSlot1Combate2.Play();
        damageParticleSlot1_Combate3.Play();
        Debug.Log("El player inflingio " + carddmgtrue + (" de da�o"));
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
        enemyattack = true;
        playercontador = 1;
        deckscript.DrawCards();
        activaryDesactivarCartaAlUsarlaSlot1();
        button1.interactable = false;
        TheCanvasesForFade[0].alpha = 1;
        yield return null;
    }
    IEnumerator FadeAnimSlot2(int myplace)
    {
        float alpha = 1;

        while (alpha >= 0)
        {
            alpha -= 0.1f;
            yield return new WaitForEndOfFrame();
            TheCanvasesForFade[myplace].alpha = alpha;
        }
        deckscript.SlotBool2 = false;
        int carddmgtrue = carddisplayscriptinSlot2.Thecarddmg();
        enemyy.health -= carddmgtrue;
        carddisplayscriptinSlot2.ejecutarpasivadelacarta();
        damageParticleSlot2.Play();
        damageParticleSlot2Combate2.Play();
        damageParticleSlot2_Combate3.Play();
        Debug.Log("El player inflingio " + carddmgtrue + (" de da�o"));
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
        //contador = 1;
        enemyattack = true;
        playercontador = 1;
        activaryDesactivarCartaAlUsarlaSlot2();
        button2.interactable = false;
        TheCanvasesForFade[myplace].alpha = 1;
        yield return null;
    }
    IEnumerator FadeAnimSlot3(int myplace)
    {
        float alpha = 1;

        while (alpha >= 0)
        {
            alpha -= 0.1f;
            yield return new WaitForEndOfFrame();
            TheCanvasesForFade[myplace].alpha = alpha;
        }
        deckscript.SlotBool3 = false;
        int carddmgtrue = carddisplayscriptinSlot3.Thecarddmg();
        enemyy.health -= carddmgtrue;
        carddisplayscriptinSlot3.ejecutarpasivadelacarta();
        damageParticleSlot3.Play();
        damageParticleSlot3Combate2.Play();
        damageParticleSlot3_Combate3.Play();
        Debug.Log("El player inflingio " + carddmgtrue + (" de da�o"));
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
        //contador = 1;
        enemyattack = true;
        playercontador = 1;
        activaryDesactivarCartaAlUsarlaSlot3();
        button3.interactable = false;
        TheCanvasesForFade[myplace].alpha = 1;
        yield return null;
    }
    IEnumerator FadeAnimSlot4(int myplace)
    {
        float alpha = 1;

        while (alpha >= 0)
        {
            alpha -= 0.1f;
            yield return new WaitForEndOfFrame();
            TheCanvasesForFade[myplace].alpha = alpha;
        }
        PlayerStadisticsScript.vigor -= carddisplayscriptinSlot4.actualizarinformaci�ncostedeVigor();
        Debug.Log("restan " + PlayerStadisticsScript.vigor + " puntos de vigor");
        carddisplayscriptinSlot4.ejecutarpasivadelacartadevigor();
        activaryDesactivarCartaAlUsarlaSlot4();

        button4.interactable = false;
        VigorDeckScript.SlotBool4 = false;
        damageparticleSlot4.Play();
        damageparticleSlot4Combate2.Play();
        damageparticleSlot4_Combate3.Play();
        TheCanvasesForFade[myplace].alpha = 1;
        yield return null;
    }
    IEnumerator FadeAnimSlot5(int myplace)
    {
        float alpha = 1;

        while (alpha >= 0)
        {
            alpha -= 0.1f;
            yield return new WaitForEndOfFrame();
            TheCanvasesForFade[myplace].alpha = alpha;
        }
        PlayerStadisticsScript.vigor -= carddisplayscriptinSlot5.actualizarinformaci�ncostedeVigor();
        Debug.Log("restan " + PlayerStadisticsScript.vigor + " puntos de vigor");
        carddisplayscriptinSlot5.ejecutarpasivadelacartadevigor();

        activaryDesactivarCartaAlUsarlaSlot5();
        button5.interactable = false;
        VigorDeckScript.SlotBool5 = false;
        damageparticleSlot5.Play();
        damageparticleSlot5Combate2.Play();
        damageparticleSlot5_Combate3.Play();
        TheCanvasesForFade[myplace].alpha = 1;
        yield return null;
    }
    IEnumerator FadeAnimSlot6(int myplace)
    {
        float alpha = 1;

        while (alpha >= 0)
        {
            alpha -= 0.1f;
            yield return new WaitForEndOfFrame();
            TheCanvasesForFade[myplace].alpha = alpha;
        }
        PlayerStadisticsScript.vigor -= carddisplayscriptinSlot6.actualizarinformaci�ncostedeVigor();
        Debug.Log("restan " + PlayerStadisticsScript.vigor + " puntos de vigor");
        carddisplayscriptinSlot6.ejecutarpasivadelacartadevigor();

        activaryDesactivarCartaAlUsarlaSlot6();
        VigorDeckScript.SlotBool6 = false;
        button6.interactable = false;
        damageparticleSlot6.Play();
        damageparticleSlot6Combate2.Play();
        damageparticleSlot6_Combate3.Play();
        TheCanvasesForFade[myplace].alpha = 1;
        yield return null;
    }
    public void clickonslotone()
    {
        if (carddisplayscriptinSlot1.myslot == 1 && playercontador == 0)
        {
            StartCoroutine(FadeAnimSlot1(0));
        }
    }
    public void clickonslottwo()
    {
        if (carddisplayscriptinSlot2.myslot == 2 && playercontador == 0)
        {
            StartCoroutine(FadeAnimSlot2(1));

        }
    }
    public void clickonslotthree()
    {
        if (carddisplayscriptinSlot3.myslot == 3 && playercontador == 0)
        {
            StartCoroutine(FadeAnimSlot3(2));

        }
    }
    public void clickonslotfour()
    {
        if (PlayerStadisticsScript.vigor >= carddisplayscriptinSlot4.actualizarinformaci�ncostedeVigor())
        {
            StartCoroutine(FadeAnimSlot4(3));

        }
    }
    public void clickonslotfive()
    {
        if (PlayerStadisticsScript.vigor >= carddisplayscriptinSlot5.actualizarinformaci�ncostedeVigor())
        {
            StartCoroutine(FadeAnimSlot5(4));

        }
    }
    public void clickonslotsix()
    {
        if (PlayerStadisticsScript.vigor >= carddisplayscriptinSlot6.actualizarinformaci�ncostedeVigor())
        {
            StartCoroutine(FadeAnimSlot6(5));

        }
    }
}
