using ProjectUtils;
using UnityEngine;

public interface IPoolableObject
{
    public abstract void InitializePooledObject(HashedName ObjectID);

    public abstract void OnPoolObjectRequested(GameObject Instigator);

    public abstract void OnPoolObjectReturned(GameObject Instigator);
    
    public abstract void TerminatePooledObject();
}
