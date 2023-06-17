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

public class CardDisplay : MonoBehaviour,IDisplayable
{
    public Card card;
    [SerializeField]
    private Text nametext;
    [SerializeField]
    private Text descriptiontext;
    [SerializeField]
    private Image image;

    public Text attacktext;
    [SerializeField]
    private Deck scriptdeck;
    [SerializeField]
    private int myslot;

    public int attackdmg;
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
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;
        attacktext.text = card.attack.ToString();
    }

    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }

    public int Thecarddmg()
    {
        attackdmg = card.attack;
        return attackdmg;
    }

    public void UpdateUiCardInfo()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;
        attacktext.text = card.attack.ToString();
    }

    public void ExecuteCardPassive()
    {
        NameOfTheCardAndExecutePassive = card.name;

        switch (NameOfTheCardAndExecutePassive)
        {
            case "Sacred Font":
                StatsPlayerScript.health += 5;
                PlayAudio(NormalAudioCard);
                Debug.Log("te has curado 5 puntos de salud");
                break;

            case "Big Bang":
                PlayAudio(BigBangAudio);
                break;
            case "Fire Explosion":
                PlayAudio(fireExplosionAudio);
                break;
            case "Destruction":
                PlayAudio(DestructionAudio);
                break;
            case "cristal Pierce":
                PlayAudio(NormalAudioCard);
                break;
        }
    }
}
