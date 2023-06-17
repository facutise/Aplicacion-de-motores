using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigorCardsDisplay : MonoBehaviour,IDisplayable
{
    public VigorCards card;
    [SerializeField]
    private Text nametext;
    [SerializeField]
    private Text descriptiontext;
    [SerializeField]
    private Image image;

    
    public Text vigortext;
    [SerializeField]
    private VigorDeck vigorscriptdeck;
    [SerializeField]
    private int myslot;
    
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

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
        thevigorCostOfMyCard = card.vigorcost;

    }
    public void SetEnemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void UpdateUiCardInfo()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
    }
    public int TheVigorCostOfMyCard()
    {
        thevigorCostOfMyCard = card.vigorcost;
        return (thevigorCostOfMyCard);
    }
    public void ExecuteCardPassive()
    {
        NameOfVigorCardAndExecutePassive = card.name;

        switch (NameOfVigorCardAndExecutePassive)
        {
            case "Warrior Pendant":
                stadisticplayerScipt.health += 8;
                ProtectionTottemPa();
                PlayAudio(WarriorPendantAudio);
                Debug.Log("te has curado 5 puntos de salud");
                break;
            case "Senpukku":

                ProtectionTottemPa();
                enemyy.health -= 4;
                if (stadisticplayerScipt.health <= 20)
                {
                    enemyy.health -= 3;
                }
                Debug.Log("has cometido Senpukku");
                break;
            case "Sacrifice":

                enemyy.health -= 12;
                ProtectionTottemPa();
                stadisticplayerScipt.health -= 3;
                Debug.Log("te has inflingido daño pero mucho mas al enemigo");
                break;
            case "Spirit Growth":

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
                stadisticplayerScipt.vigor += 5;
                ProtectionTottemPa();
                Debug.Log("te has aumentado 5 puntos de vigor");
                break;
            case "Protection Tottem":
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
                enemyy.health -= 9;
                ProtectionTottemPa();
                PlayAudio(CaosAudio);
                Debug.Log("Has inflingido 9 de daño");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Dead eye":
                enemyy.health -= 7;
                stadisticplayerScipt.health += 3;
                ProtectionTottemPa();
                PlayAudio(DeadEyeAudio);
                Debug.Log("Has inflingido 7 de daño y te has curado 2 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Prominence burn":
                enemyy.health -= 3;
                stadisticplayerScipt.health += 3;
                ProtectionTottemPa();
                Debug.Log("Has inflingido 3 de daño y te has curado 3 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Absolution":
                enemyy.health -= 6;
                stadisticplayerScipt.health += 4;
                ProtectionTottemPa();
                Debug.Log("Has inflingido 6 de daño y te has curado 4 puntos de salud");
                Debug.Log("Al enemigo le queda " + enemyy.health + " de vida ");
                break;
            case "Uncontrolled pride":
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
