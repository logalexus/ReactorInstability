using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Reactor : MonoBehaviour
{
    public static Reactor Instance;
    [SerializeField] private TextMeshProUGUI _temperatureReactorUI;
    [SerializeField] private TextMeshProUGUI _powerReactorUI;
    [SerializeField] private EndTimer _endTimer;




    [SerializeField] private Slider _absorption;

    private float _delta = 10;
    private float _temperatureReactor = 750;
    private float _powerReactor = 12000;
    private float _powerReactorKoeff = 120;


    private bool _isTimerStart = false;



    public float Delta
    {
        get => _delta;
        set
        {
            _delta = value;
        }
            
    }
    public float TemperatureReactor
    {
        get => _temperatureReactor;
        set
        {
            _temperatureReactor = value;
            _temperatureReactorUI.text = $"{(int)value}K";

            if (value > 1200 || (PowerReactor < 1000 && value < 200) || (PowerReactor < 1000 && value > 1200) || PowerReactor < 1000 || value < 200)
            {
                _temperatureReactorUI.color = Color.red;
                if (!_isTimerStart)
                {
                    _endTimer.Open(gameObject);
                    _isTimerStart = true;
                }
            }
            else
            {
                if (_isTimerStart)
                {
                    _endTimer.Close();
                    _isTimerStart = false;
                }
                _temperatureReactorUI.color = Color.white;
            }
        }
    }
    public float PowerReactor
    {
        get => _powerReactor;
        set
        {

            _powerReactor = value;
            _powerReactorUI.text = $"{(int)value}\nMwt";
            if (value < 1000)
            {
                _powerReactorUI.color = Color.red;
                
            }
            else
            {
                _powerReactorUI.color = Color.white;
                
            }
        }
    }
    public float PowerReactorKoef
    {
        get => _powerReactorKoeff;
        set
        {
            _powerReactorKoeff = value;
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameController.Instance.GameOver += () => StopAllCoroutines();
        GameController.Instance.StartGame += () => StartCoroutine(UpdateReactor());
    }
   
    IEnumerator UpdateReactor()
    {
        while (true)
        {
            float offset = Random.Range(-_delta, _delta);

            if (_absorption.value > 80 || _absorption.value < 20)
                offset /= 5;
            _absorption.DOValue(Mathf.Abs(_absorption.value + offset), 0.2f);

            TemperatureReactor = TemperatureReactor + (_absorption.value * 15 - _temperatureReactor) / 2;
            PowerReactor = PowerReactor + (_absorption.value * _powerReactorKoeff - _powerReactor) / 2;


            yield return new WaitForSeconds(1f);
        }
    }



}
