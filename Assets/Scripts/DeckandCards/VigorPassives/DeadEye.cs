using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEye :CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[5].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[11].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[17].Play();
        stadisticPlayerScript.enemyy.health -= 7;
        stadisticPlayerScript.health += 3;
        stadisticPlayerScript.ProtectionTottemPassive();
        stadisticPlayerScript.VigorPlayAudio(stadisticPlayerScript.deadEyeAudio);
        Debug.Log("Has inflingido 7 de daño y te has curado 2 puntos de salud");
        Debug.Log("Al enemigo le queda " + stadisticPlayerScript.enemyy.health + " de vida ");
        

        
    }
}
