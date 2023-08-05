using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    /*public Enemy Enemy;
    public Combat combatscript;
    public CombatPosition combatpositionscript;
    public List<GameObject> enemyGObj;
    public Transform enemytransf;
    public GameObject areawheretheenemyspawns;
    public Player player;
    int enemiesreminder;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            enemiesreminder = 1;
            Enemy actualenemy = Instantiate(enemyGObj[Random.Range(0, enemyGObj.Count)], areawheretheenemyspawns.transform.position, areawheretheenemyspawns.transform.rotation).GetComponent<Enemy>();
            actualenemy.Setcombat(combatpositionscript);
            actualenemy.SetPlayer(player);
            combatscript.SetEnemy(actualenemy);
            Destroy(areawheretheenemyspawns.gameObject);
            combatpositionscript.combatON();
        }
    }*/
}
