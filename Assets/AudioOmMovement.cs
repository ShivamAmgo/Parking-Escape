using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioOmMovement : MonoBehaviour
{
    [SerializeField] AudioClip CarRunSfx;
    [SerializeField] AudioClip HitSfx;
    AudioSource audioSource;
    public Rigidbody rigidbody;
    

    bool IsPlaying=false;
    private void Start()
    {
        // Get the Rigidbody component if not assigned
        audioSource = GetComponent<AudioSource>();
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude > 2f && !IsPlaying)
        {
            IsPlaying = true;
            PlayAudioFX(CarRunSfx, true);
            Debug.Log("gkhdb");
        }
        
        else if(IsPlaying && rigidbody.velocity.magnitude <= 0.35f && audioSource.clip==CarRunSfx)
        {

            StopAudioFx();
            
        }
        
    }
    
    public void PlayAudioFX(AudioClip clip, bool Isloop)
    { 
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.loop = Isloop;
        audioSource.Play();
    }
    void StopAudioFx()
    { 
        IsPlaying=false;
        audioSource.loop=false;
        audioSource.Stop();

    }
    public void PlayHitSFX()
    {
        if (IsPlaying) return;
        audioSource.volume /= 10;
        IsPlaying = true;
        PlayAudioFX(HitSfx, false);
        DOVirtual.DelayedCall(HitSfx.length+0.1f, () =>
        {
            IsPlaying = false;
            audioSource.volume *= 10;
        });
    }
}
