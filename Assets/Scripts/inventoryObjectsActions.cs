using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TPFINAL - Lucas Torres

public class inventoryObjectsActions : MonoBehaviour
{
    private int whispersCount;
    public int keyForTheBlackDoor;
    [SerializeField]
    private CombatPosition combatPositionScript;

    [SerializeField]
    private Camera mainCamera;
    public MenuManager menuManagerScript;
    [SerializeField] LayerMask doorMask;

    public GameObject[] cardsOnInventory;
    public bool[] activatorsOfCards;
    public int cardsOnCountdown;

    private AudioSource myAudioSource;
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

    delegate void DelegateParticle();
    DelegateParticle myDelegateParticle;
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
        myDelegateParticle += ParticleEffects;
    }

    private void OnDestroy()
    {
        myDelegateParticle -= ParticleEffects;
    }
    public void PlayAudioInventory(AudioClip AC)
    {
        myAudioSource.clip = AC;
        myAudioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && healthPotions > 0 && combatPositionScript.combatON == true)
        {
            if (myDelegateParticle != null)
            {
                myDelegateParticle.Invoke();
            }
            stadisticPlayerScript.health += 30;
            healthPotions -= 1;
            //healthPlayerParticles.Play();
            Debug.Log("Te has curado 30 puntos de salud con una mejora de salud");
        }
    }

    private void ParticleEffects()
    {
        healthPlayerParticles.Play();
    }
    public void UsePotion()
    {
        if (healthPotions > 0 && combatPositionScript.combatON == true)
        {
            if (myDelegateParticle != null)
            {
                myDelegateParticle.Invoke();
            }
            stadisticPlayerScript.health += 30;
            healthPotions -= 1;
            //healthPlayerParticles.Play();
            Debug.Log("Te has curado 30 puntos de salud con una mejora de salud");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Layers.CardBox)
        {
            activatorsOfCards[cardsOnCountdown] = true;
            cardsOnInventory[cardsOnCountdown].gameObject.SetActive(activatorsOfCards[cardsOnCountdown]);
            Debug.Log("Has obtenido una nueva carta [i] para ver el inventario");
            Destroy(other.gameObject);

            cardsOnCountdown += 1;
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
                Debug.Log("Escucha atentamente Oswald, el combate est� cerca. tienes dos mazos. uno de ellos me alimentar� de tu vigor para darte" +
                    " gran parte de mi poder y pueden poner el combate a tu favor si lo usas con ingenio. Mientras m�s luches tu vigor aumentar�" +
                    ", y por ende, m�s podr� consumir de ti, as� que trata de no morirte tan r�pido");
            }
            else if (whispersCount == 2)
            {
                Debug.Log("Al presionar [i] entrar�s en el inventario, presiona sobre una carta para equipartela. debes equiparte tanto" +
                    " cartas de vigor como cartas normales o no podr�s derrotar a tus enemigos.");
            }
            else if (whispersCount == 3)
            {
                Debug.Log("El mazo que no consume tu vigor son s�lo un suplemento, pero pueden ser muy oportunas. Te las di por pena...");
            }
            else if (whispersCount == 4)
            {
                Debug.Log("�as� usas mis cartas? eres decepcionante");
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
            menuManagerScript.Restartscene();
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
