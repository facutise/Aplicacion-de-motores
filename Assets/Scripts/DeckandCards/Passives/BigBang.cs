using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBang : CardDisplay
{
    public override void ExecuteCardPassive()
    {
        bigbangParticles = DamageParticlesInTheCombats[1];
        bigBangParticles2 = DamageParticlesInTheCombats[7];
        bigBangparticles3 = DamageParticlesInTheCombats[13];
        bigbangParticles.Play();
        bigBangParticles2.Play();
        bigBangparticles3.Play();
        PlayAudio(BigBangAudio);

    }
}
