using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class HelpingFinger : MonoBehaviour
{
    [SerializeField] float ScaleOnCLick = 0.2f;
    [SerializeField] float ScaleOnClickDuration = 0.25f;
    [SerializeField] float MoveDuration = 1f;
   
    Vector3 StartingScale;
    
    private void Start()
    {
        StartingScale=transform.localScale;
        //Wobble();
        move();
    }
    void Wobble()
    {
        float scale = transform.localScale.x;
        DOTween.To(() => scale, value => scale = value, scale + ScaleOnCLick, ScaleOnClickDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).OnUpdate
        (() =>
        {
            transform.localScale = scale * StartingScale;
        }).OnComplete(() =>
        {
            transform.localScale = StartingScale;


        });
    }
    void move()
    {
        transform.DOLocalMoveZ(transform.localPosition.z+2,MoveDuration).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);
    }
}
