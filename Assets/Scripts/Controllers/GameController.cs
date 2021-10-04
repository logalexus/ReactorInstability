using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public event UnityAction GameOver;
    public event UnityAction GameStart;
    public event UnityAction StartDialog;
    public event UnityAction EndDialog;

    private AudioController _audioController;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 70;
    }

    private void Start()
    {
        _audioController = AudioController.Instance;
    }

    private void OnGameEnd()
    {
        GameOver?.Invoke();
        _audioController.PlayMusic(_audioController.Sounds.MainTheme);
    }

    public void OnGameStart()
    {
        GameStart?.Invoke();
        _audioController.StopMusic();

    }

    public void OnStartDialog()
    {
        StartDialog?.Invoke();
    }

    public void OnEndDialog()
    {
        EndDialog?.Invoke();
    }
}
