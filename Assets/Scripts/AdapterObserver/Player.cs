using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject target;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            IInteractable interactable = target.GetComponent<IInteractable>();
            if(interactable != null)
            {
                Interact(interactable);
            }
        }
    }
    public void Interact(IInteractable interactable)
    {
        interactable.TargetInteract(this);
    }
}
