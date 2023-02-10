using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private TriggerDoor[] levelDoors;
    [SerializeField]private GameObject[] exits;
    [SerializeField]private float maxTimeclose = 3f;
    [SerializeField]private SpawnBossLevel spawn;
    private float timeclose;
    public int currentRoom;
    public int maxRooms = 4;
    public int withEnemysRoom;
    void Start()
    {
        exits[0].SetActive(false);
        currentRoom = 0;
        withEnemysRoom = 0;
        timeclose = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoom < maxRooms) {
            if (!levelDoors[currentRoom].isOnTrigger && levelDoors[currentRoom].isOnroom && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                if (timeclose < maxTimeclose) timeclose += Time.deltaTime;
                else
                {
                    timeclose = 0;
                    exits[currentRoom].SetActive(true);
                    if (currentRoom % 2 == 0)
                    {
                        spawn.SpawnMobsRoom(withEnemysRoom);
                        withEnemysRoom++;
                    }
                    currentRoom++;
                }
            }
            else
            {
                Debug.Log("wefwef");
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && currentRoom % 2 != 0)
                {
                    exits[currentRoom].SetActive(false);
                    exits[currentRoom + 1].SetActive(false);
                }
                timeclose = 0;
            }
        }

        
    }
}
