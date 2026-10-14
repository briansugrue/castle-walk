using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Handles an XR-Interactable button that toggles a door open/closed
public class DoorButton : MonoBehaviour
{
    public DoorController door;   // Reference to the door the button controls

    private XRSimpleInteractable interactable;   // The XR interactable component used to detect player input

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(OnPressed);
    }

    // Toggle door between open and closed states when button pressed
    private void OnPressed(SelectEnterEventArgs args)
    {
        if (door != null)
            door.ToggleDoor();
    }

    // Clean up the Event Listener when the object is destroyed
    void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnPressed);
    }
}
