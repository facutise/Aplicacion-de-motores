using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//TP2-Marco Lavacchielli
public class CombatPosition : MonoBehaviour
{
    [SerializeField] private Combat combatScript;
    [SerializeField] private List<GameObject> enemyObj;
    [SerializeField] private Transform enemyTransf;
    [SerializeField] private GameObject areaWhereTheEnemySpawns;
    [SerializeField] private List<GameObject> areasWhereTheEnemiesSpawns;
    [SerializeField] private int counterForPlacesWhereEnemiesSpawns;
    public bool battlePosition = false;
    public bool combatON = false;
    public bool enemyInvoke = false;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Player player;
    [SerializeField] private List<CinemachineVirtualCamera> cameras;
    public CinemachineVirtualCamera activeCamera;
    private GameManager myGM;
    [SerializeField] private MyCamera cameraScript;
    [SerializeField] private int enemiesReminder;
    [SerializeField] private Deck deckScript;
    [SerializeField] private VigorDeck vigorDeckScript;
    public VigorCardsDisplay scriptVigorCardDisplaySlot4;
    public VigorCardsDisplay scriptVigorCardDisplaySlot5;
    public VigorCardsDisplay scriptVigorCardDisplaySlot6;
    [SerializeField] private StadisticPlayer stadisticPlayerScript;
    [SerializeField] private EnemyHeathPointsUI enemyHealthPointsScript;
    private AudioSource myAudioSource;
    [SerializeField] private AudioClip cardSwipe;
    [SerializeField] private AudioClip enemyDiesAudio;
    [SerializeField] private float transitionCounter;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        myGM = GameManager.instance;
    }

    public void Update()
    {
        if (combatON)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void PlayAudio(AudioClip AC)
    {
        myAudioSource.clip = AC;
        myAudioSource.Play();
    }

    public void RunOutOfCombat()
    {
        enemiesReminder--;

        if (enemiesReminder <= 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            SwitchCamera(cameras[0]);
            PlayAudio(enemyDiesAudio);
            myGM.ActiveUI();

            combatScript.EmptyHandAtEndOfCombat();
            deckScript.EmptyListOfMyCardsBuildForCombat();
            vigorDeckScript.EmptyListOfMyVigorCardsBuildForCombat();

            battlePosition = false;
            player.enabled = true;
            playerRB.constraints = RigidbodyConstraints.None;
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            combatON = false;
            enemyInvoke = false;
            Debug.Log("Saliste del combate");
        }
    }

    public void CombatON()
    {
        battlePosition = true;
        PlayAudio(cardSwipe);
        cameraScript.enabled = false;
        myGM.ActiveUI();
        player.enabled = false;
        vigorDeckScript.CreateListOfMyCardBuildForCombat();
        deckScript.CreateListOfMyCardBuildForCombat();
        mainCamera.transform.LookAt(enemyTransf);
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("Entraste en combate");
        //deckScript.DrawCards();//COMENTAR AL DESCOMENTAR LO DE ABAJO
        //vigorDeckScript.DrawCards();//COMENTAR AL DESCOMENTAR LO DE ABAJO
        combatScript.DrawCardsStartCombat();
        combatON = true;
    }

    public void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        activeCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            cameraScript.canMoveCamera = false;
            enemiesReminder = 1;
            Vector3 direccion = new Vector3(15, 1, 15);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[1]);
                CombatON();
            }
        }
        else if (other.gameObject.layer == 13)
        {
            Destroy(other.gameObject);
            cameraScript.canMoveCamera = false;
            enemiesReminder = 1;
            Vector3 direccion = new Vector3(0, 1, 5);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[2]);
                CombatON();
            }
        }
        else if (other.gameObject.layer == 14)
        {
            Destroy(other.gameObject);
            cameraScript.canMoveCamera = false;
            enemiesReminder = 1;
            Vector3 direccion = new Vector3(-120, 1, 80);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[3]);
                CombatON();
            }
        }
        else if (other.gameObject.layer == 17)
        {
            Destroy(other.gameObject);
            cameraScript.canMoveCamera = false;
            enemiesReminder = 1;
            Vector3 direccion = new Vector3(-147, 1, 67);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[4]);
                CombatON();
            }
        }
    }

    void EnemyInvoke()
    {
        Enemy actualenemy = Instantiate(enemyObj[counterForPlacesWhereEnemiesSpawns], areasWhereTheEnemiesSpawns[counterForPlacesWhereEnemiesSpawns].transform.position, areasWhereTheEnemiesSpawns[counterForPlacesWhereEnemiesSpawns].transform.rotation).GetComponent<Enemy>();

        actualenemy.SetCombat(this);
        actualenemy.SetPlayer(stadisticPlayerScript);
        stadisticPlayerScript.SetEnemy(actualenemy);//PARTE DEL NUEVO SISTEMA DE PASIVAS
        combatScript.setenemy(actualenemy);
       
        enemyHealthPointsScript.SetEnemyInEnemyHealthPoints(actualenemy);
        //scriptVigorCardDisplaySlot4.SetEnemy(actualenemy);
        //scriptVigorCardDisplaySlot5.SetEnemy(actualenemy);
        //scriptVigorCardDisplaySlot6.SetEnemy(actualenemy);
        enemyInvoke = true;
        counterForPlacesWhereEnemiesSpawns++;
    }
}

