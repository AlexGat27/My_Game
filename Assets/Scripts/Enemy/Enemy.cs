using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public GameObject patrolPlace;
    public GameObject[] points;

    [SerializeField]private float angryspeed;
    [SerializeField]private float peacefulspeed = 2f;
    public float stopdistance;
    [SerializeField]private float detecteddistance;
    public Vector3 direction;

    protected int action = 0;
    private int rand = 0;
    private bool canrun = true;

    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        if (gameObject.GetComponent<Rigidbody2D>()) rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (action == 0 || action == 1)
        {
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
            new Vector2(player.transform.position.x, player.transform.position.y)) <= detecteddistance) action = 1;
            else action = 0;
        }

        if (canrun)
        {
            if (action == 0) patrolMove();
            else if (action == 1) toPlayerMove();
            else DistanceGo();
        }

        if (direction.x < 0) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    public void StopEnemy() { canrun = false;}
    public void StartEnemy() { canrun = true; }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (action == 0 && gameObject.GetComponent<Rigidbody2D>())
        {
            if (collision.gameObject.tag == "Enemy")
            {
                action = 2;
                if (patrolPlace.transform.parent == null) patrolPlace.transform.parent = transform;
                direction = transform.position - collision.transform.position;
                Invoke("SwitchAction", 2f);
            }
            else rand = Random.RandomRange(0, 8);
        }
        else rand = Random.RandomRange(0, 8);
    }

    private void patrolMove()
    {
        if (points.Length != 0)
        {
            if (patrolPlace.transform.parent != null)
                patrolPlace.transform.parent = null;
            if (transform.position != points[rand].transform.position)
            {
                direction = points[rand].transform.position - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, points[rand].transform.position, peacefulspeed * Time.deltaTime);
            }
            else rand = Random.RandomRange(0, 8);
        }
    }

    private void toPlayerMove()
    {
        if (patrolPlace.transform.parent == null)
            patrolPlace.transform.parent = transform;
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
            new Vector2(player.transform.position.x, player.transform.position.y)) >= stopdistance)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, angryspeed * Time.deltaTime);
        direction = player.transform.position - transform.position;
    }

    private void DistanceGo()
    {
        rb.MovePosition(rb.position + new Vector2(direction.x,direction.y) * Time.deltaTime * peacefulspeed*5f);
    }
    private void SwitchAction()
    {
        action = 0;
    }
}
