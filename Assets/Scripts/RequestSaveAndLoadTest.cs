using System;
using UnityEngine;
using UnityEngine.Events;

public class RequestSaveAndLoadTest : MonoBehaviour
{
    public int CurrentLives = 10;

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
    }

    public void OnLoadRequested(SaveData SaveDataObject)
    {
        CurrentLives = SaveDataObject.LivesLeft;
    }
}
