using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Pause,
    End
}

public class Game_Manager : MonoBehaviour
{
    private Level_Manager levelManager;
    public GameState currentGameState;
    private UI_Manager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<Level_Manager>();
        uiManager = GameObject.FindWithTag("MainUI").GetComponent<UI_Manager>();
        currentGameState = GameState.Pause;
    }

    public void StartGame()
    {
        currentGameState = GameState.Start;
        
        levelManager.StartLevel();
    }


    public void StartNextGame()
    {
        currentGameState = GameState.Start;
        levelManager.StartNextLevel();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNextGame();
        }

    }

    public void EndGame()
    {
        levelManager.EndLevel();
        currentGameState = GameState.End;
        Debug.Log("level tamamlandı.");
        
    }

   
}
