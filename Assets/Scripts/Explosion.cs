using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using DG.Tweening;

public class Explosion : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolume;
    [SerializeField] private FinalScreen _finalScreen;



    public void StartAnim()
    {
        Bloom bloom = _postProcessVolume.profile.GetSetting<Bloom>();
        var floatParameter = new FloatParameter();
        floatParameter.value = 0f;
        DOTween.To(() => floatParameter.value, x => floatParameter.value = x, 100f, 2)
            .OnUpdate(() => bloom.intensity.Override(floatParameter));
        _finalScreen.Open(gameObject);
    }
}
