using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyMaxHealht = 100f;

    public void TakeDamage(float damageAmount)
    {
        enemyMaxHealht -= damageAmount;

        if (enemyMaxHealht<=0f)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
