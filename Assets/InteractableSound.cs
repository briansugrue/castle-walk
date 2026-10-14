using UnityEngine;

// Plays a sound when Interact() is called
[RequireComponent(typeof(AudioSource))]
public class InteractableSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip soundClip;   // The audio clip to play when an interaction happens

    [Header("Options")]
    public bool destroyAfterPlaying = false;  // If true, this destroys the game object once the clip finishes playing
    public bool disableRenderer = false;

    private AudioSource audioSource;

    // Caches the AudioSource component for use in Interact()
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Triggers the interaction and plays the assigned audio clip
    public void Interact()
    {
        if (soundClip == null)
            return;

        // Stop previous sound
        audioSource.Stop();

        // Play new sound
        audioSource.clip = soundClip;
        audioSource.Play();

        // Optional visual disable
        if (disableRenderer)
        {
            Renderer[] renderers =
                GetComponentsInChildren<Renderer>();

            foreach (Renderer r in renderers)
            {
                r.enabled = false;
            }
        }

        // Optional destroy
        if (destroyAfterPlaying)
        {
            Destroy(gameObject, soundClip.length);
        }
    }
}