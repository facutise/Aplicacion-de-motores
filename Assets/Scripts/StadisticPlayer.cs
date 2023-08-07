using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//TPFINAL-"Facundo Sebastian Tisera"


public class StadisticPlayer : MonoBehaviour
{
    public int health = 50;
    public int vigor = 1;
    public int defense;
    public GameManager _myGM;
    public int spiritGrowthStacks;//NUEVO PONER EN EL UML
    public int protectionTottemStacks;// NUEVO PONER EN EL UML 

    [SerializeField]
    public ParticleSystem[] damageParticlesInTheCombats;
    [SerializeField]
    public AudioSource myAudioSource;

    public AudioClip bigBangAudio;

    public AudioClip fireExplosionAudio;

    public AudioClip destructionAudio;

    public AudioClip normalAudioCard;
    //Termina variables de cartas normales
  
    public Enemy enemyy;

    public AudioSource myVigorAudioSource;

    public AudioClip warriorPendantAudio;

    public AudioClip deadEyeAudio;

    public AudioClip caosAudio;
    //terminan variables de carddisplay;
    [SerializeField]
    public CardsPassives[] arrayOfCardPassives;
   

    public void PlayAudio(AudioClip AC)
    {
        myAudioSource.clip = AC;
        myAudioSource.Play();
    }
    public void VigorPlayAudio(AudioClip AC)
    {
        myVigorAudioSource.clip = AC;
        myVigorAudioSource.Play();
    }
    public void SetEnemy(Enemy enemy)//crear una refe a este script en combatposition y setear esta funcion HECHO
    {
        enemyy = enemy;
    }
    public void ProtectionTottemPassive()
    {
        if (protectionTottemStacks >= 5)
        {
            health += 1;
        }

    }
    public void Update()
    {
        if (health > 50)
        {
            health = 50;
        }

        if (health <= 0)
        {
            PlayerDies();
        }
    }

    public void PlayerDies()
    {
        SceneManager.LoadScene("MainScene");
    }
}
