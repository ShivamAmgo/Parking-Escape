using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    bool RoundWon = false;
    public delegate void DoorExit(bool WinStatus);
    public static event DoorExit OnDoorExit;
    private void OnEnable()
    {
        CarEscapeManager.OnROundEnd += OnRoundENded;
    }
    private void OnDisable()
    {
        CarEscapeManager.OnROundEnd -= OnRoundENded;
    }

    private void OnRoundENded()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (RoundWon) return;
        if(other.CompareTag("Player"))
        {
            RoundWon = true;
            Win();
        }
    }
    void Win()
    {
        Debug.Log("Win");
        OnDoorExit?.Invoke(true);
    }
}
