using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarEscapeManager : MonoBehaviour
{
    [SerializeField] GameObject[] Win_failPanels;
    [SerializeField] int StartSceneIndex = 1;
    [SerializeField] GameObject TapTOstartTExt;
    [SerializeField] TextMeshProUGUI Lvltxt;
    bool IsROundSTarted = false;
    public delegate void RoundSTart();
    public static event RoundSTart OnROundStart;
    public delegate void RoundEnd();
    public static event RoundSTart OnROundEnd;
    
    public static CarEscapeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        //Vibration.Init();

    }
    private void OnEnable()
    {
        ExitDoor.OnDoorExit += OnExitDoor;
    }
    private void OnDisable()
    {
        ExitDoor.OnDoorExit -= OnExitDoor;
    }
    private void Start()
    {
        Lvltxt.text = "Level " + SceneManager.GetActiveScene().buildIndex;
        OnROundStart?.Invoke();
    }
    private void Update()
    {   
        /*
        if (Input.GetMouseButtonUp(0) && !IsROundSTarted)
        { 
            IsROundSTarted=true;
            OnROundStart?.Invoke();
            TapTOstartTExt.SetActive(false);
        }
        */
    }
    private void OnExitDoor(bool WinStatus)
    {
        SetWIn(true);
    }
    public void SetWIn(bool Winstatus)
    {
        if (Winstatus == true)
        {
            Win_failPanels[0].SetActive(true);
        }
        else
        {
            Win_failPanels[1].SetActive(true);
        }
        OnROundEnd?.Invoke();
    }
    public void Restart()
    {
        /*
        if (Win_FailPanel[1].activeInHierarchy && GAScript.Instance && ISManager.instance)
        {
            GAScript.Instance.LevelFail(PlayerPrefs.GetInt("Level", 1).ToString());
            ISManager.instance.ShowInterstitialAds();
        }
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DOTween.KillAll();
        Vibration.Vibrate(30);
    }

    public void NextLevel()
    {
        /*
        if (GAScript.Instance)
            GAScript.Instance.LevelCompleted(PlayerPrefs.GetInt("Level", 1).ToString());
        if (ISManager.instance)
            ISManager.instance.ShowInterstitialAds();

        */
         int index = SceneManager.GetActiveScene().buildIndex;
        index++;
      
         if (index <= SceneManager.sceneCountInBuildSettings - 1)
         {
        
            SceneManager.LoadScene(index);
         }
         else
        {
             SceneManager.LoadScene(StartSceneIndex);
         }
        /*
        if (PlayerPrefs.GetInt("Level") >= (SceneManager.sceneCountInBuildSettings) - 1)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
            var i = Random.Range(2, SceneManager.sceneCountInBuildSettings);
            PlayerPrefs.SetInt("ThisLevel", i);
            SceneManager.LoadScene(i);
        }
        else
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        Vibration.Vibrate(30);
        */
        
    }
}
