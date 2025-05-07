using System;
using UnityEngine;

public class LightTweaker : MonoBehaviour
{
    [SerializeField] private Light LightComponent = null;

    private void Awake()
    {
        LightComponent = GetComponent<Light>();
    }

    public void ChangeColorToRed()
    {
        LightComponent.color = Color.red;
    }
    
    public void ChangeColorToGreen()
    {
        LightComponent.color = Color.green;
    }

    public void ChangeColorToBlue()
    {
        LightComponent.color = Color.blue;
    }

    public void ToggleEnabledState()
    {
        LightComponent.color = new Color
        (
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f),
            1.0f
        );

        //LightComponent.enabled = !LightComponent.enabled;
        // WallSwitch temp;
        // temp.OnSwitchPulled.AddListener(ToggleEnabledState);
        // temp.OnSwitchPulled.RemoveListener(ToggleEnabledState);
    }
}
