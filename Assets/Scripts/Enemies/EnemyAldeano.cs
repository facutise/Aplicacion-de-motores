using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFINAL-Marco Lavacchielli
public class EnemyAldeano : Enemy
{
    public override void Start()
    {
        base.Start();
    }
    public override void EnemyTurn()
    {
        if (health <= 10 && health > 8)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 20)
            {
                BasicDamage();
            }
            else if (Numero < 20)
            {
                HeavyDamage();
            }
        }
        else if (health > 5 && health <= 8)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 30)
            {
                BasicDamage();
            }
            else if (Numero2 < 30)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 5)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 40)
            {
                BasicDamage();
            }
            else if (Numero3 < 40)
            {
                HeavyDamage();
            }
            if (Numero3 <= 20)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        playerStadisticsScript.health -= 2;
        Debug.Log("El enemigo inflingio 2 de da�o al jugador con un ataque basico");
       
    }
    public void HeavyDamage()
    {
        playerStadisticsScript.health -= 4;
        Debug.Log("El enemigo inflingio 4 de da�o al jugador con un golpe pesado");
        
    }
    public void Regeneration()
    {
        health += 3;
        Debug.Log("El enemigo se curo 3 de vida");
    }
}