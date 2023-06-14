using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;
    public Text attacktext;
    public Deck scriptdeck;
    public int myslot;
    public int attackdmg;
    public string NombredelaCartayEjecutarPasiva;
    public Player player;
    public StadisticPlayer StatsPlayerScript;
    public AudioSource MyAudioSource;
    public AudioClip BigBangAudio;
    public AudioClip fireExplosionAudio;
    public AudioClip DestructionAudio;
    public AudioClip NormalAudioCard;

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

    public void actualizarinfodeUIdeCadaCarta()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;
        attacktext.text = card.attack.ToString();
    }

    public void ejecutarpasivadelacarta()
    {
        NombredelaCartayEjecutarPasiva = card.name;

        switch (NombredelaCartayEjecutarPasiva)
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
