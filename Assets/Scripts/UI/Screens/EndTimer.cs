using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class EndTimer : IteractPanel
{
    [SerializeField] private EndTimerTransition _endTimerTransition;
    [SerializeField] private TextMeshProUGUI _timerUI;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private SpriteRenderer _alert;
    
    private int _timer = 10;
    private Sequence s;
    private bool _isCall = false;
    private float _alertTime = 5f;
    private float _alertDirection = 1f;

    public override void Open(GameObject caller)
    {
        base.Open(caller);
        _endTimerTransition.OpenAnim();
        StartCoroutine(Timer());
    }

    public override void Close()
    {
        StopAllCoroutines();
        _timer = 10;
        _timerUI.text = $"{_timer}";
        _isCall = false;
        s.Kill();
        _endTimerTransition.CloseAnim().OnComplete(() =>
        {
            base.Close();
        });
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _timerUI.text = $"{_timer}";
            if (_timer > 0)
            {
                _timer--;
                if (_timer < _alertTime && !_isCall)
                {
                    s = DOTween.Sequence();
                    s.Append(_alert.DOFade(1, _alertDirection))
                        .Append(_alert.DOFade(0, _alertDirection)).SetLoops(-1, LoopType.Yoyo);
                    _isCall = true;
                }
            }
            else if (_timer == 0)
            {
                _explosion.StartAnim();
                GameController.Instance.OnGameOver();
                break;
            }
        }
    }

}
