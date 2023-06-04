using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReduceHealth(float reduceHealth)
    {
        enemyHealth -= reduceHealth;
        if (enemyHealth <= 0)
        {
            Dead();
        }

    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
