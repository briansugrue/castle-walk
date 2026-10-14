using UnityEngine;

// Simulates a chicken getting "eaten" if it touches the sewer grate
[RequireComponent(typeof(AudioSource))]
public class SewerGrate : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip eatSound;   // Sound to play when a chicken is consumed

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // If the entering object is tagged "Chicken", plays the eat sound and destroy the chicken object immediately
    private void OnTriggerEnter(Collider other)
    {
        // Check if chicken entered
        if (other.CompareTag("Chicken"))
        {
            // Play monster eating sound
            if (eatSound != null)
            {
                audioSource.PlayOneShot(eatSound);
            }

            // Destroy chicken
            Destroy(other.gameObject);
        }
    }
}
