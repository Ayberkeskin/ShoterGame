using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float enemyMaxHealht = 100f;
    [SerializeField] float currentHealht;
    [SerializeField] HealthBar healthBarScript;

    private void Start()
    {
        currentHealht = enemyMaxHealht;
        healthBarScript.HealthBarProgress(currentHealht,enemyMaxHealht);
        healthBarScript.transform.gameObject.SetActive(false);
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealht -= damageAmount;
        healthBarScript.HealthBarProgress(currentHealht, enemyMaxHealht);

        if (currentHealht <= 0f)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
