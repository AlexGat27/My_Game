using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
{
    public string hittag;
    public int enemyDamage;
    public float maxtimeRecharge = 1f;
    public float timeRecharge = 0f;
    public float kickpower = 2f;

    private void Start()
    {
        timeRecharge = maxtimeRecharge;
    }
    private void Update()
    {
        if (timeRecharge < maxtimeRecharge) timeRecharge += Time.deltaTime;
        else timeRecharge = maxtimeRecharge;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == hittag && maxtimeRecharge == timeRecharge)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            Vector2 directionForce = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(directionForce * kickpower, ForceMode2D.Impulse);
            timeRecharge = 0f;
        }
    }
}
