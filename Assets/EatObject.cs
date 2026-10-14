using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Represents a food item that can be grabbed in VR and eaten by bringing it to the player's mouth
[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(AudioSource))]
public class EdibleObject : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip eatSound;   // Sound to play when the object is eaten

    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    private bool hasBeenEaten = false; // Prevents Eat() from firing more than once

    // Prevents the food item from physically pushing the CharacterController
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        Collider foodCollider = GetComponent<Collider>();

        CharacterController player =
            FindObjectOfType<CharacterController>();

        if (player != null && foodCollider != null)
        {
            Physics.IgnoreCollision(
                foodCollider,
                player.GetComponent<Collider>()
            );
        }
    }

    // Calls MouthTrigger to consume the food item
    public void Eat()
    {
        // Prevent Eat() from running twice on the same object
        if (hasBeenEaten)
            return;

        hasBeenEaten = true;

        // Disable interaction immediately
        grabInteractable.enabled = false;

        // Disable collider
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        // Hide all renderers
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        // Stop physics
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        // Play eating sound
        if (eatSound != null)
        {
            audioSource.PlayOneShot(eatSound);

            // Destroy after sound finishes
            Destroy(gameObject, eatSound.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
