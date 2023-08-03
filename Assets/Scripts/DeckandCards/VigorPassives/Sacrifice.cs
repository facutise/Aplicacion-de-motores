using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : CardsPassives
{
    /* sacrificeParticles = DamageParticlesInTheCombats[2];
                sacrificeParticles2 = DamageParticlesInTheCombats[8];
                sacrificeParticles3 = DamageParticlesInTheCombats[14];
                sacrificeParticles.Play();
                sacrificeParticles2.Play();
                sacrificeParticles3.Play();
                enemyy.health -= 12;
                ProtectionTottemPa();
                stadisticplayerScipt.health -= 3;
                Debug.Log("te has inflingido daño pero mucho mas al enemigo");*/
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[2].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[8].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[14].Play();
        stadisticPlayerScript.enemyy.health -= 12;
        stadisticPlayerScript.ProtectionTottemPassive();
        stadisticPlayerScript.health -= 3;
        stadisticPlayerScript.VigorPlayAudio(stadisticPlayerScript.normalAudioCard);
         Debug.Log("te has inflingido daño pero mucho mas al enemigo");

    }
}
