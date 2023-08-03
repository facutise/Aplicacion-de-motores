using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProminenceBurn : VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        prominanceBurnParticles = DamageParticlesInTheCombats[3];
        prominanceBurnParticles2 = DamageParticlesInTheCombats[9];
        prominanceBurnParticles3 = DamageParticlesInTheCombats[15];
        prominanceBurnParticles.Play();
        prominanceBurnParticles2.Play();
        prominanceBurnParticles3.Play();
        enemyy.health -= 3;
        stadisticplayerScipt.health += 3;
        ProtectionTottemPa();
        Debug.Log("Has inflingido 3 de daño y te has curado 3 puntos de salud");
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
    }
}
