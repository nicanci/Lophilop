using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public Level[] levels;
    public int currentLevel;
    private Player_Movement _Player;
    private Vector3 playerDefauldPosition;

    private void Start()
    {
        _Player = GameObject.FindWithTag("Player").GetComponent<Player_Movement>();
        playerDefauldPosition = _Player.transform.position;
    }


    public void StartLevel()
    {
        levels[currentLevel].gameObject.SetActive(true);
        _Player.transform.position = playerDefauldPosition;

    }

    public void StartNextLevel()
    {
        levels[currentLevel].gameObject.SetActive(false);
        currentLevel++;
        StartLevel();
        
    }

    public void EndLevel()
    {
        
        
    }

    private void Update()
    {
        
    }






}
