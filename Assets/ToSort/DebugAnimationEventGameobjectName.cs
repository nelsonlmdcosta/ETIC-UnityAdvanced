using UnityEngine;

public class DebugAnimationEventGameobjectName : MonoBehaviour
{
    public void OnAnimEvent(GameObject objectReceived)
    {
        Debug.Log(objectReceived.name);
    }
}
