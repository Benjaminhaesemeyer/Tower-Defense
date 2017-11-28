using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

	public Text livesText;

	// Update is called once per frame
	void Update () {
		if (PlayerStats.Lives >= 2) {
			livesText.text = PlayerStats.Lives + " LIVES";
		} else {
			livesText.text = PlayerStats.Lives + " LIFE";
		}
		
	}
}
