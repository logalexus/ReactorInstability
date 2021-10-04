using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScreenNonPower : IteractPanel
{
    [SerializeField] private FinalScreenNonPowerTransition _finalScreenNonPowerTransition;
    [SerializeField] private List<IteractPanel> _panels;
    [SerializeField] private Button _restart;

    private void Start()
    {
        _restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        });
    }

    public override void Open(GameObject caller)
    {
        base.Open(caller);
        foreach (var item in _panels)
            item.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        _finalScreenNonPowerTransition.OpenAnim();

    }

    public override void Close()
    {
        StopAllCoroutines();
        _finalScreenNonPowerTransition.CloseAnim().OnComplete(() =>
        {
            base.Close();
        });
    }
}
