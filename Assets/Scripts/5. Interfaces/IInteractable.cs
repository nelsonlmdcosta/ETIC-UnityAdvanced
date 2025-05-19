using UnityEngine;

public interface IInteractable
{
    public bool CanInteract(Interactor InteractorComponent)
    {
        return true;
    }

    public void Interact(Interactor InteractorComponent);
}
