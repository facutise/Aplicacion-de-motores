using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP2-"Facundo Sebastian Tisera"
public class IntSendToCombat : MonoBehaviour
{
    public int TheintOfMySlot;

    public Combat CombatScript;

    public void MyIntMessengerToCombat()
    {
        CombatScript.UltimateClickOnSlot(TheintOfMySlot);
    }

}
