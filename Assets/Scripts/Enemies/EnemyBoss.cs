using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public override void Start()
    {
        base.Start();
    }
    public override void EnemyTurn()
    {
        if (health <= 50 && health > 30)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 40)
            {
                BasicDamage();
            }
            else if (Numero < 40)
            {
                HeavyDamage();
            }
        }
        else if (health > 15 && health <= 30)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 50)
            {
                BasicDamage();
            }
            else if (Numero2 < 50)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 15)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 60)
            {
                BasicDamage();
            }
            else if (Numero3 >= 20 && Numero3 < 60)
            {
                HeavyDamage();
            }
            else if (Numero3 < 20)
            {
                SuperHeavyDamage();
            }
            if (Numero3 <= 60)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        playerStadisticsScript.health -= 5;
        Debug.Log("El enemigo inflingio 5 de da�o al jugador con un ataque basico");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        playerStadisticsScript.health -= 7;
        Debug.Log("El enemigo inflingio 7 de da�o al jugador con un golpe pesado");
        PlayHeavyAttackParticles();
    }
    public void SuperHeavyDamage()
    {
        playerStadisticsScript.health -= 10;
        Debug.Log("El enemigo inflingio 10 de da�o al jugador con un golpe super pesado");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        health += 7;
        Debug.Log("El enemigo se curo 7 de vida");
    }
}
