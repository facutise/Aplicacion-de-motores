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
        sacredFontParticles = stadisticPlayerScript.damageParticlesInTheCombats[0];
        sacredFontParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[6];
        sacredFontParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[12];
        sacredFontParticles.Play();
        sacredFontParticles2.Play();
        sacredFontParticles3.Play();
        stadisticPlayerScript.health += 5;
        stadisticPlayerScript.PlayAudio(stadisticPlayerScript.normalAudioCard);
        Debug.Log("te has curado 5 puntos de salud");

        
        
    }

}
