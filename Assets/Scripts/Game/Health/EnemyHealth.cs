using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private Enemy enemy;
    [SerializeField]private float stopRemaining;
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        TakeHit(damage);
        enemy.StopEnemy();
        Invoke("StartEnemyCor", stopRemaining);
        if (health <= 0) Destroy(gameObject);
    }

    private void StartEnemyCor() // Корутина, за счет которой противник восстанавливает движение
    {
        enemy.StartEnemy();
    }
}
