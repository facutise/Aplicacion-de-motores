using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionTottem : VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        protetionTottemParticles = DamageParticlesInTheCombats[0];
        protetionTottemParticles2 = DamageParticlesInTheCombats[6];
        protetionTottemParticles3 = DamageParticlesInTheCombats[12];
        protetionTottemParticles.Play();
        protetionTottemParticles2.Play();
        protetionTottemParticles3.Play();
        stadisticplayerScipt.health += 1;
        ProtectionTottemPa();
        Debug.Log("te has curado 1 puntos de salud");
        stadisticplayerScipt.protectionTottemStacks += 1;
        if (stadisticplayerScipt.protectionTottemStacks == 5)
        {
            Debug.Log("el tottem de proteccción ya está activado");
        }
    }
}
