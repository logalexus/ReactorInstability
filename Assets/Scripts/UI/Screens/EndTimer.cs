using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class EndTimer : IteractPanel
{
    [SerializeField] private EndTimerTransition _endTimerTransition;
    [SerializeField] private TextMeshProUGUI _timerUI;

    private int _timer = 10;

    private void Start()
    {


    }

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
        while (_timer > 0)
        {
            yield return new WaitForSeconds(1f);
            _timerUI.text = $"{_timer}";
            if (_timer > 0)
                _timer--;
            else
                _timer = 0;
        }
    }

}
