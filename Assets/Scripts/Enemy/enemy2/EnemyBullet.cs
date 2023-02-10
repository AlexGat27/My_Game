using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    void Start()
    {
        Starting();
        damageBullet = GetComponentInParent<EnemyWeapon>().damageWeapon;
        transform.parent = null;
        direction = GameObject.FindGameObjectWithTag(playertag).transform.position - transform.position;
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
        if (collision.gameObject.tag == playertag)
        {
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(damageBullet);
        }
        if (collision.gameObject.tag != enemytag && collision.gameObject.tag != thingstag)
            Destroy(gameObject);
    }
}
