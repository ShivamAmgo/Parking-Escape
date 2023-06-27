using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class arrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float SpeedInDuration = 0.5f;
    [SerializeField] float JiggleValue = 0.5f;
    void Start()
    {
        BackAndForth();
    }
    void BackAndForth()
    {
        transform.DOLocalMoveX(transform.localPosition.x + JiggleValue, SpeedInDuration).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }

    
}
