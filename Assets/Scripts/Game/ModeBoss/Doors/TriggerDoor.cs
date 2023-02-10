using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public bool isOnroom;
    public bool isOnTrigger;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        isOnTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnTrigger = false;
        if (!isOnroom) isOnroom = true;
        else isOnroom = false;
    }
    void Start()
    {
        isOnroom = false;
        isOnTrigger = false;
    }

}
