using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredFont : CardDisplay
{
    public override void ExecuteCardPassive()
    {
        //sacredFontParticles.Play(); FUNCIONA
        sacredFontParticles = DamageParticlesInTheCombats[0];
        sacredFontParticles2 = DamageParticlesInTheCombats[6];
        sacredFontParticles3 = DamageParticlesInTheCombats[12];
        sacredFontParticles.Play();
        sacredFontParticles2.Play();
        sacredFontParticles3.Play();
        StatsPlayerScript.health += 5;
        PlayAudio(NormalAudioCard);
        Debug.Log("te has curado 5 puntos de salud");

    }

}
