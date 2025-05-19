using UnityEngine;

public class DebugSaveStuff : MonoBehaviour, ISaveable
{
    private void Awake()
    {
        SaveGameSingleton.Instance.OnSaveRequestedEvent.AddListener(OnSaveRequested);
        SaveGameSingleton.Instance.OnLoadRequestedEvent.AddListener(OnLoadRequested);
    }

    public void OnSaveRequested(SaveData SaveGameData)
    {
        Debug.Log($"OnSaveRequested");
    }

    public void OnLoadRequested(SaveData SaveGameData)
    {
        Debug.Log($"OnLoadRequested");
        
        // We Can Also Unregister From Here To Avoid Any Other Cases Of "Loaded Data"
    }
}


