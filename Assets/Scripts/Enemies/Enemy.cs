using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2-Marco Lavacchielli
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Combat combat;
    [SerializeField] private CombatPosition _combatPosition;
    public int health;
    [SerializeField] private string enemyType;
    public StadisticPlayer playerStadisticsScript;
    [SerializeField] private Transform attackEnemy1SpawnPoint;
    [SerializeField] private Transform attackEnemy2SpawnPoint;
    [SerializeField] private Transform attackEnemy1SpawnPoint_Combat2;
    [SerializeField] private Transform attackEnemigo2SpawnPoint_Combat2;
    [SerializeField] private Transform attackEnemy1SpawnPoint_Combat3;
    [SerializeField] private Transform attackEnemigo2SpawnPoint_Combat3;

    private ParticleSystem attackEnemy1;
    private ParticleSystem attackEnemy2;
    private ParticleSystem debris;
    private ParticleSystem attackEnemy1_Combat2;
    private ParticleSystem attackEnemy2_Combat2;
    private ParticleSystem debris_Combat2;
    private ParticleSystem attackEnemy1_Combat3;
    private ParticleSystem attackEnemy2_Combat3;
    private ParticleSystem debris_Combat3;

    public virtual void Start()
    {
        Enemyapears();
        GameObject PlayerObject = GameObject.Find("Player");

        if (PlayerObject != null)
        {
            combat = PlayerObject.GetComponent<Combat>();
        }

        attackEnemy1 = GameObject.Find("AtaqueEnemy1").GetComponent<ParticleSystem>();
        attackEnemy2 = GameObject.Find("AtaqueEnemigo2").GetComponent<ParticleSystem>();
        debris = GameObject.Find("Debris").GetComponent<ParticleSystem>();
        attackEnemy1_Combat2 = GameObject.Find("AtaqueEnemy1_Combat2").GetComponent<ParticleSystem>();
        attackEnemy2_Combat2 = GameObject.Find("AtaqueEnemigo2_Combat2").GetComponent<ParticleSystem>();
        debris_Combat2 = GameObject.Find("Debris_Combat2").GetComponent<ParticleSystem>();
        attackEnemy1_Combat3 = GameObject.Find("AtaqueEnemy1_Combat3").GetComponent<ParticleSystem>();
        attackEnemy2_Combat3 = GameObject.Find("AtaqueEnemigo2_Combat3").GetComponent<ParticleSystem>();
        debris_Combat3 = GameObject.Find("Debris_Combat3").GetComponent<ParticleSystem>();

        attackEnemy1.Stop();
        attackEnemy2.Stop();
        debris.Stop();
        attackEnemy1_Combat2.Stop();
        attackEnemy2_Combat2.Stop();
        debris_Combat2.Stop();
        attackEnemy1_Combat3.Stop();
        attackEnemy2_Combat3.Stop();
        debris_Combat3.Stop();
    }

    void Enemyapears()
    {
        Debug.Log("Aparecio un " + enemyType);
    }

    private void Update()
    {
        EnemyDies();
    }

    public virtual void Enemyturn()
    {

    }

    public void Setcombat(CombatPosition combatPosition)
    {
        _combatPosition = combatPosition;
    }

    public void SetPlayer(StadisticPlayer playerreference)
    {
        playerStadisticsScript = playerreference;
    }

    public virtual void EnemyDies()
    {
        if (health <= 0)
        {
            combat.EndOfCombat();
            playerStadisticsScript.vigor = 3;
            _combatPosition.RunOutOfCombat();
            Destroy(gameObject);
        }
    }

    public void PlayBasicAttackParticles()
    {
        attackEnemy1.Play();
        attackEnemy1_Combat2.Play();
        attackEnemy1_Combat3.Play();
    }

    public void PlayHeavyAttackParticles()
    {
        attackEnemy2.Play();
        attackEnemy2_Combat2.Play();
        attackEnemy2_Combat3.Play();

        debris.Play();
        debris_Combat2.Play();
        debris_Combat3.Play();
    }
}
