using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;

public class FinalScreen : IteractPanel
{
    [SerializeField] private FinalScreenTransition _finalScreenTransition;
    [SerializeField] private List<IteractPanel> _panels;
    
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
