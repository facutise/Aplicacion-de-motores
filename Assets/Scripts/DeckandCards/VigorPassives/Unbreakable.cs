using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unbreakable : VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        unbreakeableParticles = DamageParticlesInTheCombats[1];
        unbreakeableParticles2 = DamageParticlesInTheCombats[7];
        unbreakeableParticles3 = DamageParticlesInTheCombats[13];
        unbreakeableParticles.Play();
        unbreakeableParticles2.Play();
        unbreakeableParticles3.Play();
        stadisticplayerScipt.vigor += 5;
        ProtectionTottemPa();
        Debug.Log("te has aumentado 5 puntos de vigor");
    }
}
