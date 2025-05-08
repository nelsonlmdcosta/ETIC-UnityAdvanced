using System;
using ObjectPoolSystem;
using ProjectUtils;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private SceneObjectPool CachedPool;

    private HashedName BulletID = new HashedName("Bullet");
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetOrFindSceneObjectPool().RequestPooledObject(BulletID);
        }
    }

    private SceneObjectPool GetOrFindSceneObjectPool()
    {
        if (CachedPool == null)
            CachedPool = SceneObjectPool.Instance;

        return CachedPool;
    }
}
