using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
//TP2-"Facundo Sebastian Tisera"
public class VCardsInventoryCounter : MonoBehaviour
{
    public VigorDeck VigorDeckScript;
    public int cardsondeck;
    private TextMeshProUGUI ContadorCartasVigorEnMazo;


    private void Start()
    {
        ContadorCartasVigorEnMazo = GetComponent<TextMeshProUGUI>();
    }
    public void VigorCardsOnDeckCounter()
    {
        cardsondeck = VigorDeckScript.EquipOrUnequipTheCardBool.Count(b => b);
    }
    private void Update()
    {
        VigorCardsOnDeckCounter();
        ContadorCartasVigorEnMazo.text = cardsondeck.ToString() + ("/8");
    }
}
