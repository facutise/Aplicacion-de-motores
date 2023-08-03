using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBang : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[1].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[7].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[13].Play();
        stadisticPlayerScript.PlayAudio(stadisticPlayerScript.bigBangAudio);

        

    }
}
