using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brakes : MonoBehaviour
{
    [SerializeField] float BrakeAnimationDuration=0.25f;
    [SerializeField] Transform CarBody;
    [SerializeField] float HitJiggleValue = 3.5f;
    bool IsPlayingBrakesAnimation = false;
    void Start()
    {
        
    }

  
    public void PlayBrakeAnimation()
    {
        if (IsPlayingBrakesAnimation) return;
        IsPlayingBrakesAnimation=true;
        Vector3 carbodyangles = CarBody.localEulerAngles;
        //PlayAudioFX(BrakesSound, false);
        DOTween.To(() => carbodyangles, value => carbodyangles = value, carbodyangles + new Vector3(HitJiggleValue, 0, 0),
            BrakeAnimationDuration).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnUpdate
            (() => { CarBody.localEulerAngles = carbodyangles; }).OnComplete(() => 
            {
                IsPlayingBrakesAnimation=false;
            });
    }
}
