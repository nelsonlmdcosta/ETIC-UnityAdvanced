using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 100.0f;
    [SerializeField] private float CurrentHealth = 0.0f;
    private float NormalizedHealth = 0.0f;

    [SerializeField] private bool SetCurrentHealthAsMaxHealth = true;

    public UnityEvent<float> OnDamageTakenEvent;
    public UnityEvent<float> OnGainedLifeEvent;
    public UnityEvent OnDiedEvent;
    
    private IEnumerator Start()
    {
        if (SetCurrentHealthAsMaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        NormalizedHealth = CurrentHealth / MaxHealth;

        yield return new WaitForEndOfFrame();
        
        OnGainedLifeEvent?.Invoke(NormalizedHealth);
    }

    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
        NormalizedHealth = CurrentHealth / MaxHealth;

        OnDamageTakenEvent?.Invoke(NormalizedHealth);

        if (CurrentHealth <= 0.0f)
        {
            OnDiedEvent?.Invoke();
        }
    }

    public void GainLife(float HealthAmount)
    {
        CurrentHealth += HealthAmount;
        NormalizedHealth = CurrentHealth / MaxHealth;

        OnGainedLifeEvent?.Invoke(NormalizedHealth);
    }
}
