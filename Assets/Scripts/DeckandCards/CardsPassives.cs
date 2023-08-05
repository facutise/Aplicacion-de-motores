using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsPassives : MonoBehaviour
{
    //TP2-"Facundo Sebastian Tisera"

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

    public virtual void MySkill()
    {
       
    }
}
