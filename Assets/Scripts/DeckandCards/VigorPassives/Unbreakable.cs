using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unbreakable : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[1].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[7].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[13].Play();
        stadisticPlayerScript.vigor += 5;
        stadisticPlayerScript.ProtectionTottemPassive();
        Debug.Log("te has aumentado 5 puntos de vigor");

        /*unbreakeableParticles = DamageParticlesInTheCombats[1];
        unbreakeableParticles2 = DamageParticlesInTheCombats[7];
        unbreakeableParticles3 = DamageParticlesInTheCombats[13];
        unbreakeableParticles.Play();
        unbreakeableParticles2.Play();
        unbreakeableParticles3.Play();
        stadisticplayerScipt.vigor += 5;
        ProtectionTottemPa();
        Debug.Log("te has aumentado 5 puntos de vigor");*/
    }
}
