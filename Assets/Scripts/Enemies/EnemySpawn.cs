using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    /*public Enemy Enemy;
    public Combat combatScript;
    public CombatPosition combatpositionscript;
    public List<GameObject> enemyObj;
    public Transform enemyTransf;
    public GameObject areaWhereTheEnemySpawns;
    public Player player;
    int enemiesReminder;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            enemiesReminder = 1;
            Enemy actualenemy = Instantiate(enemyObj[Random.Range(0, enemyObj.Count)], areaWhereTheEnemySpawns.transform.position, areaWhereTheEnemySpawns.transform.rotation).GetComponent<Enemy>();
            actualenemy.SetCombat(combatpositionscript);
            actualenemy.SetPlayer(player);
            combatScript.SetEnemy(actualenemy);
            Destroy(areaWhereTheEnemySpawns.gameObject);
            combatpositionscript.combatON();
        }
    }*/
}
