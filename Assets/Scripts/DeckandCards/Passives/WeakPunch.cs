using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPunch : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[1].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[7].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[13].Play();
        stadisticPlayerScript.PlayAudio(stadisticPlayerScript.bigBangAudio);
        bigbangParticles = stadisticPlayerScript.damageParticlesInTheCombats[1];
        bigBangParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[7];
        bigBangparticles3 = stadisticPlayerScript.damageParticlesInTheCombats[13];
        bigbangParticles.Play();
        bigBangParticles2.Play();
        bigBangparticles3.Play();

        Debug.Log("se ha usado weak punch");
    }
}
