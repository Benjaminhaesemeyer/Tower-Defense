﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;

    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) 
        {
            Toggle();
        }
	}

    public void Toggle () 
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry () 
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);

    }
    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
