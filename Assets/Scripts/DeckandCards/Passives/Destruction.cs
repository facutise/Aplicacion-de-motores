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
       
    }
}
