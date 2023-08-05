using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2-Marco Lavacchielli
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Combat combat;
    [SerializeField] private CombatPosition _combatposition;
    public int health;
    [SerializeField] private string enemytype;
    public StadisticPlayer playerstadisticsscript;
    [SerializeField] private Transform ataqueenemy1spawnpoint;
    [SerializeField] private Transform ataqueenemigo2spawnpoint;
    [SerializeField] private Transform ataqueenemy1spawnpoint_combate2;
    [SerializeField] private Transform ataqueenemigo2spawnpoint_combate2;
    [SerializeField] private Transform ataqueenemy1spawnpoint_combate3;
    [SerializeField] private Transform ataqueenemigo2spawnpoint_combate3;

    private ParticleSystem ataqueenemy1;
    private ParticleSystem ataqueenemigo2;
    private ParticleSystem debris;
    private ParticleSystem ataqueenemy1_combate2;
    private ParticleSystem ataqueenemigo2_combate2;
    private ParticleSystem debris_combate2;
    private ParticleSystem ataqueenemy1_combate3;
    private ParticleSystem ataqueenemigo2_combate3;
    private ParticleSystem debris_combate3;

    public virtual void Start()
    {
        Enemyapears();
        GameObject PlayerObject = GameObject.Find("Player");

        if (PlayerObject != null)
        {
            combat = PlayerObject.GetComponent<Combat>();
        }

        ataqueenemy1 = GameObject.Find("AtaqueEnemy1").GetComponent<ParticleSystem>();
        ataqueenemigo2 = GameObject.Find("AtaqueEnemigo2").GetComponent<ParticleSystem>();
        debris = GameObject.Find("Debris").GetComponent<ParticleSystem>();
        ataqueenemy1_combate2 = GameObject.Find("AtaqueEnemy1_Combat2").GetComponent<ParticleSystem>();
        ataqueenemigo2_combate2 = GameObject.Find("AtaqueEnemigo2_Combat2").GetComponent<ParticleSystem>();
        debris_combate2 = GameObject.Find("Debris_Combat2").GetComponent<ParticleSystem>();
        ataqueenemy1_combate3 = GameObject.Find("AtaqueEnemy1_Combat3").GetComponent<ParticleSystem>();
        ataqueenemigo2_combate3 = GameObject.Find("AtaqueEnemigo2_Combat3").GetComponent<ParticleSystem>();
        debris_combate3 = GameObject.Find("Debris_Combat3").GetComponent<ParticleSystem>();

        ataqueenemy1.Stop();
        ataqueenemigo2.Stop();
        debris.Stop();
        ataqueenemy1_combate2.Stop();
        ataqueenemigo2_combate2.Stop();
        debris_combate2.Stop();
        ataqueenemy1_combate3.Stop();
        ataqueenemigo2_combate3.Stop();
        debris_combate3.Stop();
    }

    void Enemyapears()
    {
        Debug.Log("Aparecio un " + enemytype);
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
        _combatposition = combatPosition;
    }

    public void SetPlayer(StadisticPlayer playerreference)
    {
        playerstadisticsscript = playerreference;
    }

    public virtual void EnemyDies()
    {
        if (health <= 0)
        {
            combat.EndOfCombat();
            playerstadisticsscript.vigor = 3;
            _combatposition.RunOutOfCombat();
            Destroy(gameObject);
        }
    }

    public void PlayBasicAttackParticles()
    {
        ataqueenemy1.Play();
        ataqueenemy1_combate2.Play();
        ataqueenemy1_combate3.Play();
    }

    public void PlayHeavyAttackParticles()
    {
        ataqueenemigo2.Play();
        ataqueenemigo2_combate2.Play();
        ataqueenemigo2_combate3.Play();

        debris.Play();
        debris_combate2.Play();
        debris_combate3.Play();
    }
}
