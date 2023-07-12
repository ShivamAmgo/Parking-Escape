using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    bool RoundWon = false;
    public delegate void DoorExit(bool WinStatus);
    public delegate void AmbulanceEXited(Transform ambulance);
    public static event AmbulanceEXited OnAmbulanceExited;
    public static event DoorExit OnDoorExit;
    bool Used = false;
    int AmbulanceCount = 0;
    int AmbulanceExitCount = 0;
    private void OnEnable()
    {
        CarEscapeManager.OnROundEnd += OnRoundENded;
        PlayerEvent.OnPlayerDeliverInfo += RecievePlayer;
        ExitDoor.OnAmbulanceExited += AmbulanceExited;
    }

    

    private void OnDisable()
    {
        CarEscapeManager.OnROundEnd -= OnRoundENded;
        PlayerEvent.OnPlayerDeliverInfo -= RecievePlayer;
        ExitDoor.OnAmbulanceExited -= AmbulanceExited;
    }
    private void AmbulanceExited(Transform ambulance)
    {
        AmbulanceExitCount++;
        
        CheckWin();
    }
    private void RecievePlayer(Transform player)
    {
        AmbulanceCount++;
        Debug.Log(AmbulanceCount);
    }

    private void OnRoundENded()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Used) return;
        if(other.CompareTag("Player"))
        {
            Used = true;
            
            OnAmbulanceExited?.Invoke(other.transform);
            
        }
    }
    void Win()
    {
        Debug.Log("Win");
        OnDoorExit?.Invoke(true);
    }
    void CheckWin()
    {
        if (AmbulanceExitCount >= AmbulanceCount)
        {
            Win();
        }
    }
}
