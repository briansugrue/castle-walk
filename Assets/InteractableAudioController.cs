using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Handles three audio events:
//      1. A grab sound when the player picks the object up
//      2. Surface specific impact sounds
//      3. A fallback impact sound for untagged surfaces

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class InteractableAudioController : MonoBehaviour
{
    // Nested class
    // Maps a Unity surface Tag to one or more audio clips
    [System.Serializable]
    public class SurfaceImpactEntry
    {
        [Tooltip("Must exactly match a Unity Tag (e.g. Wood, Stone, Metal).")]
        public string surfaceTag = "Default";

        [Tooltip("One or more clips; a random one plays on impact.")]
        public AudioClip[] clips;
    }


    // Inspector fields 
    [Header("Grab Sound")]
    [Tooltip("Played once when the player grabs this object.")]
    public AudioClip grabSound;

    [Header("Surface Impact Sounds")]
    [Tooltip("Add one entry per surface type. Order doesn't matter.")]
    public SurfaceImpactEntry[] surfaceImpacts;

    [Header("Fallback Impact")]
    [Tooltip("Played when no matching surface tag is found (e.g. ceiling, unknown wall).")]
    public AudioClip[] fallbackImpactSounds;

    [Header("Impact Settings")]
    [Tooltip("Minimum collision speed (m/s) to trigger an impact sound.")]
    public float impactVelocityThreshold = 1.5f;

    [Tooltip("Minimum seconds between impact sounds (prevents bounce spam).")]
    public float impactCooldown = 0.2f;

    [Header("Volume")]
    [Range(0f, 1f)] public float grabVolume = 1f;
    [Range(0f, 1f)] public float impactVolume = 1f;


    // Private state 
    private AudioSource _audio;
    private XRGrabInteractable _grabInteractable;
    private float _lastImpactTime = -999f;
    private bool _isHeld = false;


    // Lifecycle 
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _audio.playOnAwake = false;
    }

    void OnEnable()
    {
        _grabInteractable.selectEntered.AddListener(OnGrabbed);
        _grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnDisable()
    {
        _grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        _grabInteractable.selectExited.RemoveListener(OnReleased);
    }

  
    // Called when the player grabs the object
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        _isHeld = true;
        PlayClip(grabSound, grabVolume);
    }

    // Called when the player releases the object
    private void OnReleased(SelectExitEventArgs args)
    {
        _isHeld = false;
    }

    // Called by the Unity physics system when this object hits another collider
    private void OnCollisionEnter(Collision collision)
    {
        if (_isHeld) return;

        float speed = collision.relativeVelocity.magnitude;
        if (speed < impactVelocityThreshold) return;

        if (Time.time - _lastImpactTime < impactCooldown) return;
        _lastImpactTime = Time.time;

        AudioClip clip = GetImpactClip(collision.gameObject.tag);

        if (clip != null)
        {
            // Louder impact for faster throws, clamped between 40%–100% volume
            float volumeScale = Mathf.Clamp(speed / 10f, 0.4f, 1.0f);
            PlayClip(clip, impactVolume * volumeScale);
        }
    }

    // Searches surfaceImpacts for a matching tag and picks a random clip from its array
    private AudioClip GetImpactClip(string tag)
    {
        // Search the surface entries for a matching tag
        foreach (var entry in surfaceImpacts)
        {
            if (entry.surfaceTag == tag && entry.clips != null && entry.clips.Length > 0)
                return entry.clips[Random.Range(0, entry.clips.Length)];
        }

        // Fall back to generic clips (walls, ceiling, unknown surfaces)
        if (fallbackImpactSounds != null && fallbackImpactSounds.Length > 0)
            return fallbackImpactSounds[Random.Range(0, fallbackImpactSounds.Length)];

        return null;
    }

    // Plays a clip through the audio source using PlayOneShot
    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip == null) return;
        _audio.PlayOneShot(clip, volume);
    }
}
