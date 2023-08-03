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
    }
}
