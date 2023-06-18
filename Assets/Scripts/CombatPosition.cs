using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CombatPosition : MonoBehaviour
{
    [SerializeField]
    private Combat combatscript;
    [SerializeField]
    private List<GameObject> enemyGObj;
    [SerializeField]
    private Transform enemytransf;
    [SerializeField]
    private GameObject areaWhereTheEnemySpawns;
    [SerializeField]
    private List<GameObject> AreasWhereTheEnemiesSpawns;
    [SerializeField]
    private int CounterforPlacesWhereEnemiesSpawns;
    public bool battlePosition = false;
    public bool CombatON = false;
    public bool enemyInvoke = false;
    [SerializeField]
    private Rigidbody playerRB;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Player player;
    [SerializeField]
    private List<CinemachineVirtualCamera> cameras;
    public CinemachineVirtualCamera ActiveCamera;
    private GameManager myGM;
    [SerializeField]
    private MyCamera camerascript;
    [SerializeField]
    private int enemiesreminder;
    [SerializeField]
    private Deck deckscript;
    [SerializeField]
    private VigorDeck vigordeckscript;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot4;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot5;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot6;
    [SerializeField]
    private StadisticPlayer stadisticPlayerScript;
    [SerializeField]
    private EnemyHeathPointsUI EnemyHealthPointsScript;
    private AudioSource MyAudioSource;
    [SerializeField]
    private AudioClip CardSwipe;
    [SerializeField]
    private AudioClip EnemyDiesAudio;
    [SerializeField]
    private float TransitionCounter;

    private void Awake()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        myGM = GameManager.instance;
    }

    public void Update()
    {
        if (CombatON)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }

    public void RunOutOfCombat()
    {
        enemiesreminder--;

        if (enemiesreminder <= 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            SwitchCamera(cameras[0]);
            PlayAudio(EnemyDiesAudio);
            myGM.activeUI();
            battlePosition = false;
            player.enabled = true;
            playerRB.constraints = RigidbodyConstraints.None;
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            CombatON = false;
            enemyInvoke = false;
            Debug.Log("Saliste del combate");
        }
    }

    public void combatON()
    {
        battlePosition = true;
        PlayAudio(CardSwipe);
        camerascript.enabled = false;
        myGM.activeUI();
        player.enabled = false;
        vigordeckscript.CreateListOfMyCardBuildForCombat();
        deckscript.CreateListOfMyCardBuildForCombat();
        mainCamera.transform.LookAt(enemytransf);
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("Entraste en combate");
        deckscript.DrawCards();
        vigordeckscript.DrawCards();
        CombatON = true;
    }

    public void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

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
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(15, 1, 15);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!CombatON)
            {
                SwitchCamera(cameras[1]);
                combatON();
            }
        }
        else if (other.gameObject.layer == 13)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(0, 1, 5);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!CombatON)
            {
                SwitchCamera(cameras[2]);
                combatON();
            }
        }
        else if (other.gameObject.layer == 14)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(-120, 1, 80);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!CombatON)
            {
                SwitchCamera(cameras[3]);
                combatON();
            }
        }
        else if (other.gameObject.layer == 17)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(-147, 1, 67);
            transform.LookAt(direccion);

            if (!enemyInvoke)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (!CombatON)
            {
                SwitchCamera(cameras[4]);
                combatON();
            }
        }
    }

    void EnemyInvoke()
    {
        Enemy actualenemy = Instantiate(enemyGObj[CounterforPlacesWhereEnemiesSpawns], AreasWhereTheEnemiesSpawns[CounterforPlacesWhereEnemiesSpawns].transform.position, AreasWhereTheEnemiesSpawns[CounterforPlacesWhereEnemiesSpawns].transform.rotation).GetComponent<Enemy>();

        actualenemy.Setcombat(this);
        actualenemy.SetPlayer(stadisticPlayerScript);
        combatscript.setenemy(actualenemy);
        EnemyHealthPointsScript.SetEnemyInEnemyHealthPoints(actualenemy);
        ScriptVigorCardDisplaySlot4.SetEnemy(actualenemy);
        ScriptVigorCardDisplaySlot5.SetEnemy(actualenemy);
        ScriptVigorCardDisplaySlot6.SetEnemy(actualenemy);
        enemyInvoke = true;
        CounterforPlacesWhereEnemiesSpawns++;
    }
}

