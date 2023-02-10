using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    public PlayerAttack sword;

    public float speed;
    public float dirX, dirY;
    public bool isrun;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isRight = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;
        if (dirX > 0 && !isRight)
        {
            Flip();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dirX < 0 && isRight)
        {
            Flip();
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Attack()
    {
        sword.SetDamage();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
        if (dirX != 0 && dirY != 0)
        {
            isrun = true;
        }
        else isrun = false;
        anim.SetBool("run", isrun);
    }

    private void Flip()
    {
        isRight = !isRight;
    }


}
