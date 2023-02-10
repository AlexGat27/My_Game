using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /*
        Скрипт для хранения здоровья всех объектов на сцене, от персонажа до противника.
        По тегам можем определить кто получает урон, или восстанавливает его
     */
    public int health;
    public int maxHealth = 10;
    public int regenerateHealth = 1;
    public float maxtimeRegenerate = 5f;
    protected float timeRegenerate = 0f;

    protected void TakeHit(int damage) // Функция принятия дамага
    {
        health -= damage;
        gameObject.GetComponent<Animator>().SetTrigger("damage");
    }

    protected void SetHealth(int bonusHealth) // Функция аптечки
    {
        health += bonusHealth;
        if (health > maxHealth) health = maxHealth;
    }
}
