using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoldScript : MonoBehaviour
{
    [SerializeField] private Ease moveEase = Ease.Linear;
    [SerializeField] private float swayAmount = 2f;
    [SerializeField] private float timeDuration = 0.75f;
    [SerializeField] private float rotateAmount = 5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(transform.position.y + swayAmount, timeDuration).SetEase(moveEase).OnComplete(() =>
            {
                transform.DOMoveY(transform.position.y - 2 * swayAmount, 2 * timeDuration).SetEase(moveEase).SetLoops(-1, LoopType.Yoyo);
            }
        );

        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateAmount * Time.deltaTime,0);
    }
}
