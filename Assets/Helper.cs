using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] GameObject HelpingHand;
    [SerializeField] TextMeshProUGUI HelpText;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Tutorial"))
        { 
            
        }
    }
}
