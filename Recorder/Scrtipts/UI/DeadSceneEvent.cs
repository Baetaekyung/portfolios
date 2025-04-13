using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class DeadSceneEvent : MonoBehaviour
{
    [SerializeField] private CanvasGroup _deadSceneCanvas;
    [SerializeField] private float _fadeTime;
    [SerializeField] private GameObject _postProcessing;

    public void FadeCanvas()
    {
        _deadSceneCanvas.DOFade(1, _fadeTime);
        _postProcessing.SetActive(false);
    }
}
