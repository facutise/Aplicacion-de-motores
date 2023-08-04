using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[3].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[9].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[15].Play();
        stadisticPlayerScript.PlayAudio(stadisticPlayerScript.destructionAudio);
        destructionParticles = stadisticPlayerScript.damageParticlesInTheCombats[3];
        destructionParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[9];
        destructionParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[15];
        destructionParticles.Play();
        destructionParticles2.Play();
        destructionParticles3.Play();

        Debug.Log("se ha usado destruction");

    }
}
