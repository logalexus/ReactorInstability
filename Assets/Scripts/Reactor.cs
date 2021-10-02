using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Reactor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI temperatureReactorUI;
    
    [SerializeField] private Slider _absorption;

    private float _delta = 0;
    
    void Start()
    {
        StartCoroutine(UpdateReactor());
    }
    

    IEnumerator UpdateReactor()
    {
        while (true)
        {
            _delta = Random.Range(-2, 2);
            _absorption.value = _absorption.value + _delta;
            yield return new WaitForSeconds(1f);
        }
        
    }

}
