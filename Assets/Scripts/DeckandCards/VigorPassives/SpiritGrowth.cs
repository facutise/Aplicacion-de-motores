using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritGrowth : VigorCardsDisplay
{
    public override void ExecuteCardPassive()
    {
        spiritGrowthParticles = DamageParticlesInTheCombats[4];
        spiritGrowthParticles2 = DamageParticlesInTheCombats[10];
        spiritGrowthParticles3 = DamageParticlesInTheCombats[16];
        spiritGrowthParticles.Play();
        spiritGrowthParticles2.Play();
        spiritGrowthParticles3.Play();
        stadisticplayerScipt.spiritGrowthStacks += 1;
        enemyy.health -= 1;
        ProtectionTottemPa();
        if (stadisticplayerScipt.spiritGrowthStacks >= 3)
        {
            enemyy.health -= 3;
            Debug.Log("has inflingido 8 de daño con Spirit Growth");
        }
    }
}
