using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BooletPlayer : Bullet
{
    public Shooting shooting;
    void Start()
    {
        Starting();
        shooting = GameObject.Find("Gun").GetComponent<Shooting>();
        if (shooting.isOnShot) direction = Shooting.target.transform.position - transform.position;
        else
        {
            float angle = shooting.angleRot * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Debug.Log(angle);
        }
        rb.AddForce(direction.normalized * bulspeed * 0.1f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.transform.GetComponent<EnemyHealth>())
                collision.transform.GetComponent<EnemyHealth>().TakeDamage(damageBullet);
            if (collision.transform.GetComponent<BossHealth>())
                collision.transform.GetComponent<BossHealth>().TakeBossDamage(damageBullet);
        }
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != thingstag)
            Destroy(gameObject);
    }

}
