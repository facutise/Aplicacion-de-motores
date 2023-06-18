using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigorCardsDisplay : MonoBehaviour,IDisplayable
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

    //public Player player;
    [SerializeField]
    private StadisticPlayer stadisticplayerScipt;
    
    private int SpiritGrowthStacks;
    private int ProtectionTottemStacks;
    [SerializeField]
    private Enemy enemyy;
    [SerializeField]
    private AudioSource MyAudioSource;
    [SerializeField]
    private AudioClip WarriorPendantAudio;
    [SerializeField]
    private AudioClip DeadEyeAudio;
    [SerializeField]
    private AudioClip CaosAudio;

    [SerializeField]
    private ParticleSystem[] DamageParticlesInTheCombats;

    private ParticleSystem warriorPendantParticles;
    private ParticleSystem warriorPendantParticles2;
    private ParticleSystem warriorPendantParticles3;

    private ParticleSystem senpukkuParticles;
    private ParticleSystem senpukkuParticles2;
    private ParticleSystem senpukkuParticles3;

    private ParticleSystem sacrificeParticles;
    private ParticleSystem sacrificeParticles2;
    private ParticleSystem sacrificeParticles3;

    private ParticleSystem spiritGrowthParticles;
    private ParticleSystem spiritGrowthParticles2;
    private ParticleSystem spiritGrowthParticles3;

    private ParticleSystem unbreakeableParticles;
    private ParticleSystem unbreakeableParticles2;
    private ParticleSystem unbreakeableParticles3;

    private ParticleSystem protetionTottemParticles;
    private ParticleSystem protetionTottemParticles2;
    private ParticleSystem protetionTottemParticles3;

    private ParticleSystem caosParticles;
    private ParticleSystem caosParticles2;
    private ParticleSystem caosParticles3;

    private ParticleSystem deadEyeParticles;
    private ParticleSystem deadEyeParticles2;
    private ParticleSystem deadEyeParticles3;

    private ParticleSystem prominanceBurnParticles;
    private ParticleSystem prominanceBurnParticles2;
    private ParticleSystem prominanceBurnParticles3;

    private ParticleSystem absolutionParticles;
    private ParticleSystem absolutionParticles2;
    private ParticleSystem absolutionParticles3;

    private ParticleSystem uncontrolledPrideParticles;
    private ParticleSystem uncontrolledPrideParticles2;
    private ParticleSystem uncontrolledPrideParticles3;
    // private void Awake()
    //{
    //MyAudioSource = GetComponent<AudioSource>();
    //}
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
    public void ExecuteCardPassive()
    {
        NameOfVigorCardAndExecutePassive = Card.name;

        switch (NameOfVigorCardAndExecutePassive)
        {
            case "Warrior Pendant":
                warriorPendantParticles = DamageParticlesInTheCombats[5];
                warriorPendantParticles2 = DamageParticlesInTheCombats[11];
                warriorPendantParticles3 = DamageParticlesInTheCombats[17];
                warriorPendantParticles.Play();
                warriorPendantParticles2.Play();
                warriorPendantParticles3.Play();
                stadisticplayerScipt.health += 8;
                ProtectionTottemPa();
                PlayAudio(WarriorPendantAudio);
                Debug.Log("te has curado 5 puntos de salud");
                break;
            case "Senpukku":
                senpukkuParticles = DamageParticlesInTheCombats[3];
                senpukkuParticles2 = DamageParticlesInTheCombats[9];
                senpukkuParticles3 = DamageParticlesInTheCombats[15];
                senpukkuParticles.Play();
                senpukkuParticles2.Play();
                senpukkuParticles3.Play();
                ProtectionTottemPa();
                enemyy.health -= 4;
                if (stadisticplayerScipt.health <= 20)
                {
                    enemyy.health -= 3;
                }
                Debug.Log("has cometido Senpukku");
                break;
            case "Sacrifice":
                sacrificeParticles = DamageParticlesInTheCombats[2];
                sacrificeParticles2 = DamageParticlesInTheCombats[8];
                sacrificeParticles3 = DamageParticlesInTheCombats[14];
                sacrificeParticles.Play();
                sacrificeParticles2.Play();
                sacrificeParticles3.Play();
                enemyy.health -= 12;
                ProtectionTottemPa();
                stadisticplayerScipt.health -= 3;
                Debug.Log("te has inflingido daño pero mucho mas al enemigo");
                break;
            case "Spirit Growth":
                spiritGrowthParticles = DamageParticlesInTheCombats[4];
                spiritGrowthParticles2 = DamageParticlesInTheCombats[10];
                spiritGrowthParticles3 = DamageParticlesInTheCombats[16];
                spiritGrowthParticles.Play();
                spiritGrowthParticles2.Play();
                spiritGrowthParticles3.Play();
                SpiritGrowthStacks += 1;
                enemyy.health -= 1;
                ProtectionTottemPa();
                if (SpiritGrowthStacks >= 3)
                {
                    enemyy.health -= 3;
                    Debug.Log("has inflingido 8 de daño con Spirit Growth");
                }
                break;
            case "Unbreakable":
                unbreakeableParticles = DamageParticlesInTheCombats[1];
                unbreakeableParticles2 = DamageParticlesInTheCombats[7];
                unbreakeableParticles3 = DamageParticlesInTheCombats[13];
                unbreakeableParticles.Play();
                unbreakeableParticles2.Play();
                unbreakeableParticles3.Play();
                stadisticplayerScipt.vigor += 5;
                ProtectionTottemPa();
                Debug.Log("te has aumentado 5 puntos de vigor");
                break;
            case "Protection Tottem":
                protetionTottemParticles = DamageParticlesInTheCombats[0];
                protetionTottemParticles2 = DamageParticlesInTheCombats[6];
                protetionTottemParticles3 = DamageParticlesInTheCombats[12];
                protetionTottemParticles.Play();
                protetionTottemParticles2.Play();
                protetionTottemParticles3.Play();
                stadisticplayerScipt.health += 1;
                ProtectionTottemPa();
                Debug.Log("te has curado 1 puntos de salud");
                ProtectionTottemStacks += 1;
                if (ProtectionTottemStacks == 5)
                {
                    Debug.Log("el tottem de proteccción ya está activado");
                }
                break;
            case "Caos":
                caosParticles = DamageParticlesInTheCombats[2];
                caosParticles2 = DamageParticlesInTheCombats[8];
                caosParticles3 = DamageParticlesInTheCombats[14];
                caosParticles.Play();
                caosParticles2.Play();
                caosParticles3.Play();
                enemyy.health -= 9;
                ProtectionTottemPa();
                PlayAudio(CaosAudio);
                Debug.Log("Has inflingido 9 de daño");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Dead eye":
                deadEyeParticles = DamageParticlesInTheCombats[5];
                deadEyeParticles2 = DamageParticlesInTheCombats[11];
                deadEyeParticles3 = DamageParticlesInTheCombats[17];
                deadEyeParticles.Play();
                deadEyeParticles2.Play();
                deadEyeParticles3.Play();
                enemyy.health -= 7;
                stadisticplayerScipt.health += 3;
                ProtectionTottemPa();
                PlayAudio(DeadEyeAudio);
                Debug.Log("Has inflingido 7 de daño y te has curado 2 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Prominence burn":
                prominanceBurnParticles = DamageParticlesInTheCombats[3];
                prominanceBurnParticles2 = DamageParticlesInTheCombats[9];
                prominanceBurnParticles3 = DamageParticlesInTheCombats[15];
                prominanceBurnParticles.Play();
                prominanceBurnParticles2.Play();
                prominanceBurnParticles3.Play();
                enemyy.health -= 3;
                stadisticplayerScipt.health += 3;
                ProtectionTottemPa();
                Debug.Log("Has inflingido 3 de daño y te has curado 3 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Absolution":
                absolutionParticles = DamageParticlesInTheCombats[4];
                absolutionParticles2 = DamageParticlesInTheCombats[10];
                absolutionParticles3 = DamageParticlesInTheCombats[16];
                absolutionParticles.Play();
                absolutionParticles2.Play();
                absolutionParticles3.Play();
                enemyy.health -= 6;
                stadisticplayerScipt.health += 4;
                ProtectionTottemPa();
                Debug.Log("Has inflingido 6 de daño y te has curado 4 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Uncontrolled pride":
                unbreakeableParticles = DamageParticlesInTheCombats[2];
                unbreakeableParticles2 = DamageParticlesInTheCombats[7];
                unbreakeableParticles3 = DamageParticlesInTheCombats[13];
                unbreakeableParticles.Play();
                unbreakeableParticles2.Play();
                unbreakeableParticles3.Play();
                enemyy.health -= 5;
                Debug.Log("Has inflingido 5 de daño");
                ProtectionTottemPa();
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
        }


    }
    public void ProtectionTottemPa()
    {
        if (ProtectionTottemStacks >= 5)
        {
            stadisticplayerScipt.health += 1;
        }

    }
}
