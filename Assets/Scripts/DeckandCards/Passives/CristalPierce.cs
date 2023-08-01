using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalPierce : CardDisplay
{
    public override void ExecuteCardPassive()
    {
        cristalPierceParticles = DamageParticlesInTheCombats[4];
        cristalPierceParticles2 = DamageParticlesInTheCombats[10];
        cristalPierceParticles3 = DamageParticlesInTheCombats[16];
        cristalPierceParticles.Play();
        cristalPierceParticles2.Play();
        cristalPierceParticles3.Play();
        PlayAudio(NormalAudioCard);
    }
}
