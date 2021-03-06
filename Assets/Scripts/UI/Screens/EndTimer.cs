using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class EndTimer : IteractPanel
{
    [SerializeField] private EndTimerTransition _endTimerTransition;
    [SerializeField] private TextMeshProUGUI _timerUI;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private SpriteRenderer _alert;
    [SerializeField] private FinalScreenNonPower _finalScreenNonPower;
    [SerializeField] private Slider _slider;



    private int _timer = 10;
    private Tween tw;

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
        _isCall = false;
        tw.Rewind();
        _endTimerTransition.CloseAnim().OnComplete(() =>
        {
            base.Close();
            _timerUI.text = $"{_timer}";
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
                    tw = _alert.DOFade(1, _alertDirection).SetLoops(-1, LoopType.Yoyo).SetAutoKill(false);
                    _isCall = true;
                }
            }
            else if (_timer == 0)
            {
                if (Reactor.Instance.TemperatureReactor > 900)
                {
                    _explosion.StartAnim();
                    GameController.Instance.OnGameOver();
                    break;
                }
                else if (Reactor.Instance.PowerReactor < 1100)
                {
                    _finalScreenNonPower.Open(gameObject);
                    GameController.Instance.OnGameOver();
                    break;
                }
                Close();

            }
        }
    }

}
