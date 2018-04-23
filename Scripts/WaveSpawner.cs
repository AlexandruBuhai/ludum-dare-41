using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour {

    [Header ("Enemies and spawnPoint")]
    public Transform enemyPrefab;
    public Transform enemyPrefab2;
	//aja
	public Transform enemyBossPrefab;
	//aja
    public Transform spawnPoint;
    public Transform spawnPoint2;

    [Header ("Attributes")]
    public float timeBetweenWaves = 10f; // 5f
    public float timeBetweenWaves2 = 15f; // Till the second wave spawns 

    public float countdown = 3f; // 2f
    public float countdown2 = 3f; // Countdown of the next wave 

    [Header("Text objects")]
    public Text waveCountdownText;
    public Text moneyCount;

    private int waveIndex = 0; 

    public GameObject enemyBatch;


    void Awake()
    {
        enemyBatch.SetActive(false);
    }
  

	//aja
	//public Text waveCountText;
	public int waveCount;
	//aja

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            
            countdown = timeBetweenWaves;
        }

        if(countdown2 <= 0f)
        {
            StartCoroutine(SpawnWave2());
            countdown2 = timeBetweenWaves2;
        }

        countdown -= Time.deltaTime; 
        countdown2 -= Time.deltaTime; 
        waveCountdownText.text = Math.Round(countdown).ToString();
        //waveCountdownText.text = Math.Round(countdown2).ToString();
        moneyCount.text = PlayerStats.Money.ToString();
    }

    IEnumerator SpawnWave()
	{
		//waveIndex++;
		//UnityEngine.Debug.Log("Wave incoming");
		if (waveIndex <= 4) {
			for (int i = 0; i < waveIndex; ++i) {	
				//aja
				//waveCountText.text = waveIndex.ToString();
				waveCount = waveIndex;
				//aja

				SpawnEnemy ();
				yield return new WaitForSeconds (0.94f);
			}
		} else {
			if (waveIndex > 6 && waveIndex < 8)
				SpawnEnemyBoss ();
			//yield return new WaitForSeconds(0.7f);
		}
	}
 
    IEnumerator SpawnWave2()
    {
        
        waveIndex++;
        //waveIndex += (int) Math.Round((double) (Random.Range(0, 1)));
        //UnityEngine.Debug.Log("Wave incoming");
        if(waveIndex <= 4)
        {
            for (int i = 0; i < waveIndex; ++i)
            {	
                SpawnEnemy2();

                yield return new WaitForSeconds(0.94f);
            }
        }
        if(waveIndex > 5)
        {
            enemyBatch.SetActive(true);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
     void SpawnEnemy2()
    {
        Instantiate(enemyPrefab2, spawnPoint2.position, spawnPoint2.rotation);
    }

	//aja
	void SpawnEnemyBoss()
	{
		Instantiate(enemyBossPrefab, spawnPoint.position, spawnPoint.rotation);
	}
	//aja
}
