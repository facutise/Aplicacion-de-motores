using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TP2 - Lucas Torres

public class inventoryObjectsActions : MonoBehaviour
{
    private int whispersCount;
    public int keyForTheBlackDoor;
    [SerializeField]
    private CombatPosition combatpositionscript;

    [SerializeField]
    private Camera mainCamera;
    public MenuManager menumanagerscript;
    [SerializeField] LayerMask doormask;

    public GameObject[] cardsOnInventory;
    public bool[] ActivatorsOfCards;
    public int CardsOnCountdown;

    AudioSource myAudioSource;
    public AudioClip openCardBox;

    public int healthPotions;
    public StadisticPlayer stadisticPlayerScript;

    public GameObject doorHolder;

    [SerializeField]
    private ParticleSystem healthPotionParticles;
    [SerializeField]
    private ParticleSystem healthPotionMiniParticles;
    [SerializeField]
    private ParticleSystem healthPlayerParticles;
    [SerializeField]
    private Light healthPotionLight;
    [SerializeField]
    private Light lightCardbox;
    [SerializeField]
    private Light demonWhispersLight;

    [SerializeField]
    private Animator animationDoor;

    delegate void delegateParticle();
    delegateParticle myDelegateparticle;
    private enum Layers
    {
        Whispers = 6,
        DoorsLocked = 7,
        Keys = 8,
        PatrolEnemy = 12,
        CardBox = 15,
        HealthPotions = 16
    }

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        myDelegateparticle += UsePotion;
        myDelegateparticle += Update;

        if (myDelegateparticle != null)
        {
            myDelegateparticle();
        }
    }
    public void PlayAudioInventory(AudioClip AC)
    {
        myAudioSource.clip = AC;
        myAudioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && healthPotions > 0 && combatpositionscript.combatON == true)
        {
            stadisticPlayerScript.health += 10;
            healthPotions -= 1;
            healthPlayerParticles.Play();
            Debug.Log("Te has curado 10 puntos de salud con una mejora de salud");
        }
    }

    public void UsePotion()
    {
        if (healthPotions > 0 && combatpositionscript.combatON == true)
        {
            stadisticPlayerScript.health += 10;
            healthPotions -= 1;
            healthPlayerParticles.Play();
            Debug.Log("Te has curado 10 puntos de salud con una mejora de salud");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Layers.CardBox)
        {
            ActivatorsOfCards[CardsOnCountdown] = true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            Debug.Log("Has obtenido una nueva carta [i] para ver el inventario");
            Destroy(other.gameObject);

            CardsOnCountdown += 1;
        }
        if (other.gameObject.layer == (int)Layers.HealthPotions)
        {
            healthPotions += 1;
            Destroy(other.gameObject);
            healthPotionLight.enabled = false;
            healthPotionParticles.Stop();
            healthPotionMiniParticles.Stop();
            Debug.Log("Obtuviste una pocion de curacion, para usarla puedes presionar H o tocar el icono desde el inventario, pero recuerda que solamente podras curarte estando en combate");
        }

        if (other.gameObject.layer == (int)Layers.Whispers)
        {
            whispersCount += 1;
            Destroy(other.gameObject);

            PlayAudioInventory(openCardBox);
            if (whispersCount == 1)
            {
                Debug.Log("Escucha atentamente Oswald, el combate está cerca. tienes dos mazos. uno de ellos me alimentará de tu vigor para darte" +
                    " gran parte de mi poder y pueden poner el combate a tu favor si lo usas con ingenio. Mientras más luches tu vigor aumentará" +
                    ", y por ende, más podré consumir de ti, así que trata de no morirte tan rápido");
            }
            else if (whispersCount == 2)
            {
                Debug.Log("Al presionar [i] entrarás en el inventario, presiona sobre una carta para equipartela. debes equiparte tanto" +
                    " cartas de vigor como cartas normales o no podrás derrotar a tus enemigos.");
            }
            else if (whispersCount == 3)
            {
                Debug.Log("El mazo que no consume tu vigor son sólo un suplemento, pero pueden ser muy oportunas. Te las di por pena...");
            }
            else if (whispersCount == 4)
            {
                Debug.Log("¿así usas mis cartas? eres decepcionante");
            }
        }
        if (other.gameObject.layer == (int)Layers.Keys)
        {
            keyForTheBlackDoor = 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == (int)Layers.DoorsLocked)
        {
            //puerta
            if (keyForTheBlackDoor == 1)
            {
                animationDoor.Play("AnimationDoor");
                Destroy(doorHolder);
            }

        }
        if (other.gameObject.layer == (int)Layers.PatrolEnemy)
        {
            menumanagerscript.Restartscene();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == (int)Layers.CardBox)
        {
            lightCardbox.enabled = false;
        }
        if (other.gameObject.layer == (int)Layers.Whispers)
        {
            demonWhispersLight.enabled = false;
        }
    }
}
