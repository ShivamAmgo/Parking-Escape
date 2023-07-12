using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
public class PlayerEvent : MonoBehaviour
{
    public delegate void DeliverPlayerInfo(Transform player);
    public static event DeliverPlayerInfo OnPlayerDeliverInfo;
    bool Exiting = false;
    private void OnEnable()
    {
        ExitDoor.OnAmbulanceExited += AmbulanceExited;
    }

   

    private void OnDisable()
    {
        ExitDoor.OnAmbulanceExited -= AmbulanceExited;
    }
    private void Start()
    {
        OnPlayerDeliverInfo?.Invoke(transform);
    }
    private void AmbulanceExited(Transform ambulance)
    {
        if (Exiting) return;
        
        if (ambulance == transform)
        {
            Exiting = true;
            transform.DOMove(transform.position+transform.forward*20, 1).SetEase(Ease.Linear);
            
        }
    }
}
