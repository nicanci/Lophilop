using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private Game_Manager gameManager;
    public Button btnStart, btnNextLevel;

    public GameObject menuUI, ingameUI, endUI;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<Game_Manager>();
        SetBindings();
    }

    private void SetBindings()
    {
        btnStart.onClick.AddListener(() =>
        {
            gameManager.StartGame();
            menuUI.SetActive(false);
            
        }

        );

        btnNextLevel.onClick.AddListener(() =>
        {
            endUI.SetActive(false);
            gameManager.StartNextGame();
            ingameUI.SetActive(false);
        }
        );
    }


    public void EndLevel()
    {
        ingameUI.SetActive(false);
        endUI.SetActive(true);
    }
}
