using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[2].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[8].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[14].Play();
        stadisticPlayerScript.PlayAudio(stadisticPlayerScript.fireExplosionAudio);
        Debug.Log("se ha usado fire explosion");

        fireExplosionParticles = stadisticPlayerScript.damageParticlesInTheCombats[2];
        fireExplosionParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[8];
        fireExplosionParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[14];
        
        fireExplosionParticles.Play();
        fireExplosionParticles2.Play();
        fireExplosionParticles3.Play();

    }
}
