using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BossBiologi : Boss
{
    [SerializeField] private GameObject bullet;
    private bool update1;
    private bool update2;
    private int countbullet;
    // Update is called once per frame
    void Start()
    {
        Starting();
        update1 = false;
        update2 = false;
        countbullet = 3;
    }
    void Update()
    {
        if (bosshealth.health <= angryHelth1 && bosshealth.health > angryHelth2 && !update1 && !update2) SetUpdate1();
        if (bosshealth.health <= angryHelth2 && bosshealth.health > angryHelth3 && !update2 && update1) SetUpdate2();
        if (bosshealth.health <= angryHelth3 && update1 && update2 ) SetUpdate3();

        Recharging();

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
            new Vector2(player.transform.position.x, player.transform.position.y)) <= detectedDistance)
        {
            direction = player.transform.position - transform.position;
            if (direction.x < 0) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            else transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            if (timerecharge1 >= timerecharge1Max)
            {
                Attack1();
                timerecharge1 = 0;
            }
            if (timerecharge2 >= timerecharge2Max && update1)
            {
                Attack2();
                timerecharge2 = 0;
            }
            if (timerecharge3 >= timerecharge3Max && update2)
            {
                Attack3();
                timerecharge3 = 0;
            }
        }
    }

    private void Attack1()
    {
        Vector2 direct = player.transform.position - transform.position;
        GameObject bult = Instantiate(bullet, transform.position, transform.rotation, transform);
        bult.GetComponent<BossBullet>().FireBulletBoss(direct);
        if (countbullet % 2 != 0)
        {
            for (int i = 1; i < countbullet; i += 2)
            {
                GameObject bultleft = Instantiate(bullet, transform.position, transform.rotation, transform);
                Vector2 direct1 = new Vector2(direct.x * (i + 1), direct.y);
                bultleft.GetComponent<BossBullet>().FireBulletBoss(direct1);
                GameObject bulright = Instantiate(bullet, transform.position, transform.rotation, transform);
                Vector2 direct2 = new Vector2(direct.x, direct.y * (i + 1));
                bulright.GetComponent<BossBullet>().FireBulletBoss(direct2);
            }
        }
        else
        {
            for (int i = 1; i < countbullet; i++)
            {
                Invoke("Attack1", 0.5f);
            }
        }
        
    }
    private void Attack2()
    {

    }
    private void Attack3()
    {

    }
    private void SetUpdate1()
    {
        update1 = true;
        Debug.Log("Update");
        countbullet = 5;
        timerecharge1Max -= 0.5f;
    }
    private void SetUpdate2()
    {
        update2 = true;
        timerecharge2Max -= 2f;
    }
    private void SetUpdate3()
    {
        timerecharge1Max -= 0.5f;
        timerecharge2Max -= 2f;
        timerecharge3Max -= 2f;
    }


}
