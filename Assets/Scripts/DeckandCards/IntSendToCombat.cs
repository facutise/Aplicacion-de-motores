using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntSendToCombat : MonoBehaviour
{
    public int TheintOfMySlot;

    public Combat CombatScript;

    public void MyIntMessengerToCombat()
    {
        CombatScript.UltimateClickOnSlot(TheintOfMySlot);
    }

}
