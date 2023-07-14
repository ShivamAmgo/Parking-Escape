using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class arrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float SpeedInDuration = 0.5f;
    [SerializeField] float JiggleValue = 0.5f;
    [SerializeField] bool IsUi = false;
    RectTransform Uitransform;
    void Start()
    {
        BackAndForth();
        if (!IsUi) return;
        Uitransform = GetComponent<RectTransform>();

    }
    void BackAndForth()
    {
        if (!IsUi)
            transform.DOLocalMoveX(transform.localPosition.x + JiggleValue, SpeedInDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        else
        {
            transform.DOLocalMoveZ(transform.localPosition.z + JiggleValue, SpeedInDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }

    }

    
}
