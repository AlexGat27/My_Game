using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUpgrade : MonoBehaviour
{
    [SerializeField]private GameObject bombenemy;
    [SerializeField]private int countbomb = 2;
    public int bombdamage;
    public float radiusOnAttack;
    protected GameObject player;
    private Enemy enemy;
    protected bool isanimate;
    private Animator animator;
    private void Start()
    {
        isanimate = false;
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
            new Vector2(player.transform.position.x, player.transform.position.y)) <= enemy.stopdistance)
        {
            if (!isanimate)
            {
                isanimate = true;
                animator.SetBool("activateBomb", isanimate);
            }
        }
        else
        {
            if (isanimate)
            {
                isanimate = false;
                animator.SetBool("activateBomb", isanimate);
            }
        }
    }
    public void Exposion2Wave()
    {
        bool isonattack = Physics2D.OverlapCircle(transform.position, radiusOnAttack);
        if (isonattack && isanimate)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(bombdamage);
            for (int i = 0; i < countbomb;i++) Instantiate(bombenemy, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
