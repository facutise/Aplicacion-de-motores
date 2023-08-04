using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalPierce : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[4].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[10].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[16].Play();
        stadisticPlayerScript.PlayAudio(stadisticPlayerScript.normalAudioCard);
        cristalPierceParticles = stadisticPlayerScript.damageParticlesInTheCombats[4];
        cristalPierceParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[10];
        cristalPierceParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[16];
        cristalPierceParticles.Play();
        cristalPierceParticles2.Play();
        cristalPierceParticles3.Play();

    }
}
