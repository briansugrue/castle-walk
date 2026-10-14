using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls a door's open/closed state by rotating its Transform and playing audio clips
public class DoorController : MonoBehaviour
{
    [Header("Door Settings")]
    public Transform doorTransform;                           // The Transform of the door object to rotate
    public Vector3 openRotation = new Vector3(0f, 90f, 0f);   // The rotation the door moves to when opened

    [Header("Audio")]
    public AudioSource audioSource;   // The AudioSource used to play door sounds
    public AudioClip doorOpenSound;   // Door open audio clip
    public AudioClip doorCloseSound;  // Door close audio clip

    private bool isOpen = false;
    private Vector3 closedRotation;   // Stores the door's original rotation so it can be restored when closed


    // Sets the door's starting rotation in the "closed" position
    void Start()
    {
        closedRotation = doorTransform.localEulerAngles;
    }

    // Toggles the door between open and closed states
    public void ToggleDoor()
    {
        if (isOpen)
            CloseDoor();
        else
            OpenDoor();
    }

    // Opens the door by rotating it to openRotation
    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;
        doorTransform.localEulerAngles = openRotation;
        PlayClip(doorOpenSound);
    }

    // Closes the door by restoring its original rotation
    public void CloseDoor()
    {
        if (!isOpen) return;
        isOpen = false;
        doorTransform.localEulerAngles = closedRotation;
        PlayClip(doorCloseSound);
    }

    // Plays an audio clip through the audio source
    private void PlayClip(AudioClip clip)
    {
        if (audioSource == null || clip == null)
            return;

        // Stop any currently playing sound
        audioSource.Stop();

        // Assign and play new clip
        audioSource.clip = clip;
        audioSource.Play();
    }
}