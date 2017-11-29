 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab; //Prefab of the enemy to spawn

	public Transform spawnPoint; //Point to spawn enemies from

	public float timeBetweenWaves = 5f; //Time to countdown between waves
	private float countdown = 2f; // Time to spawn first wave

	public Text waveCountdownText; //UI to display countdown text

	private int waveIndex = 0; //Index starting number

	void Update (){
		if (countdown <= 0f) {
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves; //Resetting timer
		}
		countdown -= Time.deltaTime; //counting down by 1
		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format ("{0:00.00}", countdown); //Formatting UI text
	}
    // Spaw wave of enemies and increase the amount each round
	IEnumerator SpawnWave(){ 
		waveIndex++;
		PlayerStats.Rounds++;

		for (int i = 0; i < waveIndex; i++) {
			spawnEnemy ();
            yield return new WaitForSeconds (0.5f); //IEnumerator allows us to pause 
		}
	}
    //Function to create enemies at postion of spawnpoint
	void spawnEnemy() {
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}


}
