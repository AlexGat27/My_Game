using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField]private float movingspeed;
    [SerializeField]private Transform playerTransform;
    [SerializeField] private string playerTag;
    void Start()
    {
        movingspeed = 4f;
        if (playerTransform == null)
        {
            if (playerTag == "") playerTag = "Player";
            playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
        }
        transform.position = new Vector3()
        {
            x = playerTransform.position.x,
            y = playerTransform.position.y,
            z = playerTransform.position.z - 10,
        };
    }


    void Update()
    {
        if (playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = playerTransform.position.x,
                y = playerTransform.position.y,
                z = playerTransform.position.z - 10,
            };
            Vector3 pos = Vector3.Lerp(transform.position, target, movingspeed * Time.deltaTime);
            transform.position = pos;
        }

    }
}
