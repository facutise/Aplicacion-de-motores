using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caos : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[2].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[8].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[14].Play();
        stadisticPlayerScript.enemyy.health -= 9;
        stadisticPlayerScript.ProtectionTottemPassive();
        stadisticPlayerScript.VigorPlayAudio(stadisticPlayerScript.caosAudio);
        Debug.Log("Has inflingido 9 de daño");
        Debug.Log("Al enemigo le queda " + stadisticPlayerScript.enemyy.health + " de vida ");

        /*caosParticles = DamageParticlesInTheCombats[2];
        caosParticles2 = DamageParticlesInTheCombats[8];
        caosParticles3 = DamageParticlesInTheCombats[14];
        caosParticles.Play();
        caosParticles2.Play();
        caosParticles3.Play();
        enemyy.health -= 9;
        ProtectionTottemPa();
        PlayAudio(CaosAudio);*/
    }
}
