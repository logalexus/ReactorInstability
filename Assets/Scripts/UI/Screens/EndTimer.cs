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
                if (_timer < 5)
                    _alert.DOFade(1, 3f);
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
