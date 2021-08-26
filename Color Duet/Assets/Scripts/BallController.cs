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
        



        /*if (Input.GetMouseButton(0))
        {
            isTaped = true;
            comeBackTweener.Kill();
            TapRouteDown();
            TapRouteUp();
        }
        else
        {
            isTaped = false;
            downTweener.Kill();
            turningTweener.Kill();
            ComeBack();
        }*/
    }

    /*
    public void TapRouteDown()
    {
        if (isTapRouteDown && isTaped)
        {
            turningTweener.Kill();
            comeBackTweener.Kill();

            downTweener = transform.DOMoveY(-waveAmplitude, timeDuration).SetEase(moveEaseDown);
            //.OnComplete(() => TapRouteDown());

            //Debug.Log("");
        }
    }

    public void TapRouteUp()
    {
        if (isTapRouteUp && isTaped)
        {
            downTweener.Kill();
            comeBackTweener.Kill();
            
            turningTweener = transform.DOMoveY(waveAmplitude, timeDuration).SetEase(moveEase);
                //.OnComplete(() => TapRouteUp());
        }
    }

    public void PosCheck()
    {
        if(transform.position.y <= -1.29f)
        {
            isTapRouteUp = true;
            isTapRouteDown = false;
        }
        if(transform.position.y >= 1.29f)
        {
            isTapRouteDown = true;
            isTapRouteUp = false;
        }
    }

    public void ComeBack()
    {
        //downTweener.Kill();
        //turningTweener.Kill();
        comeBackTweener = transform.DOMoveY(rangePoint, timeDuration).SetEase(moveEase);
    }*/
}
