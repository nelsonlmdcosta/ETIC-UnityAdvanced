using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonMonobehaviourType : MonoBehaviour
{
    private static SingletonMonobehaviourType instance;

    public SingletonMonobehaviourType Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject SingletonGameObject = new GameObject("SingletonMonobehaviour");
                instance = SingletonGameObject.AddComponent<SingletonMonobehaviourType>();

                SceneManager.activeSceneChanged += OnSceneChanged;
            }

            return instance;
        }
    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        instance = null;
    }
}
