using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    public UnityEvent OnAnimationLoggedEvent;
    public UnityEvent OnTurnOnCollisionEvent;
    public UnityEvent<GameObject> OnTurnOffCollisionEvent;
    
    public UnityEvent<Color> OnAnimationChangeAlbedoTintToRandomColorV1;
    public UnityEvent<Color> OnAnimationChangeAlbedoTintToRandomColorV2;

    [SerializeField] private GameObject ParticleSystem1Prefab;
    [SerializeField] private GameObject ParticleSystem2Prefab;
    
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

    public void RandomizeColor()
    {
        OnAnimationChangeAlbedoTintToRandomColorV1?.Invoke(new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), 1.0f));
    }
    
    public void RandomizeColor2()
    {
        OnAnimationChangeAlbedoTintToRandomColorV2?.Invoke(new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), 1.0f));
    }

    public void SpawnParticleEffects()
    {
        Instantiate(ParticleSystem1Prefab, transform.position, quaternion.identity);
    }

    public void SpawnParticleEffects2()
    {
        Instantiate(ParticleSystem2Prefab, transform.position + Vector3.one, quaternion.identity);
    }
}
