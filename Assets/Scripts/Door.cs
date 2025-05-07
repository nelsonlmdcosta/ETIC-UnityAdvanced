using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator AnimatorComponent = null;

    private bool IsBusy = false;
    private bool IsDoorOpen = false;
    
    private void Awake()
    {
        AnimatorComponent = GetComponent<Animator>();
    }

    public bool CanInteract(Interactor InteractorComponent)
    {
        return InteractorComponent.CompareTag("MainCamera") && IsBusy == false;
    }

    public void Interact(Interactor InteractorComponent)
    {
        // A ? B ? C;
        // A is the Condition, any boolean conditional checks work here, like booleans, || && etc etc
        // B is the return type if condition is true
        // C is the return type if the condition is false
        
        AnimatorComponent.SetTrigger(IsDoorOpen ? "DoDoorClose" : "DoDoorOpen");
        IsDoorOpen = !IsDoorOpen;

        StartCoroutine(DoWaitTimeForAnimation());
        
        //StopCoroutine(DoWaitTimeForAnimation());
    }

    private IEnumerator DoWaitTimeForAnimation()
    {
        IsBusy = true;
        yield return new WaitForSeconds(AnimatorComponent.GetCurrentAnimatorClipInfo(0).Length);
        IsBusy = false;
    }
}
