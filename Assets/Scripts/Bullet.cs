using ProjectUtils;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolableObject
{
    private HashedName ObjectID;
    
    public void InitializePooledObject(HashedName ObjectID)
    {
        ObjectID = ObjectID; // We Keep Track Of This Information For Now, This Can Also Be Used As A Start Alternative
    }

    public void OnPoolObjectRequested(GameObject Instigator)
    {
        gameObject.SetActive(true);
        
        LocatorComponent Locators = Instigator.GetComponent<LocatorComponent>();
        if (Locators)
        {
            Transform ShootLocator = Locators.ShootLocator;
            if (ShootLocator)
            {
                transform.position = ShootLocator.position;
                transform.rotation = ShootLocator.rotation;
            }
        }
        
        // TODO: Apply Force Forwards
        // TODO: Default TO Instigator Transform
    }

    public void OnPoolObjectReturned(GameObject Instigator)
    {
        transform.position = Instigator.transform.position;
        transform.parent = Instigator.transform;
        gameObject.SetActive(false);
    }

    public void TerminatePooledObject()
    {
        // Nothing Really To Do In This Case But Be Destroyed
    }
}
