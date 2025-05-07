using UnityEngine;

[CreateAssetMenu(fileName = "Pistol", menuName = "ScriptableObjects/Pistol", order = 1)]
public class Pistol : AWeapon
{
    public override void FireWeapon()
    {
        
    }

    public override void ReloadWeapon()
    {
        //StartCoroutine(ReloadWaitTime());
    }
}