using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolledPride :CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[5].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[5].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[5].Play();
        stadisticPlayerScript.enemyy.health -= 5;
        Debug.Log("Has inflingido 5 de daño");
        stadisticPlayerScript.ProtectionTottemPassive();
        Debug.Log("Al enemigo le queda " + stadisticPlayerScript.enemyy.health + " de vida ");

        /*unbreakeableParticles = DamageParticlesInTheCombats[2];
        unbreakeableParticles2 = DamageParticlesInTheCombats[7];
        unbreakeableParticles3 = DamageParticlesInTheCombats[13];
        unbreakeableParticles.Play();
        unbreakeableParticles2.Play();
        unbreakeableParticles3.Play();
        enemyy.health -= 5;
        Debug.Log("Has inflingido 5 de daño");
        ProtectionTottemPa();
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");*/
    }
}
