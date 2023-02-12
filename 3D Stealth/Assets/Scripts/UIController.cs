using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController Instance;

    public GameObject VictoryScreen;
    public Button RetryButton, QuitButton;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        RetryButton.onClick.AddListener(OnRetry);
        QuitButton.onClick.AddListener(OnQuit);
        VictoryScreen.SetActive(false);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    private void OnRetry()
    {
        SceneManager.LoadScene("StealthLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVictory()
    {
        VictoryScreen.SetActive(true);
    }
}
