using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Iteracter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    private bool isIteractable;
    private PanelOpener panelOpener;
    private Breaking breaking;


    private void Update()
    {
        if (isIteractable && Input.GetKeyDown(KeyCode.E))
        {
            enabled = false;
            panelOpener.Open();
            Player.Instance.GetComponent<PlayerMove>().StopMove();
            Player.Instance.GetComponent<PlayerMove>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.transform.TryGetComponent(out ControlPanel hl))
        {
            panelOpener = collider.transform.GetComponent<PanelOpener>();
            isIteractable = true;
            _sprite.DOFade(1, 0.5f);
        }
        if (collider.transform.TryGetComponent(out breaking) && breaking.IsCall)
        {
            panelOpener = collider.transform.GetComponent<PanelOpener>();
            isIteractable = true;
            _sprite.DOFade(1, 0.5f);
            breaking.callbackAfterFix += () => 
            {
                _sprite.DOFade(0, 0.5f);
                isIteractable = false;
            };
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out HighlightToIteract hl))
        {
            _sprite.DOFade(0, 0.5f);
            isIteractable = false;
        }
    }
}
