using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Helper : MonoBehaviour
{
    [SerializeField] public List<GameObject> HelpingPanels;
    //[SerializeField] GameObject HelpingHand;
    [SerializeField] TextMeshProUGUI HelpText1;
    [SerializeField] TextMeshProUGUI HelpText2;
    [SerializeField] public List<Transform> CarOrder;//for tutorial
    [SerializeField] bool IsTEtsting = true;
    bool IsTutorial = false;
    private void OnEnable()
    {
        tutorialHelper.OncarClicked += CarClicked;
    }
    private void OnDisable()
    {
        tutorialHelper.OncarClicked -= CarClicked;
    }

    private void CarClicked(Transform car)
    {
        if (!IsTutorial) return;
        if (car != CarOrder[0])
        {
            Debug.Log("mismatch");
            return;
        }
        ActivateHelperHand(false);
        CarOrder.Remove(car);
        HelpingPanels[0].SetActive(false);
        HelpingPanels.Remove(HelpingPanels[0]);
        if (CarOrder.Count > 0)
        {

            ActivateHelperHand(true);
        }
        else
        {
            HelpText1.gameObject.SetActive(false);
            HelpText2.gameObject.SetActive(true);
            PlayerPrefs.SetString("Tutorial", "Done");
        }
        
    }

    private void Start()
    {
        if (IsTEtsting)
        {
            PlayerPrefs.DeleteAll();
        }
        if (!PlayerPrefs.HasKey("Tutorial"))
        { 
            IsTutorial =true;
            ActivateHelperHand(true);
            HelpText1.gameObject.SetActive(true);
        }
        
    }
    void ActivateHelperHand(bool status)
    {
        if (!IsTutorial) return;
        HelpingPanels[0].SetActive(status);
    }
    

}
