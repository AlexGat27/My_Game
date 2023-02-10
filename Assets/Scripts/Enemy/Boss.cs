using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    protected GameObject player;
    [SerializeField]protected float detectedDistance;
    protected BossHealth bosshealth;
    [SerializeField]protected string playertag = "Player";
    [SerializeField] protected Vector2 direction;

    [SerializeField] protected float timerecharge1;
    [SerializeField] protected float timerecharge1Max;
    [SerializeField] protected float timerecharge2;
    [SerializeField] protected float timerecharge2Max;
    [SerializeField] protected float timerecharge3;
    [SerializeField] protected float timerecharge3Max;


    [SerializeField] protected int angryHelth1;
    [SerializeField] protected int angryHelth2;
    [SerializeField] protected int angryHelth3;

    protected void Starting()
    {
        player = GameObject.FindGameObjectWithTag(playertag);
        bosshealth = gameObject.GetComponent<BossHealth>();
        timerecharge1 = timerecharge1Max;
        timerecharge2 = timerecharge2Max;
        timerecharge3 = timerecharge3Max;
    }
    protected void Recharging()
    {
        if (timerecharge1 <= timerecharge1Max) timerecharge1 += Time.deltaTime;
        if (timerecharge2 <= timerecharge2Max) timerecharge2 += Time.deltaTime;
        if (timerecharge3 <= timerecharge3Max) timerecharge3 += Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectedDistance);
    }
}
