using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsPassives : MonoBehaviour
{
    //EL PLAN ES QUE ESTE SEA EL PADRE, TIRAR TODOS LOS HIJOS EN PLAYER, CREAR UN ARRAY DE LOS HIJOS DE CARDPASSIVES EN stadisticplayer Y QUE LOS CARD DISPLAY
    // ACCEDAN A ELLOS A TRAVES DEL ARRAY EN UNA FUNCIÓN QUE RECIBA COMO PARAMETRO UN NUEVO INT QUE VOY A CREAR EN CARD Y DEPENDIENDO DE CUAL, ES EL SCRIPT HIJO QUE SE EJECUTA
    // EJEMPLO DE CARDDISPLAY: public void ExecutePassive(int intdelcard)
    // {
    //    stadisticplayerscript.cardpassivesArray[intdelcard].MySkill;
    // }

    //LAS variables van en stadisticplayer y las llamamos desde los hijos
    [SerializeField]
    protected StadisticPlayer stadisticPlayerScript;
    protected ParticleSystem sacredFontParticles;
    protected ParticleSystem sacredFontParticles2;
    protected ParticleSystem sacredFontParticles3;

    protected ParticleSystem bigbangParticles;
    protected ParticleSystem bigBangParticles2;
    protected ParticleSystem bigBangparticles3;

    protected ParticleSystem fireExplosionParticles;
    protected ParticleSystem fireExplosionParticles2;
    protected ParticleSystem fireExplosionParticles3;

    protected ParticleSystem destructionParticles;
    protected ParticleSystem destructionParticles2;
    protected ParticleSystem destructionParticles3;

    protected ParticleSystem cristalPierceParticles;
    protected ParticleSystem cristalPierceParticles2;
    protected ParticleSystem cristalPierceParticles3;

    public void Start()
    {

       
        /*sacredFontParticles = stadisticPlayerScript.damageParticlesInTheCombats[0];
        sacredFontParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[6];
        sacredFontParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[12];
        bigbangParticles = stadisticPlayerScript.damageParticlesInTheCombats[1];
        bigBangParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[7];
        bigBangparticles3 = stadisticPlayerScript.damageParticlesInTheCombats[13];
        fireExplosionParticles = stadisticPlayerScript.damageParticlesInTheCombats[2];
        fireExplosionParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[8];
        fireExplosionParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[14];
        destructionParticles = stadisticPlayerScript.damageParticlesInTheCombats[3];
        destructionParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[9];
        destructionParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[15];
        cristalPierceParticles = stadisticPlayerScript.damageParticlesInTheCombats[4];
        cristalPierceParticles2 = stadisticPlayerScript.damageParticlesInTheCombats[10];
        cristalPierceParticles3 = stadisticPlayerScript.damageParticlesInTheCombats[16];*/
    }
    public virtual void MySkill()
    {
        //cardDisplayScript.sacredFontParticles.Play(); //FUNCIONA
        //cardDisplayScript.DamageParticlesInTheCombats[0].Play(); // FUNCIONA
    }
}
