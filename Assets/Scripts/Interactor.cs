using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float InteractionMaxDistance = 10.0f;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast( transform.position, transform.forward, out RaycastHit HitInformation, InteractionMaxDistance  ))
        {
            IInteractable InteractableComponent = HitInformation.transform.GetComponent<IInteractable>();
            if (InteractableComponent != null && InteractableComponent.CanInteract(this))
            {
                InteractableComponent.Interact(this);
            }
            
            Debug.DrawLine(transform.position, HitInformation.point, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * InteractionMaxDistance, Color.red);
        }
    }
}
