using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject[] enemyes;
    public GameObject shotpos, boolet;
    public static GameObject target;

    [HideInInspector]public bool isOnShot;
    public float distanceLimit = 5f;
    public string enemytag = "Enemy";
    [HideInInspector]public float angleRot;

    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyes = GameObject.FindGameObjectsWithTag(enemytag);
        if (enemyes.Length > 0)
        {
            target = enemyes[0];
            for (int i = 0; i < enemyes.Length; i++)
            {
                if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(enemyes[i].transform.position.x, enemyes[i].transform.position.y)) <
                    Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y)))
                {
                    target = enemyes[i];
                }
            }
            Vector3 difference = target.transform.position - transform.position;
            if (difference.magnitude <= distanceLimit)
            {
                angleRot = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                isOnShot = true;
            }
            else
            {
                isOnShot = false;
                if (player.dirY != 0 && player.dirX != 0) angleRot = Mathf.Atan2(player.dirY, player.dirX) * Mathf.Rad2Deg;
            }
        }
        else
        {
            isOnShot = false;
            if (player.dirY != 0 || player.dirX != 0) angleRot = Mathf.Atan2(player.dirY, player.dirX) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, angleRot);
    }

    public void Shot()
    {
        Instantiate(boolet, shotpos.transform.position, transform.rotation);
    }
}
