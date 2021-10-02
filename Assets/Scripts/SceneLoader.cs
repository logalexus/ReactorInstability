using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{
    public Button _start;

    [SerializeField] private Image _sprite;


    private void Start()
    {
        _start.onClick.AddListener(()=>
        {
            _sprite.DOFade(1, 0.5f).OnComplete(() => { SceneManager.LoadScene(1); });;
        });
    }

}
