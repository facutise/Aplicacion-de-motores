using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public interface IDisplayable
{
    void PlayAudio(AudioClip AC);
    void UpdateUiCardInfo();
    void ExecuteCardPassive();
}

public class CardDisplay : MonoBehaviour, IDisplayable
{
    private static Dictionary<string, Card> cardDictionary = new Dictionary<string, Card>();

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
    private CardsPassives[] arrayOfCardPassives;

    private void Awake()
    {
        // Agregamos las cartas al diccionario cuando se crea cada objeto CardDisplay
        if (Card != null && !cardDictionary.ContainsKey(Card.name))
        {
            cardDictionary.Add(Card.name, Card);
        }
    }

    private void Start()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;
        AttackText.text = Card.attack.ToString();
    }

    public static Card GetCardByName(string name)
    {
        if (cardDictionary.ContainsKey(name))
        {
            return cardDictionary[name];
        }
        else
        {
            Debug.LogWarning($"No se encontró la carta con el nombre: {name}");
            return null;
        }
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

    public void TestForSystemOfSkills(int TheSkillInt)
    {
        arrayOfCardPassives[TheSkillInt].MySkill();
    }

    public virtual void ExecuteCardPassive()
    {
        thePLaceOfTheSkillInTheArray = Card.myPassiveInt;
        StatsPlayerScript.arrayOfCardPassives[thePLaceOfTheSkillInTheArray].MySkill();
    }
}