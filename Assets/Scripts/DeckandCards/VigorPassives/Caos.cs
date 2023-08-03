using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caos : VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        caosParticles = DamageParticlesInTheCombats[2];
        caosParticles2 = DamageParticlesInTheCombats[8];
        caosParticles3 = DamageParticlesInTheCombats[14];
        caosParticles.Play();
        caosParticles2.Play();
        caosParticles3.Play();
        enemyy.health -= 9;
        ProtectionTottemPa();
        PlayAudio(CaosAudio);
        Debug.Log("Has inflingido 9 de daño");
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
    }
}
