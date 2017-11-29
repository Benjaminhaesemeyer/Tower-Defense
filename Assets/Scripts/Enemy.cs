using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f; //Speed of enemy at begining of the game

	[HideInInspector]
	public float speed; //Speed variable we can assign a value later

	public float health = 100; //Default health for enemies
	public int worth = 50; //Money player recieves for destroying enemy
	public GameObject deathEffect; //Particle effect when enemy is destroyed 


	void Start(){
		speed = startSpeed; //Setting speed value to 10f at the start
	}
    //Function to damage enemies health
	public void TakeDamage(float amount){
		health -= amount;

		if (health <= 0) {
			Die ();
		}
	}
    //Function to slow down enemies speed 
	public void Slow (float pct){
		speed = startSpeed * (1f- pct); //Slowing down enemies by percent
	}
    //Function to destroy enemies 
	void Die() {
		PlayerStats.Money += worth; //Add money to the players bank 

        //Run the death particle effect 
		GameObject effect = (GameObject)Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 5f);

        //Remove the enemy object from the hierarchy
		Destroy (gameObject);
	}
}
