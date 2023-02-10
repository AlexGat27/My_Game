using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Slider healthSlider;
    public Text healthText;
    public Slider protectSlider;
    public Text protectText;

    private int protection;
    private float timeProtect = 0f;
    public int maxProtection = 10;
    public int reprotection = 1;
    public float maxtimeProtect = 3f;

    [SerializeField]private float timeToRegen = 5f;
    private bool canToRegen;
    private void Start()
    {
        health = maxHealth;
        canToRegen = true;
        healthSlider.maxValue = maxHealth;
        protection = maxProtection;
        protectSlider.maxValue = maxProtection;
        SetSlider();
    }

    private void Update()
    {
        if (canToRegen)
        {
            if (timeProtect > maxtimeProtect)
            {
                Reprotection(reprotection);
                timeProtect = 0;
            }
            else timeProtect += Time.deltaTime;

            if (timeRegenerate > maxtimeRegenerate)
            {
                Regenerate(regenerateHealth);
                timeRegenerate = 0;
            }
            else timeRegenerate += Time.deltaTime;
        }
    }

    public void Regenerate(int bonus) //Функция регенерации.
    {
        SetHealth(bonus);
        SetSlider();
    }

    public void Reprotection(int bonus) //Функция восстановления защиты.
    {
        protection += bonus;
        if (protection > maxProtection) protection = maxProtection;
    }

    public void TakeDamage(int damage)
    {
        if (protection <= 0) TakeHit(damage);
        else
        {
            protection -= damage;
            if (protection < 0) protection = 0;
            gameObject.GetComponent<Animator>().SetTrigger("damage");
        }
        SetSlider();
        canToRegen = false;
        Invoke("AfterHitToRegen", timeToRegen);
    }

    private void SetSlider()
    {
        protectSlider.value = protection;
        protectText.text = protection.ToString() + " / " + maxProtection.ToString();
        healthSlider.value = health;
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
    }

    private void AfterHitToRegen()
    {
        canToRegen = true;
    }
}
