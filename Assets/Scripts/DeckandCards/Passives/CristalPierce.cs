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
        
    }
}
