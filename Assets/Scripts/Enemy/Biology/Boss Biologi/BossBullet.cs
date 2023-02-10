using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bullet
{
    public void FireBulletBoss(Vector2 direct)
    {
        transform.parent = null;
        direction = direct;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction.normalized * bulspeed * 0.1f, ForceMode2D.Impulse);
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
