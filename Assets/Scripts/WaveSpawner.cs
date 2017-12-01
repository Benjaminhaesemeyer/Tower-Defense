 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;

	public Transform spawnPoint; //Point to spawn enemies from

	public float timeBetweenWaves = 5f; //Time to countdown between waves
	private float countdown = 2f; // Time to spawn first wave

	public Text waveCountdownText; //UI to display countdown text

	private int waveIndex = 0; //Index starting number

	void Update (){
        if (EnemiesAlive > 0)
        {
            return;
        }

		if (countdown <= 0f) {
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves; //Resetting timer
            return;
		}
		countdown -= Time.deltaTime; //counting down by 1
		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format ("{0:00.00}", countdown); //Formatting UI text
	}
    // Spaw wave of enemies and increase the amount each round
	IEnumerator SpawnWave(){ 
        
		PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

		for (int i = 0; i < wave.count; i++) {
			SpawnEnemy (wave.enemy);
            yield return new WaitForSeconds (1f / wave.rate); //IEnumerator allows us to pause 
		}
        waveIndex++;
	}
    //Function to create enemies at postion of spawnpoint
    void SpawnEnemy(GameObject enemy) {
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
	}


}
