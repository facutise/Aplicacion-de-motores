using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorPendant : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[5].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[11].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[17].Play();
        stadisticPlayerScript.health += 8;
        stadisticPlayerScript.ProtectionTottemPassive();
        stadisticPlayerScript.VigorPlayAudio(stadisticPlayerScript.warriorPendantAudio);
        Debug.Log("te has curado 5 puntos de salud");
        
        /*warriorPendantParticles = DamageParticlesInTheCombats[5];
        warriorPendantParticles2 = DamageParticlesInTheCombats[11];
        warriorPendantParticles3 = DamageParticlesInTheCombats[17];
        warriorPendantParticles.Play();
        warriorPendantParticles2.Play();
        warriorPendantParticles3.Play();
        stadisticplayerScipt.health += 8;
        ProtectionTottemPa();
        PlayAudio(WarriorPendantAudio);
        Debug.Log("te has curado 5 puntos de salud");*/
    }
}
