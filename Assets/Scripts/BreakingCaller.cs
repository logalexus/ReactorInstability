using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BreakingCaller : MonoBehaviour
{
    [SerializeField] private List<Breaking> _breakings;

    private void Start()
    {
        GameController.Instance.GameOver += () => StopAllCoroutines();
        GameController.Instance.StartGame += () => StartCoroutine(BreakingCalls());
    }

    private void Update()
    {
        if (_breakings.All(x => x.IsCall == false))
            AudioController.Instance.StopSFXLoop();
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
