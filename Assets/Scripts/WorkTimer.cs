using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerUI;
    [SerializeField] private FinalScreenGoodWork _finalScreenGoodWork;

    private float _timer = 8;

    private void Start()
    {
        GameController.Instance.StartGame += ()=> StartCoroutine(ProccessTime());
    }

    IEnumerator ProccessTime()
    {
        while (true)
        {
            if (_timer <= 12)
                _timerUI.text = $"{_timer} am";
            else
                _timerUI.text = $"{_timer - 12} pm";

            if (_timer - 12 == 4)
            {
                GameController.Instance.OnGameOver();
                _finalScreenGoodWork.Open(gameObject);
                StopAllCoroutines();
            }
            _timer++;
            yield return new WaitForSeconds(2);

        }
    }
}
