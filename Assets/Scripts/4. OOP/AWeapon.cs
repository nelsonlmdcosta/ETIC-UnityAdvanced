using System.Collections;
using UnityEngine;

public abstract class AWeapon : ScriptableObject
{
    [SerializeField] private float BulletPerSecond = 30.0f;
    [SerializeField] private float ReloadTime = 1.0f;
    [SerializeField] private float RecoilAngles = 30.0f;
    
    public abstract void FireWeapon();
    public abstract void ReloadWeapon();
    
    protected virtual IEnumerator ReloadWaitTime()
    {
        yield return new WaitForSeconds(ReloadTime);
        
        // CurrentMagazine = MaxBullets;
    }
}
