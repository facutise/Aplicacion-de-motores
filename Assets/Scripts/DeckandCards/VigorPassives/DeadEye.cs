using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEye :VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        deadEyeParticles = DamageParticlesInTheCombats[5];
        deadEyeParticles2 = DamageParticlesInTheCombats[11];
        deadEyeParticles3 = DamageParticlesInTheCombats[17];
        deadEyeParticles.Play();
        deadEyeParticles2.Play();
        deadEyeParticles3.Play();
        enemyy.health -= 7;
        stadisticplayerScipt.health += 3;
        ProtectionTottemPa();
        PlayAudio(DeadEyeAudio);
        Debug.Log("Has inflingido 7 de daño y te has curado 2 puntos de salud");
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
    }
}
