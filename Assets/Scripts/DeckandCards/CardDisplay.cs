using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TP2-"Facundo Sebastian Tisera"

public interface IDisplayable
{
    public void PlayAudio(AudioClip AC);
    public void UpdateUiCardInfo();
    public void ExecuteCardPassive();

}


public class CardDisplay : MonoBehaviour, IDisplayable
{
    [SerializeField]
    protected ParticleSystem[] DamageParticlesInTheCombats;

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

    public int thePLaceOfTheSkillInTheArray;

    public int AttackDamage;
    [SerializeField]
    private string NameOfTheCardAndExecutePassive;

    //public Player player;

    public StadisticPlayer StatsPlayerScript;
    [SerializeField]
    protected AudioSource MyAudioSource;
    [SerializeField]
    protected AudioClip BigBangAudio;
    [SerializeField]
    protected AudioClip fireExplosionAudio;
    [SerializeField]
    protected AudioClip DestructionAudio;
    [SerializeField]
    protected AudioClip NormalAudioCard;

    [SerializeField]
    private CardsPassives[] arrayOfCardPassives;//ELIMINAR

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

    public void TestForSystemOfSkills(int TheSkillInt)//FUNCIONA: ESTO ES PARTE DEL NUEVO SISTEMA pero poner el array en stadisticplayer
    {
      
        arrayOfCardPassives[TheSkillInt].MySkill();// ESTA SERIA LA FUNCIÓN IDEAL JUNTO A UN DICCIONARIO EN STADISTICPLAYER QUE CONTENGA LOS SCRIPTS
    }

    public virtual void ExecuteCardPassive()
    {
        NameOfTheCardAndExecutePassive = Card.name;
        thePLaceOfTheSkillInTheArray = Card.attack;

        switch (NameOfTheCardAndExecutePassive)
        {
            case "Sacred Font":

                StatsPlayerScript.arrayOfCardPassives[0].MySkill();
                StatsPlayerScript.sacredFontScript.MySkill();
                /*sacredfontparticles = damageparticlesinthecombats[0];
                sacredfontparticles2 = damageparticlesinthecombats[6];
                sacredfontparticles3 = damageparticlesinthecombats[12];
                sacredfontparticles.play();
                sacredfontparticles2.play();
                sacredfontparticles3.play();
                statsplayerscript.health += 5;
                playaudio(normalaudiocard);
                debug.log("te has curado 5 puntos de salud");*/
                break;

            case "Big Bang":
                StatsPlayerScript.arrayOfCardPassives[4].MySkill();
                StatsPlayerScript.bigBangscript.MySkill();
                //bigbangParticles = DamageParticlesInTheCombats[1];
                //bigBangParticles2 = DamageParticlesInTheCombats[7];
                //bigBangparticles3 = DamageParticlesInTheCombats[13];
                //bigbangParticles.Play();
                //bigBangParticles2.Play();
                //bigBangparticles3.Play();
                //PlayAudio(BigBangAudio);
                break;
            case "Fire Explosion":

                StatsPlayerScript.arrayOfCardPassives[1].MySkill();
                StatsPlayerScript.fireExplosionscript.MySkill();
                //fireExplosionParticles = DamageParticlesInTheCombats[2];
                //fireExplosionParticles2 = DamageParticlesInTheCombats[8];
                //fireExplosionParticles3 = DamageParticlesInTheCombats[14];
                //fireExplosionParticles.Play();
                //fireExplosionParticles2.Play();
                //fireExplosionParticles3.Play();
                //PlayAudio(fireExplosionAudio);
                break;
            case "Destruction":
                StatsPlayerScript.arrayOfCardPassives[2].MySkill();
                StatsPlayerScript.destructionscript.MySkill();
                //destructionParticles = DamageParticlesInTheCombats[3];
                //destructionParticles2 = DamageParticlesInTheCombats[9];
                //destructionParticles3 = DamageParticlesInTheCombats[15];
                //destructionParticles.Play();
                //destructionParticles2.Play();
                //destructionParticles3.Play();
                //PlayAudio(DestructionAudio);
                break;
            case "Cristal Pierce"://tenia la primera letra en mayuscula, ahora a probar si funciona

                StatsPlayerScript.arrayOfCardPassives[3].MySkill();
                StatsPlayerScript.cristalpiercescript.MySkill();
                //cristalPierceParticles = DamageParticlesInTheCombats[4];
                //cristalPierceParticles2 = DamageParticlesInTheCombats[10];
                //cristalPierceParticles3 = DamageParticlesInTheCombats[16];
                //cristalPierceParticles.Play();
                //cristalPierceParticles2.Play();
                //cristalPierceParticles3.Play();
                //PlayAudio(NormalAudioCard);
                break;
        }
    }
}
