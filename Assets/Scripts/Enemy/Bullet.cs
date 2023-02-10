using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulspeed, timer = 3f;
    [SerializeField]protected string playertag = "Player";
    [SerializeField] protected string enemytag = "Enemy";
    protected Vector2 direction;
    public int damageBullet;
    [SerializeField] protected string thingstag = "things";
    protected void Starting()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
