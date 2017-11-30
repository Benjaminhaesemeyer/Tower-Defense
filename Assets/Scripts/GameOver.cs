using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text roundsText; //Display how many rounds survived

	void OnEnable () {
		roundsText.text = PlayerStats.Rounds.ToString ();
	}
    //Rety button will run this and reload the scene 
	public void Retry () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
    //Menu button redirects to a menu UI
	public void Menu () {
		Debug.Log ("Go to menu!");
	}
}
 