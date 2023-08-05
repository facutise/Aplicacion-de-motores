using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//TP2-Marco Lavacchielli
public class CombatPosition : MonoBehaviour
{
    [SerializeField] private Combat combatscript;
    [SerializeField] private List<GameObject> enemygobj;
    [SerializeField] private Transform enemytransf;
    [SerializeField] private GameObject areawheretheenemyspawns;
    [SerializeField] private List<GameObject> areaswheretheenemiesspawns;
    [SerializeField] private int counterforplaceswhereenemiesspawns;
    public bool battlePosition = false;
    public bool combatON = false;
    public bool enemyInvoke = false;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Player player;
    [SerializeField] private List<CinemachineVirtualCamera> cameras;
    public CinemachineVirtualCamera activecamera;
    private GameManager myGM;
    [SerializeField] private MyCamera camerascript;
    [SerializeField] private int enemiesreminder;
    [SerializeField] private Deck deckscript;
    [SerializeField] private VigorDeck vigordeckscript;
    public VigorCardsDisplay scriptvigorcarddisplayslot4;
    public VigorCardsDisplay scriptvigorcarddisplayslot5;
    public VigorCardsDisplay scriptvigorcarddisplayslot6;
    [SerializeField] private StadisticPlayer stadisticplayerscript;
    [SerializeField] private EnemyHeathPointsUI enemyhealthpointsscript;
    private AudioSource myaudiosource;
    [SerializeField] private AudioClip cardswipe;
    [SerializeField] private AudioClip enemydiesaudio;
    [SerializeField] private float transitioncounter;

    private void Awake()
    {
        myaudiosource = GetComponent<AudioSource>();
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
        myaudiosource.clip = AC;
        myaudiosource.Play();
    }

    public void RunOutOfCombat()
    {
        enemiesreminder--;

        if (enemiesreminder <= 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            SwitchCamera(cameras[0]);
            PlayAudio(enemydiesaudio);
            myGM.ActiveUI();

            combatscript.EmptyHandAtEndOfCombat();
            deckscript.EmptyListOfMyCardsBuildForCombat();
            vigordeckscript.EmptyListOfMyVigorCardsBuildForCombat();

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
        PlayAudio(cardswipe);
        camerascript.enabled = false;
        myGM.ActiveUI();
        player.enabled = false;
        vigordeckscript.CreateListOfMyCardBuildForCombat();
        deckscript.CreateListOfMyCardBuildForCombat();
        mainCamera.transform.LookAt(enemytransf);
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("Entraste en combate");
        //deckscript.DrawCards();//COMENTAR AL DESCOMENTAR LO DE ABAJO
        //vigordeckscript.DrawCards();//COMENTAR AL DESCOMENTAR LO DE ABAJO
        combatscript.DrawCardsStartCombat();
        combatON = true;
    }

    public void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        activecamera = camera;

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

            Destroy(areawheretheenemyspawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[1]);
                CombatON();
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

            Destroy(areawheretheenemyspawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[2]);
                CombatON();
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

            Destroy(areawheretheenemyspawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[3]);
                CombatON();
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

            Destroy(areawheretheenemyspawns.gameObject);

            if (!combatON)
            {
                SwitchCamera(cameras[4]);
                CombatON();
            }
        }
    }

    void EnemyInvoke()
    {
        Enemy actualenemy = Instantiate(enemygobj[counterforplaceswhereenemiesspawns], areaswheretheenemiesspawns[counterforplaceswhereenemiesspawns].transform.position, areaswheretheenemiesspawns[counterforplaceswhereenemiesspawns].transform.rotation).GetComponent<Enemy>();

        actualenemy.Setcombat(this);
        actualenemy.SetPlayer(stadisticplayerscript);
        stadisticplayerscript.SetEnemy(actualenemy);//PARTE DEL NUEVO SISTEMA DE PASIVAS
        combatscript.setenemy(actualenemy);
       
        enemyhealthpointsscript.SetEnemyInEnemyHealthPoints(actualenemy);
        //scriptvigorcarddisplayslot4.SetEnemy(actualenemy);
        //scriptvigorcarddisplayslot5.SetEnemy(actualenemy);
        //scriptvigorcarddisplayslot6.SetEnemy(actualenemy);
        enemyInvoke = true;
        counterforplaceswhereenemiesspawns++;
    }
}

