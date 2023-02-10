using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health
{
    private Slider sliderhealth;
    private Animator slideranim;
    void Start()
    {
        sliderhealth = GameObject.Find("SliderBossHealth").GetComponent<Slider>();
        slideranim = sliderhealth.GetComponent<Animator>();
        sliderhealth.maxValue = maxHealth;
        sliderhealth.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRegenerate <= maxtimeRegenerate) timeRegenerate += Time.deltaTime;
        else
        {
            RegenerateBoss(regenerateHealth);
            timeRegenerate = 0;
        }
    }

    public void TakeBossDamage(int damage)
    {
        TakeHit(damage);
        sliderhealth.value -= damage;
        slideranim.SetTrigger("damage");
    }

    public void RegenerateBoss(int countHealth)
    {
        SetHealth(countHealth);
        sliderhealth.value += countHealth;
        slideranim.SetTrigger("regenerate");
    }
}
