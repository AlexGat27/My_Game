using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossLevel : MonoBehaviour
{
    public Transform[] spawns;
    [SerializeField] private GameObject[] enemys1Room;
    [SerializeField] private GameObject[] enemys2Room;
    [SerializeField] private GameObject[] enemys3Room;
    [SerializeField] private GameObject[] enemys4Room;
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform bossspawn;
    private int[] countsEnemy;
    [SerializeField] private string enemytag = "Enemy";
    void Start()
    {
        countsEnemy = new int[spawns.Length];
        for (int i = 0; i < spawns.Length; i++)
            countsEnemy[i] = spawns[i].childCount;
    }

    public void SpawnMobsRoom(int room)
    {
        for (int j = 0; j < countsEnemy[room]; j++)
        {
            Transform[] points = spawns[room].GetComponentsInChildren<Transform>();
            int numspawn = UnityEngine.Random.Range(0, points.Length);
            switch (room)
            {
                case 0:
                    GameObject enemy1 = Instantiate(enemys1Room[UnityEngine.Random.Range(0, enemys1Room.Length)]);
                    enemy1.transform.position = points[numspawn].transform.position;
                    break;
                case 1:
                    GameObject enemy2 = Instantiate(enemys2Room[UnityEngine.Random.Range(0, enemys2Room.Length)]);
                    enemy2.transform.position = points[numspawn].transform.position;
                    break;
                case 2:
                    GameObject enemy3 = Instantiate(enemys3Room[UnityEngine.Random.Range(0, enemys3Room.Length)]);
                    enemy3.transform.position = points[numspawn].transform.position;
                    break;
                default:
                    GameObject enemy4 = Instantiate(enemys4Room[UnityEngine.Random.Range(0, enemys4Room.Length)]);
                    enemy4.transform.position = points[numspawn].transform.position;
                    break;
            }
        }
    }
}
