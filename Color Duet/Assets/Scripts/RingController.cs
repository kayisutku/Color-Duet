using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RingController : MonoBehaviour
{
    Tween downTween;
    Tween upTween;
    [SerializeField] private Ease moveEase;

    public float upMoveDuration;
    public float downMoveDuration;
    public float downRange;
    public float upRange;

    public bool isDown;
    public bool isUp;

    public ParticleSystem ringParticle;

    private void Start()
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

    private void MoveDown()
    {
        downTween = transform.DOMoveY(-downRange, downMoveDuration).SetEase(moveEase).OnComplete(() => MoveUp());
    }


    private void MoveUp()
    {
        upTween = transform.DOMoveY(upRange, upMoveDuration).SetEase(moveEase).OnComplete(() => MoveDown());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Ring"))
        {
            downTween.Kill();
            upTween.Kill();
            isDown = false;
            isUp = false;
        }
    }
}
