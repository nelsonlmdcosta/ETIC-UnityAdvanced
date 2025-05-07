using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Bazooka", menuName = "ScriptableObjects/Bazooka", order = 1)]
public class Bazooka : AWeapon
{
    public override void FireWeapon()
    {
        
    }

    public override void ReloadWeapon()
    {
        //StartCoroutine(ReloadWaitTime());
    }

    protected override IEnumerator ReloadWaitTime()
    {
        // Wait for remove animation
        yield return new WaitForSeconds(1.0f);

        // Wait for add projectile animation
        yield return new WaitForSeconds(1.0f);
    }
}