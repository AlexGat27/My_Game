using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject player;
    public Enemy enemy;
    public GameObject shotpos, boolet;

    [HideInInspector] public bool isOnShot;
    public float distanceLimit = 5f;
    public string playertag = "Player";
    [HideInInspector] public float angleRot;

    public float recharge = 0.5f;
    private float timeRecharge;
    public int damageWeapon;
    void Start()
    {
        timeRecharge = recharge;
        player = GameObject.FindGameObjectWithTag(playertag);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = player.transform.position - transform.position;
        if (difference.magnitude <= distanceLimit) isOnShot = true;
        else isOnShot = false;
        angleRot = Mathf.Atan2(enemy.direction.y, enemy.direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angleRot);
        if (timeRecharge < recharge) timeRecharge += Time.deltaTime;
        Fire();
    }

    private void Fire()
    {
        if (isOnShot && timeRecharge >= recharge)
        {
            Instantiate(boolet, shotpos.transform.position, transform.rotation, transform);
            timeRecharge = 0;
        }
    }
}
