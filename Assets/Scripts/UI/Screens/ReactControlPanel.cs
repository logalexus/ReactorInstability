using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ReactControlPanel : IteractPanel
{
    [SerializeField] private ReactControlPanelTransition mainMenuTransition;
    [SerializeField] private Button _close;
    
    private void Start()
    {
        _close.onClick.AddListener(()=>
        {
            Close();
        });
    }

    public override void Open()
    {
        base.Open();
        mainMenuTransition.OpenAnim();
    }

    public override void Close()
    {
        mainMenuTransition.CloseAnim().OnComplete(()=> 
        {
            Player.Instance.GetComponent<Iteracter>().enabled = true;
            Player.Instance.GetComponent<PlayerMove>().enabled = true;
            base.Close();
        });
    }

    
}
