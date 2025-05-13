using System.IO;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SaveData
{
    public int LivesLeft = 10;
}

// Save Manager
public class SaveGameSingleton
{
    private static SaveGameSingleton instance;
    public static SaveGameSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveGameSingleton();
            }

            return instance;
        }
    }

    private SaveData SaveGameData = new SaveData();

    public UnityEvent<SaveData> OnSaveRequestedEvent = new UnityEvent<SaveData>();
    public UnityEvent<SaveData> OnLoadRequestedEvent = new UnityEvent<SaveData>();

    public void SaveGameToFile()
    {
        // Warn Everyon That A Save Has Been Requested, And Pass The Object Along To Be Filled
        OnSaveRequestedEvent?.Invoke(SaveGameData);
        
        string DataToWriteOut = JsonUtility.ToJson(SaveGameData);
        
        File.WriteAllText( $"{Application.persistentDataPath}/SaveGameData.json", DataToWriteOut);
   }

    public void LoadSaveGameFromFile()
    {
        string JSONText = File.ReadAllText($"{Application.persistentDataPath}/SaveGameData.json");
        
        SaveGameData = JsonUtility.FromJson<SaveData>(JSONText);
        
        OnLoadRequestedEvent?.Invoke(SaveGameData);
    }
}
