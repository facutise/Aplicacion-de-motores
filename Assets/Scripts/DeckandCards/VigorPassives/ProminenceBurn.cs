using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProminenceBurn : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[3].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[9].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[15].Play();
        stadisticPlayerScript.enemyy.health -= 3;
        stadisticPlayerScript.health += 3;
        stadisticPlayerScript.ProtectionTottemPassive();
        Debug.Log("Has inflingido 3 de daño y te has curado 3 puntos de salud");
        Debug.Log("Al enemigo le queda " + stadisticPlayerScript.enemyy.health + " de vida ");
        stadisticPlayerScript.VigorPlayAudio(stadisticPlayerScript.warriorPendantAudio);
        
        /*prominanceBurnParticles = DamageParticlesInTheCombats[3];
        prominanceBurnParticles2 = DamageParticlesInTheCombats[9];
        prominanceBurnParticles3 = DamageParticlesInTheCombats[15];
        prominanceBurnParticles.Play();
        prominanceBurnParticles2.Play();
        prominanceBurnParticles3.Play();
        enemyy.health -= 3;
        stadisticplayerScipt.health += 3;
        ProtectionTottemPa();
        Debug.Log("Has inflingido 3 de daño y te has curado 3 puntos de salud");
        Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");*/
    }
}
