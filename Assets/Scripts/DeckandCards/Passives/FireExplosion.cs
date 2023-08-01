using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : CardDisplay
{
    public override void ExecuteCardPassive()
    {
        fireExplosionParticles = DamageParticlesInTheCombats[2];
        fireExplosionParticles2 = DamageParticlesInTheCombats[8];
        fireExplosionParticles3 = DamageParticlesInTheCombats[14];
        fireExplosionParticles.Play();
        fireExplosionParticles2.Play();
        fireExplosionParticles3.Play();
        PlayAudio(fireExplosionAudio);
    }
}
