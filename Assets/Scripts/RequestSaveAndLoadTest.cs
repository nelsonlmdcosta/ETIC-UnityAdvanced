using System;
using System.Runtime.Serialization;
using UnityEngine;

public class RequestSaveAndLoadTest : MonoBehaviour, ISaveable
{
    public int CurrentLives = 10;

    public bool RuntimeIsFullscreen = true;

    public void Awake()
    {
        SaveGameSingleton.Instance.OnSaveRequestedEvent.AddListener(OnSaveRequested);
        SaveGameSingleton.Instance.OnLoadRequestedEvent.AddListener(OnLoadRequested);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveGameSingleton.Instance.LoadSaveGameFromFile();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGameSingleton.Instance.SaveGameToFile();
        }
    }

    public void OnSaveRequested(SaveData SaveDataObject)
    {
        SaveDataObject.LivesLeft = CurrentLives;

        SaveDataObject.IsFullScreen = RuntimeIsFullscreen;
    }

    public void OnLoadRequested(SaveData SaveDataObject)
    {
        CurrentLives = SaveDataObject.LivesLeft;

        RuntimeIsFullscreen = SaveDataObject.IsFullScreen;
        Screen.fullScreen = RuntimeIsFullscreen;
    }
    
    // Some UI Callback
    public void OnFullScreenRadioButtonStateChanged(bool newState)
    {
        RuntimeIsFullscreen = newState;
        Screen.fullScreen = RuntimeIsFullscreen;
    }
}
