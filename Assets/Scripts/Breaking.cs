using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class Breaking : MonoBehaviour
{
    [SerializeField] private Image _fixingProgressBar, _progressBarBorder;
    [SerializeField] private SpriteRenderer _warningSign;
    [SerializeField] private Camera _camera;

    private Sequence _warningSignSeq;
    private float _scaleDelta = 0.2f;
    private bool _isCall = false;

    public bool IsCall => _isCall;
    public UnityAction callbackAfterFix;

    public void StartBreaking()
    {
        if (!_isCall)
        {
            _warningSignSeq = DOTween.Sequence();
            _warningSignSeq.Join(_warningSign.DOFade(1, 0.4f));
            _warningSignSeq.Join(_warningSign.transform.DOScale(new Vector2(transform.localScale.x + _scaleDelta, transform.localScale.y + _scaleDelta), 0.4f)).SetLoops(-1, LoopType.Yoyo);
            _isCall = true;
            Reactor.Instance.Delta += 10;
            AudioController.Instance.PlaySFXLoop(AudioController.Instance.Sounds.WarnignSignal);

        }
    }

    public void FixBreaking(TweenCallback callback)
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(Player.Instance.transform.position + Vector3.up * 2);
        _progressBarBorder.transform.position = screenPos;
        _fixingProgressBar.transform.position = screenPos;
        StartCoroutine(ProccesFixing(callback));
    }

    IEnumerator ProccesFixing(TweenCallback callback)
    {
        _fixingProgressBar.DOFillAmount(1, 4).OnComplete(callback);
        yield return new WaitForSeconds(4f);
        Player.Instance.GetComponent<PlayerMove>().enabled = true;
        Player.Instance.GetComponent<Iteracter>().enabled = true;
        _fixingProgressBar.fillAmount = 0;
        _warningSignSeq.OnKill(() =>
        {
            _warningSignSeq.Restart();
        });
        _warningSignSeq.Kill();
        callbackAfterFix?.Invoke();
        callbackAfterFix = null;
        _isCall = false;
        Reactor.Instance.Delta -= 10;
    }
}
