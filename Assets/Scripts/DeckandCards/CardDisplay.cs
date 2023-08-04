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
        //NameOfTheCardAndExecutePassive = Card.name;
        //thePLaceOfTheSkillInTheArray = Card.attack;// FUE PRUEBA, ELIMINAR. YA QUE FUNCIONA CREAR UN NUEVO INT(acorde al array) EN LOS SCRIPTABLE OBJCTS PARA INCORPORARLO ACA
        //Debug.Log("execute passive llamada corretamente");
        //StatsPlayerScript.arrayOfCardPassives[0].MySkill();//prueba a ver si era el switch 
        //ERA EL SWITCH!
        thePLaceOfTheSkillInTheArray = Card.myPassiveInt;
        StatsPlayerScript.arrayOfCardPassives[thePLaceOfTheSkillInTheArray].MySkill();


    }
}
