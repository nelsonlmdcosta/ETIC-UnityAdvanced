using System;
using UnityEngine;

public class PulsingLight : MonoBehaviour
{
    [SerializeField] private float MaxIntensity = 20.0f;

    [SerializeField] private float SpeedMultiplier = 1.0f;
    
    private Light LightComponent = null;
    private float Timer = 0.0f;

    private void Awake()
    {
        LightComponent = GetComponent<Light>();
    }

    private void Update()
    {
        Timer += Time.deltaTime * SpeedMultiplier;

        LightComponent.intensity = ((Mathf.Sin(Timer) + 1) / 2) * MaxIntensity;
    }
}
