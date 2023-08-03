using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredFont : CardsPassives
{
    public override void MySkill()
    {
        //sacredFontParticles.Play(); FUNCIONA
        stadisticPlayerScript.damageParticlesInTheCombats[0].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[6].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[12].Play();
        stadisticPlayerScript.health += 5;
        stadisticPlayerScript.PlayAudio(stadisticPlayerScript.normalAudioCard);
        Debug.Log("te has curado 5 puntos de salud");

        
        
    }

}
