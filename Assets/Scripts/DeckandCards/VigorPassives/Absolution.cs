using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absolution : VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        absolutionParticles = DamageParticlesInTheCombats[4];
        absolutionParticles2 = DamageParticlesInTheCombats[10];
        absolutionParticles3 = DamageParticlesInTheCombats[16];
        absolutionParticles.Play();
        absolutionParticles2.Play();
        absolutionParticles3.Play();
        enemyy.health -= 6;
        stadisticplayerScipt.health += 4;
        ProtectionTottemPa();
        Debug.Log("Has inflingido 6 de daño y te has curado 4 puntos de salud");
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
    }
}
