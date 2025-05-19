using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum ESerializationType
{
    JSON,
    Binary,
    XML
}

// [StructLayout(LayoutKind.Sequential, Pack = 1)] // Might Talk About This Later
[System.Serializable]
public class SaveData
{
    public int LivesLeft = 10;

    public bool IsFullScreen = true;
}

// Save Manager
public class SaveGameSingleton // Non Monobehaviour, which means it'll live during the lifetime of the game application
{
    private static SaveGameSingleton instance;

    public static SaveGameSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveGameSingleton();
                instance.SetupCallbacks();
                instance.SetupSerializationType();
            }

            return instance;
        }
    }

#if UNITY_STANDALONE
    private ESerializationType SerializationType = ESerializationType.Binary;
#else
    private ESerializationType SerializationType = ESerializationType.JSON;
#endif

    // TODO: Include Things Like User And Slot Indices
    string saveToFilePath = $"{Application.persistentDataPath}/SaveGameData.json";

    private SaveData SaveGameData = new SaveData();

    public UnityEvent<SaveData> OnSaveRequestedEvent = new UnityEvent<SaveData>();
    public UnityEvent<SaveData> OnLoadRequestedEvent = new UnityEvent<SaveData>();

    private Action<SaveData> SerializationAction;
    private Action<SaveData> DeserializationAction;

    public void SaveGameToFile()
    {
        // Warn Everyone That A Save Has Been Requested, And Pass The Object Along To Be Filled
        OnSaveRequestedEvent?.Invoke(SaveGameData);
        
        SerializationAction?.Invoke(SaveGameData); 
    }

    public void LoadSaveGameFromFile()
    {
        DeserializationAction?.Invoke(SaveGameData);
        
        OnLoadRequestedEvent?.Invoke(SaveGameData);
    }
    
    private void SetupCallbacks()
    {
        // This Should Be Called Post Awake()
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene LoadedScene, LoadSceneMode LoadType)
    {
        // This means we hard loaded a level, therefore there might be objects in need of that loaded call
        //if (LoadType == LoadSceneMode.Single)

        // Additive objects need love too, so might as well not seperate them depending on our needs
        //if (LoadType == LoadSceneMode.Additive)

        // Warn All That Loading Has Happened An They're Getting Notified
        OnLoadRequestedEvent?.Invoke(SaveGameData);
    }

    // Note: This could take a parameter to override the default value. If we so chose to do so
    private void SetupSerializationType()
    {
        switch (SerializationType)
        {
            case ESerializationType.Binary:
                SerializationAction += BinarySerializationAction;
                DeserializationAction += BinaryDeserializationAction;
                break;
            case ESerializationType.JSON:
                SerializationAction += JSONSerializationAction;
                DeserializationAction += JSONDeserializationAction;
                break;
            case ESerializationType.XML:
            default:
                Debug.LogError("SaveManager::SetupSerializationType - Unsupported Serialization Type Used");
                break;
        }
    }

    // Could Always abstract these in the future into contained obejcts or utility function libs
    private void JSONSerializationAction(SaveData obj)
    {
        string DataToWriteOut = JsonUtility.ToJson(SaveGameData);

        File.WriteAllText($"{Application.persistentDataPath}/SaveGameData.json", DataToWriteOut);
    }

    private void JSONDeserializationAction(SaveData obj)
    {
        string JSONText = File.ReadAllText($"{Application.persistentDataPath}/SaveGameData.json");

        SaveGameData = JsonUtility.FromJson<SaveData>(JSONText);    }
    
    private void BinarySerializationAction(SaveData ObjectToSave)
    {
        // TODO: Cache These Strings
        string saveToFilePath = $"{Application.persistentDataPath}/SaveGameData.json";

        using (FileStream Stream = File.Open(saveToFilePath, FileMode.Create))
        {
            using (BinaryWriter Writer = new BinaryWriter(Stream, Encoding.UTF8, false))
            {
                // TODO: Use Marshalling
                byte[] BufferToWriteToFile = null;
                
                BinaryFormatter Formatter = new BinaryFormatter();
                using (MemoryStream MemoryStreamer = new MemoryStream())
                {
                    Formatter.Serialize(MemoryStreamer, SaveGameData);
                    BufferToWriteToFile = MemoryStreamer.ToArray();
                    
                    Writer.Write( BufferToWriteToFile );
                }
            }
        }
    }

    private void BinaryDeserializationAction(SaveData obj)
    {
        using (FileStream Stream = File.Open(saveToFilePath, FileMode.Create))
        {
            using (BinaryReader Reader = new BinaryReader(Stream, Encoding.UTF8, false))
            {
                // TODO: Use Marshalling
                
                SaveGameData = FromBinaryReader<SaveData>(Reader);
            }
        }
    }
    
    public static T FromBinaryReader<T>(BinaryReader reader)
    {
        int size = Marshal.SizeOf<T>();
        byte[] buffer = reader.ReadBytes(size);

        // Allocate The Memory So The Marshaller Can Directly Place The Binary Data Into The Specific Spot
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        try
        {
            IntPtr ptr = handle.AddrOfPinnedObject();
            return Marshal.PtrToStructure<T>(ptr);
        }
        finally
        {
            handle.Free();
        }
    }
}
