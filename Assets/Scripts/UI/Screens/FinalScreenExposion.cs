using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScreenExposion : IteractPanel
{
    [SerializeField] private FinalScreenExposionTransition _finalScreenTransition;
    [SerializeField] private List<IteractPanel> _panels;
    [SerializeField] private Button _restart;

    private void Start()
    {
        _restart.onClick.AddListener(()=>
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        });
    }

    public override void Open(GameObject caller)
    {
        base.Open(caller);
        foreach (var item in _panels)
            item.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        _finalScreenTransition.OpenAnim();
        
    }

    public override void Close()
    {
        StopAllCoroutines();
        _finalScreenTransition.CloseAnim().OnComplete(() =>
        {
            base.Close();
        });
    }
}
