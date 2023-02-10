using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject player;

    public float startTimeBtnAttack = 0.5f;
    public float timeBtnAttack;
    public int damage = 1;
    public float attackRange;

    public Animator anim;
    public Transform attackPos;
    public LayerMask enemy;

    // Update is called once per frame
    void Update()
    {
        if (timeBtnAttack >= 0) timeBtnAttack -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void OnAttack() // Вызывается от кнопки, включает анимацию
    {
        if (timeBtnAttack <= 0)
        {
            anim.SetTrigger("attack");
            timeBtnAttack = startTimeBtnAttack;
        }
    }

    public void SetDamage() //Вызывается по событию из анимации, наносит урон при опускании оружие
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
            Vector2 directionForce = enemies[i].transform.position - player.transform.position;
            if (enemies[i].GetComponent<Rigidbody2D>())
                enemies[i].GetComponent<Rigidbody2D>().AddForce(directionForce * 3, ForceMode2D.Impulse);
        }
    }
}
