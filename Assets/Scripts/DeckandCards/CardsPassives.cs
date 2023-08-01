using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardsPassives : MonoBehaviour
{
    //private ParticleSystem sacredFontParticles;
    public StadisticPlayer stadisticPlayerScript;
    public CardDisplay cardDisplayScript;
    public virtual void Start()
    {

        GameObject PlayerObject = GameObject.Find("Player");
    }


    public void SetPlayer(StadisticPlayer playerreference)
    {
        stadisticPlayerScript = playerreference;
    }
    public void SetCardDisplay(CardDisplay cardDisplayReference)
    {
        cardDisplayScript = cardDisplayReference;
    }
    public void MySkill()
    {
        //cardDisplayScript.sacredFontParticles.Play(); //FUNCIONA
        //cardDisplayScript.DamageParticlesInTheCombats[0].Play(); // FUNCIONA
    }
}
