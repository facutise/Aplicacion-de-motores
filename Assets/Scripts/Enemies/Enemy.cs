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

   

    public virtual void Start()
    {
        EnemyAppears();
        GameObject PlayerObject = GameObject.Find("Player");

        if (PlayerObject != null)
        {
            combat = PlayerObject.GetComponent<Combat>();
        }

        
    }

    void EnemyAppears()
    {
        Debug.Log("Aparecio un " + enemyType);
    }

    private void Update()
    {
        EnemyDies();
    }

    public virtual void EnemyTurn()
    {

    }

    public void SetCombat(CombatPosition combatPosition)
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

   
}
