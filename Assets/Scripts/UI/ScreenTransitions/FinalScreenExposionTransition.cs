using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FinalScreenExposionTransition : IteractPanelTransition
{

    
    private void Start()
    {
        _durationOpen = 5;
        _overshot = 0;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.interactable = false;
        _topGroup.localPosition = new Vector3(_topGroup.localPosition.x, _topGroup.localPosition.y + _topGroup.rect.height);
    }

    public override Sequence CloseAnim()
    {
        _canvasGroup.interactable = false;
        Sequence s = DOTween.Sequence();
        s.Join(_topGroup.DOLocalMoveY(_topGroup.localPosition.y + _topGroup.rect.height, _durationClose).SetEase(Ease.InBack, _overshot));
        return s;
    }
    public override Sequence OpenAnim()
    {
        Sequence s = DOTween.Sequence();
        s.Join(_topGroup.DOLocalMoveY(_topGroup.localPosition.y - _topGroup.rect.height, _durationOpen).SetEase(Ease.OutBack, _overshot));
        s.OnComplete(() =>
        {
            _canvasGroup.interactable = true; ;
        });
        return s;
    }
}
