using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    public UnityEvent OnAnimationLoggedEvent;
    public UnityEvent OnTurnOnCollisionEvent;
    public UnityEvent<GameObject> OnTurnOffCollisionEvent;
    
    public void AnimationDebugLog()
    {
        OnAnimationLoggedEvent?.Invoke();
    }

    public void TurnOnCollision()
    {
        OnTurnOnCollisionEvent?.Invoke();
    }
    
    public void TurnOffCollision()
    {
        OnTurnOffCollisionEvent?.Invoke(gameObject);
    }
}
