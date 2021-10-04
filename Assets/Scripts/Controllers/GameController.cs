using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public event UnityAction GameOver;
    public event UnityAction StartGame;

    private AudioController _audioController;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 70;
    }

    private void Start()
    {
        _audioController = AudioController.Instance;
    }
    

    public void OnGameOver()
    {
        GameOver?.Invoke();
    }

    public void OnStartGame()
    {
        StartGame?.Invoke();
    }
    
}
