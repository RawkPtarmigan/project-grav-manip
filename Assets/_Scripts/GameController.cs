﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    public GameObject gravityManager;
    public GameObject player;
    public GameObject exit;

    void Start()
    {
        GameData.data.currentLevel = Application.loadedLevel;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gravityManager.SetActive(false);
        Input.gyro.enabled = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gravityManager.SetActive(true);
        Input.gyro.enabled = true;
        if(player) player.rigidbody2D.velocity = Vector2.zero;
    }

    public void LoadGame(int level)
    {
        if(GameData.data.pause) GameData.data.pause = false;
        if(GameData.data.complete) GameData.data.complete = false;

        if(level == -1) 
            Application.Quit();
        else if(level == -2)
            Application.LoadLevel(GameData.data.currentLevel);
        else 
            Application.LoadLevel(level);            
    }
}
