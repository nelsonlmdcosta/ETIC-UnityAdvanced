using UnityEngine;

// This needs implementing and registering during the Awake()
public interface ISaveable
{
    void OnSaveRequested(SaveData SaveGameData);
    void OnLoadRequested(SaveData SaveGameData);
}

