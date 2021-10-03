using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingCaller : MonoBehaviour
{
    [SerializeField] private List<Breaking> _breakings;

    private void Start()
    {
        StartCoroutine(BreakingCalls());
    }

    IEnumerator BreakingCalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            _breakings[Random.Range(0, _breakings.Count)].StartBreaking();
        }
    }
 }
