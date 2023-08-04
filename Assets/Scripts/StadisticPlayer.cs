using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//TP2-"Facundo Sebastian Tisera"


public class StadisticPlayer : MonoBehaviour
{
    public int health = 30;
    public int vigor = 1;
    public int defense;
    public GameManager _myGM;
    public int spiritGrowthStacks;//NUEVO PONER EN EL UML
    public int protectionTottemStacks;// NUEVO PONER EN EL UML 

    public Dictionary<string, CardDisplay> cardDisplayPassives = new Dictionary<string, CardDisplay>();


    [SerializeField]
    public ParticleSystem[] damageParticlesInTheCombats;
    [SerializeField]
    public AudioSource myAudioSource;

    public AudioClip bigBangAudio;

    public AudioClip fireExplosionAudio;

    public AudioClip destructionAudio;

    public AudioClip normalAudioCard;
    //Termina variables de cartas normales
    [SerializeField]
    public Enemy enemyy;

    public AudioSource myVigorAudioSource;

    public AudioClip warriorPendantAudio;

    public AudioClip deadEyeAudio;

    public AudioClip caosAudio;
    //terminan variables de carddisplay;
    [SerializeField]
    public CardsPassives[] arrayOfCardPassives;
    public SacredFont sacredFontScript;
    public FireExplosion fireExplosionscript;
    public Destruction destructionscript;
    public CristalPierce cristalpiercescript;
    public BigBang bigBangscript;

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
        if (health > 30)
        {
            health = 30;
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
