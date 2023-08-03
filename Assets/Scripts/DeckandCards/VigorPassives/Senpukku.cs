using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senpukku : CardsPassives
{
    public override void MySkill()
    {
        stadisticPlayerScript.damageParticlesInTheCombats[3].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[9].Play();
        stadisticPlayerScript.damageParticlesInTheCombats[15].Play();
        stadisticPlayerScript.enemyy.health -= 4;
        if (stadisticPlayerScript.health <= 20)
        {
            stadisticPlayerScript.enemyy.health -= 3;
        }
        Debug.Log("has cometido Senpukku");
        /*
        senpukkuParticles = DamageParticlesInTheCombats[3];
        senpukkuParticles2 = DamageParticlesInTheCombats[9];
        senpukkuParticles3 = DamageParticlesInTheCombats[15];
        senpukkuParticles.Play();
        senpukkuParticles2.Play();
        senpukkuParticles3.Play();
        ProtectionTottemPa();
        enemyy.health -= 4;
        if (stadisticplayerScipt.health <= 20)
        {
            enemyy.health -= 3;
        }*/
    }
}
