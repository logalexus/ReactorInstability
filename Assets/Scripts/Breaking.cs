using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Breaking : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    public void StartBreaking()
    {

    }
    
    public void FixBreaking()
    {
        StartCoroutine(ProccesFixing());
    }

    IEnumerator ProccesFixing()
    {
        yield return new WaitForSeconds(10f);
        
    }
}
