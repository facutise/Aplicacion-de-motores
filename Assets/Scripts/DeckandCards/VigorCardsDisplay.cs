using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TP2-"Facundo Sebastian Tisera"
public class VigorCardsDisplay : MonoBehaviour, IDisplayable
{
    public VigorCards Card;
    [SerializeField]
    private Text NameText;
    [SerializeField]
    private Text DescriptionText;
    [SerializeField]
    private Image Image;


    public Text VigorText;
    [SerializeField]
    private VigorDeck VigorScriptDeck;
    [SerializeField]
    private int MySlot;

    public int thevigorCostOfMyCard;


    private string NameOfVigorCardAndExecutePassive;

    public int thePLaceOfTheSkillInTheArray;


    [SerializeField]
    protected StadisticPlayer stadisticplayerScipt;

    protected int SpiritGrowthStacks;
    protected int ProtectionTottemStacks;
    [SerializeField]
    protected Enemy enemyy;
    [SerializeField]
    protected AudioSource MyAudioSource;
    [SerializeField]
    protected AudioClip WarriorPendantAudio;
    [SerializeField]
    protected AudioClip DeadEyeAudio;
    [SerializeField]
    protected AudioClip CaosAudio;

    [SerializeField]
    protected ParticleSystem[] DamageParticlesInTheCombats;

    protected ParticleSystem warriorPendantParticles;
    protected ParticleSystem warriorPendantParticles2;
    protected ParticleSystem warriorPendantParticles3;

    protected ParticleSystem senpukkuParticles;
    protected ParticleSystem senpukkuParticles2;
    protected ParticleSystem senpukkuParticles3;

    protected ParticleSystem sacrificeParticles;
    protected ParticleSystem sacrificeParticles2;
    protected ParticleSystem sacrificeParticles3;

    protected ParticleSystem spiritGrowthParticles;
    protected ParticleSystem spiritGrowthParticles2;
    protected ParticleSystem spiritGrowthParticles3;

    protected ParticleSystem unbreakeableParticles;
    protected ParticleSystem unbreakeableParticles2;
    protected ParticleSystem unbreakeableParticles3;

    protected ParticleSystem protetionTottemParticles;
    protected ParticleSystem protetionTottemParticles2;
    protected ParticleSystem protetionTottemParticles3;

    protected ParticleSystem caosParticles;
    protected ParticleSystem caosParticles2;
    protected ParticleSystem caosParticles3;

    protected ParticleSystem deadEyeParticles;
    protected ParticleSystem deadEyeParticles2;
    protected ParticleSystem deadEyeParticles3;

    protected ParticleSystem prominanceBurnParticles;
    protected ParticleSystem prominanceBurnParticles2;
    protected ParticleSystem prominanceBurnParticles3;

    protected ParticleSystem absolutionParticles;
    protected ParticleSystem absolutionParticles2;
    protected ParticleSystem absolutionParticles3;

    protected ParticleSystem uncontrolledPrideParticles;
    protected ParticleSystem uncontrolledPrideParticles2;
    protected ParticleSystem uncontrolledPrideParticles3;


    private static Dictionary<string, VigorCards> VigorcardDictionary = new Dictionary<string, VigorCards>();

    private void Awake()
    {
        // Agregamos las cartas al diccionario cuando se crea cada objeto CardDisplay
        if (Card != null && !VigorcardDictionary.ContainsKey(Card.name))
        {
            VigorcardDictionary.Add(Card.name, Card);
        }
    }

    public static VigorCards GetVigorCardByName(string name)
    {
        if (VigorcardDictionary.ContainsKey(name))
        {
            return VigorcardDictionary[name];
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
    private void Start()
    {

        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;

        VigorText.text = Card.vigorcost.ToString();
        thevigorCostOfMyCard = Card.vigorcost;

    }
    public void SetEnemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void UpdateUiCardInfo()
    {
        NameText.text = Card.name;
        DescriptionText.text = Card.description;
        Image.sprite = Card.image;

        VigorText.text = Card.vigorcost.ToString();
    }
    public int TheVigorCostOfMyCard()
    {
        thevigorCostOfMyCard = Card.vigorcost;
        return (thevigorCostOfMyCard);
    }
    public virtual void ExecuteCardPassive()
    {
        thePLaceOfTheSkillInTheArray = Card.myPassiveInt;
        stadisticplayerScipt.arrayOfCardPassives[thePLaceOfTheSkillInTheArray].MySkill();
        


    }

}
