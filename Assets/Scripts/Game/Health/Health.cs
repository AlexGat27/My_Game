using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /*
        ������ ��� �������� �������� ���� �������� �� �����, �� ��������� �� ����������.
        �� ����� ����� ���������� ��� �������� ����, ��� ��������������� ���
     */
    public int health;
    public int maxHealth = 10;
    public int regenerateHealth = 1;
    public float maxtimeRegenerate = 5f;
    protected float timeRegenerate = 0f;

    protected void TakeHit(int damage) // ������� �������� ������
    {
        health -= damage;
        gameObject.GetComponent<Animator>().SetTrigger("damage");
    }

    protected void SetHealth(int bonusHealth) // ������� �������
    {
        health += bonusHealth;
        if (health > maxHealth) health = maxHealth;
    }
}
