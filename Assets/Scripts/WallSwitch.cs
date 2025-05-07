using UnityEngine;
using UnityEngine.Events;

public class WallSwitch : MonoBehaviour, IInteractable
{
    public UnityEvent OnSwitchPulled;
    
    public void Interact(Interactor InteractorComponent)
    {
        OnSwitchPulled.Invoke();
    }
}
