using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RingController : MonoBehaviour
{
    Tween downTween;
    Tween upTween;
    [SerializeField] private Ease moveEase;

    public float moveDuration;
    public float downRange;
    public float upRange;

    public bool isDown;
    public bool isUp;

    void Start()
    {
        if (isDown && !isUp)
        {
            MoveDown();
        }

        if (!isDown && isUp)
        {
            MoveUp();
        }
    }


    void Update()
    {

    }


    public void MoveDown()
    {
        downTween = transform.DOMoveY(-downRange, moveDuration).SetEase(moveEase).OnComplete(() => MoveUp());
    }


    public void MoveUp()
    {
        upTween = transform.DOMoveY(upRange, moveDuration).SetEase(moveEase).OnComplete(() => MoveDown());
    }
}
