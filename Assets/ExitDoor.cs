using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    bool RoundWon = false;
    public delegate void DoorExit(bool WinStatus);
    public static event DoorExit OnDoorExit;
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
