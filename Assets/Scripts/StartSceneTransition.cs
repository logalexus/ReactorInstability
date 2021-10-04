using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartSceneTransition : MonoBehaviour
{
    [SerializeField] private Image _sprite;
<<<<<<< HEAD
=======
    [SerializeField] private IteractPanel _startPanel;
>>>>>>> remotes/origin/master

    void Start()
    {
        _startPanel.Open(gameObject);
        _sprite.DOFade(0, 1);
    }
    
}
