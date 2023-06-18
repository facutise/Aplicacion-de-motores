using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IDisplayable
{
    public void PlayAudio(AudioClip AC);
    public void UpdateUiCardInfo();
    public void ExecuteCardPassive();

}


public class CardDisplay : MonoBehaviour, IDisplayable
{
    [SerializeField]
    private ParticleSystem[] DamageParticlesInTheCombats;

    private ParticleSystem sacredFontParticles;
    private ParticleSystem sacredFontParticles2;
    private ParticleSystem sacredFontParticles3;

    private ParticleSystem bigbangParticles;
    private ParticleSystem bigBangParticles2;
    private ParticleSystem bigBangparticles3;

    private ParticleSystem fireExplosionParticles;
    private ParticleSystem fireExplosionParticles2;
    private ParticleSystem fireExplosionParticles3;

    private ParticleSystem destructionParticles;
    private ParticleSystem destructionParticles2;
    private ParticleSystem destructionParticles3;

    private ParticleSystem cristalPierceParticles;
    private ParticleSystem cristalPierceParticles2;
    private ParticleSystem cristalPierceParticles3;


    public Card Card;
    [SerializeField]
    private Text NameText;
    [SerializeField]
    private Text DescriptionText;
    [SerializeField]
    private Image Image;

    public Text AttackText;
    [SerializeField]
    private Deck ScriptDeck;
    [SerializeField]
    private int MySlot;

    public int AttackDamage;
    [SerializeField]
    private string NameOfTheCardAndExecutePassive;

    //public Player player;

    public StadisticPlayer StatsPlayerScript;
    [SerializeField]
    private AudioSource MyAudioSource;
    [SerializeField]
    private AudioClip BigBangAudio;
    [SerializeField]
    private AudioClip fireExplosionAudio;
    [SerializeField]
    private AudioClip DestructionAudio;
    [SerializeField]
    private AudioClip NormalAudioCard;

    private void Start()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;
        AttackText.text = Card.attack.ToString();
    }

    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }

    public int Thecarddmg()
    {
        AttackDamage = Card.attack;
        return AttackDamage;
    }

    public void UpdateUiCardInfo()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;
        AttackText.text = Card.attack.ToString();
    }

    public void ExecuteCardPassive()
    {
        NameOfTheCardAndExecutePassive = Card.name;

        switch (NameOfTheCardAndExecutePassive)
        {
            case "Sacred Font":
                sacredFontParticles = DamageParticlesInTheCombats[0];
                sacredFontParticles2 = DamageParticlesInTheCombats[6];
                sacredFontParticles3 = DamageParticlesInTheCombats[12];
                sacredFontParticles.Play();
                sacredFontParticles2.Play();
                sacredFontParticles3.Play();
                StatsPlayerScript.health += 5;
                PlayAudio(NormalAudioCard);
                Debug.Log("te has curado 5 puntos de salud");
                break;

            case "Big Bang":
                bigbangParticles = DamageParticlesInTheCombats[1];
                bigBangParticles2 = DamageParticlesInTheCombats[7];
                bigBangparticles3 = DamageParticlesInTheCombats[13];
                bigbangParticles.Play();
                bigBangParticles2.Play();
                bigBangparticles3.Play();
                PlayAudio(BigBangAudio);
                break;
            case "Fire Explosion":
                fireExplosionParticles = DamageParticlesInTheCombats[2];
                fireExplosionParticles2 = DamageParticlesInTheCombats[8];
                fireExplosionParticles3 = DamageParticlesInTheCombats[14];
                fireExplosionParticles.Play();
                fireExplosionParticles2.Play();
                fireExplosionParticles3.Play();
                PlayAudio(fireExplosionAudio);
                break;
            case "Destruction":
                destructionParticles = DamageParticlesInTheCombats[3];
                destructionParticles2 = DamageParticlesInTheCombats[9];
                destructionParticles3 = DamageParticlesInTheCombats[15];
                destructionParticles.Play();
                destructionParticles2.Play();
                destructionParticles3.Play();
                PlayAudio(DestructionAudio);
                break;
            case "cristal Pierce":
                cristalPierceParticles = DamageParticlesInTheCombats[4];
                cristalPierceParticles2 = DamageParticlesInTheCombats[10];
                cristalPierceParticles3 = DamageParticlesInTheCombats[16];
                cristalPierceParticles.Play();
                cristalPierceParticles2.Play();
                cristalPierceParticles3.Play();
                PlayAudio(NormalAudioCard);
                break;
        }
    }
}
