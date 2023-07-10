using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brakes : MonoBehaviour
{
    [SerializeField] float BrakeAnimationDuration=0.25f;
    [SerializeField] Transform CarBody;
    [SerializeField] float HitJiggleValue = 3.5f;
    [SerializeField] GameObject HitFX;
    [SerializeField] GameObject TapFx;
    AudioOmMovement AudioPlayer;
    bool IsPlayingBrakesAnimation = false;
    Rigidbody RB;
    
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        AudioPlayer = GetComponent<AudioOmMovement>();
    }

  
    public void PlayBrakeAnimation()
    {
        RB.velocity = Vector3.zero;
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
        if(AudioPlayer!=null)
        AudioPlayer.PlayHitSFX();
    }
    public void PlayHitfx(Vector3 pos)
    {
       
        HitFX.transform.position = pos+new Vector3(0,1.45f,0);
        PlayFX(HitFX);
    }
    public void PlayFX(GameObject FX)
    {
        //FX.transform.position = transform.position + new Vector3(0, 2, 0);
        if (FX == null) return;
        FX.SetActive(false);
        FX.SetActive(true);
    }
    private void OnMouseDown()
    {
        PlayFX(TapFx);
    }
}
