using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : CardDisplay
{
    public override void ExecuteCardPassive()
    {
        destructionParticles = DamageParticlesInTheCombats[3];
        destructionParticles2 = DamageParticlesInTheCombats[9];
        destructionParticles3 = DamageParticlesInTheCombats[15];
        destructionParticles.Play();
        destructionParticles2.Play();
        destructionParticles3.Play();
        PlayAudio(DestructionAudio);
    }
}
