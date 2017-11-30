using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver; //variable to toggle at end of game 

	public GameObject gameOverUI; //GameOver screen we want to display

	void Start() {
		GameIsOver = false;  
	}

	// Update is called once per frame
	void Update () {

        if (GameIsOver)
            return;
        
        //Once we run out of lives end the game
		if (PlayerStats.Lives <= 0) { 

            EndGame (); 
		}
	}

	void EndGame (){
		GameIsOver = true;
		gameOverUI.SetActive (true);
	}
}
