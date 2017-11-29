using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target; //Setting target to move towards
    private int waypointIndex = 0; //Starting point for wavepointIndex

	private Enemy enemy; //Enemy variable to refer to


	void Start () {
		enemy = GetComponent<Enemy> (); //Access the enemy

		target = Waypoints.points [0]; //First waypoint to target 
	}

	void Update() {
        //Vector direction we want enemy to move towards = target position - current position
		Vector3 dir = target.position - transform.position;
        //Speed for the enemies transform to move at
		transform.Translate (dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        //If we reach the current waypoint we are targeting get the next one
		if (Vector3.Distance (transform.position, target.position) <= 0.4f) {
			GetNextWaypoint ();
		}
		enemy.speed = enemy.startSpeed; //resetting the speed to default
	}
    //Function to assign next waypoint for the enemy to target
	void GetNextWaypoint(){
        //If enemy reaches the last waypoint call endPath()
		if (waypointIndex >= Waypoints.points.Length - 1) {
			EndPath ();
			return;

		}
        //Get the next waypoint in the index
		waypointIndex++;
		target = Waypoints.points [waypointIndex];
	}
    //Runs when enemy reaches end of waypoint path
	void EndPath() {
		PlayerStats.Lives--; //Subtract life from player
        Destroy (gameObject); //Destroy enemy
	}
}
