using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolledPride :VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        unbreakeableParticles = DamageParticlesInTheCombats[2];
        unbreakeableParticles2 = DamageParticlesInTheCombats[7];
        unbreakeableParticles3 = DamageParticlesInTheCombats[13];
        unbreakeableParticles.Play();
        unbreakeableParticles2.Play();
        unbreakeableParticles3.Play();
        enemyy.health -= 5;
        Debug.Log("Has inflingido 5 de daño");
        ProtectionTottemPa();
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
    }
}
