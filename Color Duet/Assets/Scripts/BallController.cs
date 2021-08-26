using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    public float rangePoint = 3.5f;
    public float waveAmplitude = 1.3f;
    public float timeDuration = 0.5f;

    [SerializeField] private Ease moveEase = Ease.Linear;

    public bool isTapRouteDown;
    public bool isTapRouteUp;
    public bool isTaped = false;

    private Tween initialMovement;
    private Tween loopMovement;
    private Tween comeBackTween;

    private Environment environment;

    #region monoBehaviours

    void Update()
    {
        //PosCheck();
        GetMouseButtonFunc();
    }

    #endregion

    private void GetMouseButtonFunc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            comeBackTween.Kill(); //comeBackTween?.Kill();
            initialMovement = transform.DOMoveY(-waveAmplitude, timeDuration).SetEase(moveEase).OnComplete(() => {
              loopMovement = transform.DOMoveY(waveAmplitude, timeDuration).SetEase(moveEase).SetLoops(-1, LoopType.Yoyo);
                
            });
        }
        if (Input.GetMouseButtonUp(0))
        {
            initialMovement.Kill();
            loopMovement.Kill();
            comeBackTween = transform.DOMoveY(rangePoint, timeDuration).SetEase(moveEase);
        }
    }
}
