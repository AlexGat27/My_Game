using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Waves : MonoBehaviour
{
    [SerializeField]private Image[] countwaves;
    [SerializeField]private Text textWave;
    [SerializeField]private Spawn spawn;
    public bool isToSpawn;
    public int currentwave;
    [SerializeField] private float timeToWave = 10f;
    [SerializeField] private float timeToWaveRemaining;
    private string enemytag = "Enemy";
    void Start()
    {
        isToSpawn = false;
        currentwave = 0;
        timeToWaveRemaining = 0f;

        for(int i = 0; i < countwaves.Length; i++)
            countwaves[i].color = Color.white;

        Color color = textWave.color;
        color.a = 0;
        textWave.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToWaveRemaining >= timeToWave)
        {
            isToSpawn = true;
            currentwave++;
            timeToWaveRemaining = 0;
            spawn.SpawnMobsRoom(currentwave);
            SwitchUIWave(currentwave);
            StartCoroutine(Zatuxanie());
        }
        else if (!isToSpawn) timeToWaveRemaining+=Time.deltaTime;
        CheckEnemy();
    }

    private void CheckEnemy()
    {
        if(GameObject.FindGameObjectsWithTag(enemytag).Length == 0) isToSpawn = false;
    }
    private void SwitchUIWave(int numwave)
    {
        for (int i = 0; i < numwave; i++)
        {
            countwaves[i].color = Color.blue;
        }
        textWave.text = "Wave " + numwave.ToString();
    }

    IEnumerator Zatuxanie()
    {
        Color col = textWave.color;
        col.a = 1f;
        textWave.color = col;
        for (float f = 1f; f >= -0.01f; f-=0.01f)
        {
            Color color = textWave.color;
            color.a = f;
            textWave.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
