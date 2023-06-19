using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inventoryObjectsActions : MonoBehaviour
{
    private int WhispersCount;
    public int KeyForTheBlackDoor;
    [SerializeField]
    private  CombatPosition combatpositionscript;

    [SerializeField]
    private Camera mainCamera;
    public MenuManager menumanagerscript;
    [SerializeField] LayerMask doormask;

    public GameObject[] cardsOnInventory;
    public bool[] ActivatorsOfCards;
    public int CardsOnCountdown;

    AudioSource MyAudioSource;
    public AudioClip OpenCardBox;

    public int HealthPotions;
    public StadisticPlayer stadisticPlayerScript;

    public GameObject doorHolder;

    [SerializeField]
    private ParticleSystem healthPotionParticles;
    [SerializeField]
    private ParticleSystem healthPotionMiniParticles;

    [SerializeField]
    private Light healthPotionLight;
    [SerializeField]
    private Light lightCardbox;
    [SerializeField]
    private Light demonWhispersLight;

    [SerializeField]
    private Animator animationDoor;

    private void Awake()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioInventory(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && HealthPotions > 0 && combatpositionscript.CombatON == true)
        {
            stadisticPlayerScript.health += 10;
            HealthPotions -= 1;
            healthPotionParticles.Play();
            Debug.Log("Te has curado 10 puntos de salud con una mejora de salud");
        }
    }

    public void UsePotion()
    {
        if (HealthPotions > 0 && combatpositionscript.CombatON == true)
        {
            stadisticPlayerScript.health += 10;
            HealthPotions -= 1;
            healthPotionParticles.Play();
            Debug.Log("Te has curado 10 puntos de salud con una mejora de salud");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            ActivatorsOfCards[CardsOnCountdown] = true;
            cardsOnInventory[CardsOnCountdown].gameObject.SetActive(ActivatorsOfCards[CardsOnCountdown]);
            Debug.Log("Has obtenido una nueva carta [i] para ver el inventario");
            Destroy(other.gameObject);

            CardsOnCountdown += 1;
        }
        if (other.gameObject.layer == 16)
        {
            HealthPotions += 1;
            Destroy(other.gameObject);
            healthPotionLight.enabled = false;
            healthPotionParticles.Stop();
            healthPotionMiniParticles.Stop();
            Debug.Log("Obtuviste una pocion de curacion, para usarla puedes presionar H o tocar el icono desde el inventario, pero recuerda que solamente podras curarte estando en combate");
        }

        if (other.gameObject.layer == 6)
        {
            WhispersCount += 1;
            Destroy(other.gameObject);

            PlayAudioInventory(OpenCardBox);
            if (WhispersCount == 1)
            {
                Debug.Log("Escucha atentamente Oswald, el combate está cerca. tienes dos mazos. uno de ellos me alimentará de tu vigor para darte" +
                    " gran parte de mi poder y pueden poner el combate a tu favor si lo usas con ingenio. Mientras más luches tu vigor aumentará" +
                    ", y por ende, más podré consumir de ti, así que trata de no morirte tan rápido");
            }
            else if (WhispersCount == 2)
            {
                Debug.Log("Al presionar [i] entrarás en el inventario, presiona sobre una carta para equipartela. debes equiparte tanto" +
                    " cartas de vigor como cartas normales o no podrás derrotar a tus enemigos.");
            }
            else if (WhispersCount == 3)
            {
                Debug.Log("El mazo que no consume tu vigor son sólo un suplemento, pero pueden ser muy oportunas. Te las di por pena...");
            }
            else if (WhispersCount == 4)
            {
                Debug.Log("¿así usas mis cartas? eres decepcionante");
            }
        }
        if (other.gameObject.layer == 8)
        {
            KeyForTheBlackDoor = 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == 7)
        {
            //puerta
            if (KeyForTheBlackDoor == 1)
            {
                animationDoor.Play("AnimationDoor");
                Destroy(doorHolder);
            }

        }
        if (other.gameObject.layer == 12)
        {
            menumanagerscript.Restartscene();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 15)
        {
            lightCardbox.enabled = false;
        }
        if (other.gameObject.layer == 6)
        {
            demonWhispersLight.enabled = false;
        }
    }
}
