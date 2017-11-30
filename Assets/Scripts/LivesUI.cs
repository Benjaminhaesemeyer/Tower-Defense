using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text livesText; //Display how many lives are left 

	void Update () {
		if (PlayerStats.Lives >= 2) {
			livesText.text = PlayerStats.Lives + " LIVES";
		} else {
            //Change plural to singular once PlayerStats.Lives = 1
			livesText.text = PlayerStats.Lives + " LIFE";
		}
		
	}
}
