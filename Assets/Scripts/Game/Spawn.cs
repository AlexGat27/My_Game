using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.VFX;

public class Spawn : MonoBehaviour
{
    public Transform[] spawns;
    [SerializeField]private GameObject[] enemys1Wave;
    [SerializeField] private GameObject[] enemys2Wave;
    [SerializeField] private GameObject[] enemys3Wave;
    private int[] countsEnemy;
    [SerializeField]private float timeSpawn = 10f;
    private float timeRemainingSpawn;
    [SerializeField]private int countEnemyMainRoom = 7;
    [SerializeField]private string enemytag = "Enemy";
    void Start()
    {
        timeRemainingSpawn = timeSpawn;
        countsEnemy = new int[spawns.Length];
        for (int i = 1; i < spawns.Length; i++) 
            countsEnemy[i] = spawns[i].childCount;
        if (countsEnemy.Length > 0) countsEnemy[0] = countEnemyMainRoom;
    }

    public void SpawnMobsRoom(int wave)
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            for (int j = 0; j < countsEnemy[i]; j++)
            {
                Transform[] points = spawns[i].GetComponentsInChildren<Transform>();
                int numspawn = Random.Range(0, points.Length);
                switch (wave)
                {
                    case 1:
                        GameObject enemy1 = Instantiate(enemys1Wave[Random.Range(0, enemys1Wave.Length)]);
                        enemy1.transform.position = points[numspawn].transform.position;
                        break;
                    case 2:
                        GameObject enemy2 = Instantiate(enemys2Wave[Random.Range(0, enemys2Wave.Length)]);
                        enemy2.transform.position = points[numspawn].transform.position;
                        break;
                    default:
                        GameObject enemy3 = Instantiate(enemys3Wave[Random.Range(0, enemys3Wave.Length)]);
                        enemy3.transform.position = points[numspawn].transform.position;
                        break;
                }
            }
            
        }
    }

}
