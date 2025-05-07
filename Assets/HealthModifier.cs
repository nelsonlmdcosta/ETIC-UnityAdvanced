using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    public HealthComponent Health { get; set; }

    private void Awake()
    {
        Health = GetComponent<HealthComponent>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Health.TakeDamage(UnityEngine.Random.Range(0, 10));
        }
        
        if(Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Health.GainLife(UnityEngine.Random.Range(0, 10));
        }
    }
}
