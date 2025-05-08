using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProjectUtils;
using UnityEngine;

namespace ObjectPoolSystem
{
    // Config Object For Editor Purposes Only
    [Serializable]
    public class PooledObjectConfig
    {
        public HashedName PoolKey = new HashedName("Test"); // Key for this prefab type
        public GameObject Prefab; // The prefab to pool
        public int InitialSize = 10; // Initial pool size
        public bool WarnOnExpansion = true; // Whether the pool can grow
        public int MaxSize = 100; // Maximum pool size (if expandAutomatically is true)
    }

    public class SceneObjectPool : MonoBehaviour
    {
        #region LazySingleton

        // Singleton instance
        private static SceneObjectPool instance;
        public static SceneObjectPool Instance
        {
            get
            {
                if (instance == null)
                {
                    // TODO: Simplify This
                    // One Already Exists In Scene So Let's Use That One
                    SceneObjectPool InSceneObjectPool = FindFirstObjectByType<SceneObjectPool>();
                    if (InSceneObjectPool != null)
                    {
                        return instance = InSceneObjectPool;
                    }

                    // Otherwise Generate One
                    GameObject go = new GameObject("Object Pool Manager");
                    instance = go.AddComponent<SceneObjectPool>();
                }
                return instance;
            }
        }

        #endregion
        
        // Config list that can be set up in the editor
        [SerializeField] private List<PooledObjectConfig> PoolConfigurations = new List<PooledObjectConfig>();
        
        // TODO: Use This Later
        // Cache original prefabs for instantiation in case we need it later
        private Dictionary<HashedName, GameObject> ObjectPrefabDictionary = new Dictionary<HashedName, GameObject>();
        
        // Dictionary that maps string hashes to lists of GameObjects
        private Dictionary<HashedName, Stack<GameObject>> ObjectPoolDictionary = new Dictionary<HashedName, Stack<GameObject>>();

        private void Start()
        {
            InitializePools();
        }

        private void OnDestroy()
        {
            TerminatePools();
        }

        #region Initialization And Termination
        private void InitializePools()
        {
            for (int i = 0; i < PoolConfigurations.Count; ++i)
            {
                PooledObjectConfig ConfigObject = PoolConfigurations[i];
                if(ConfigObject == null)
                    continue;

                ObjectPoolDictionary[ConfigObject.PoolKey] = GeneratePooledObjectsWithConfig(ConfigObject);
            }
        }

        private Stack<GameObject> GeneratePooledObjectsWithConfig(PooledObjectConfig ConfigObject)
        {
            Stack<GameObject> GeneratedPooledObjects = new Stack<GameObject>();
            for (int i = 0; i < ConfigObject.InitialSize; ++i)
            {
                // Generate And Attach Them To Us
                GameObject GeneratedObject = Instantiate(ConfigObject.Prefab, transform.position, Quaternion.identity, transform) as GameObject;
                GeneratedObject.SetActive(false);
                
                GeneratedPooledObjects.Push(GeneratedObject);
                
                // TODO: Use An Interface For Intiialization For The Object
            }

            return GeneratedPooledObjects;
        }
        
        private void TerminatePools()
        {
            foreach(KeyValuePair<HashedName, Stack<GameObject>> item in ObjectPoolDictionary)
            {
                Stack<GameObject> InstancesToClearOut = item.Value;
                while ( InstancesToClearOut.Count > 0 )
                {
                    Destroy(InstancesToClearOut.Pop());
                }
            }
            
            ObjectPrefabDictionary.Clear();
            ObjectPoolDictionary.Clear();
        }
        #endregion

        public GameObject RequestPooledObject(HashedName ObjectID)
        {
            Stack<GameObject> PooledObjects;
            if (ObjectPoolDictionary.TryGetValue( ObjectID, out PooledObjects))
            {
                if (PooledObjects.Count > 0)
                {
                    return PooledObjects.Pop(); // Stacks Are Great For This So We Avoid Pushing Elements Around In Lists
                }
                
                // TODO: Generate A New One
            }

            return null;
        }

        public void ReturnObjectToPool(HashedName ObjectID, GameObject ObjectToReturn)
        {
            if (ObjectPoolDictionary.ContainsKey(ObjectID))
            {
                ObjectPoolDictionary[ObjectID].Push(ObjectToReturn);
            }
        }
    }
}