using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text roundsText; //Display how many rounds survived

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

	void OnEnable () {
		roundsText.text = PlayerStats.Rounds.ToString ();
	}
    //Rety button will run this and reload the scene 
	public void Retry () 
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}
    //Menu button redirects to a menu UI
	public void Menu () 
    {
        sceneFader.FadeTo(menuSceneName);
	}
}
 