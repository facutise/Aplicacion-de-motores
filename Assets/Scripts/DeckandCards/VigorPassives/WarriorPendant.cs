using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorPendant : VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        warriorPendantParticles = DamageParticlesInTheCombats[5];
        warriorPendantParticles2 = DamageParticlesInTheCombats[11];
        warriorPendantParticles3 = DamageParticlesInTheCombats[17];
        warriorPendantParticles.Play();
        warriorPendantParticles2.Play();
        warriorPendantParticles3.Play();
        stadisticplayerScipt.health += 8;
        ProtectionTottemPa();
        PlayAudio(WarriorPendantAudio);
        Debug.Log("te has curado 5 puntos de salud");
    }
}
