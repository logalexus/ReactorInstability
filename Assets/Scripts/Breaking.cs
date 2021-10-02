using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class Breaking : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private Camera _camera;

    
    public void StartBreaking()
    {

    }
    
    public void FixBreaking(TweenCallback callback)
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(Player.Instance.transform.position + Vector3.up * 2);
        _sprite.transform.position = screenPos;
        StartCoroutine(ProccesFixing(callback));
    }

    IEnumerator ProccesFixing(TweenCallback callback)
    {
        _sprite.DOFillAmount(1, 4).OnComplete(callback);
        yield return new WaitForSeconds(4f);
        Player.Instance.GetComponent<PlayerMove>().enabled = true;
        Player.Instance.GetComponent<Iteracter>().enabled = true;
        _sprite.fillAmount = 0;
    }
}
