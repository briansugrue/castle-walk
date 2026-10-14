using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plays footstep sounds as the player moves around the game
public class FootstepController : MonoBehaviour
{
    public Transform playerTransform; // assign Main Camera here

    public float stepDistance = 0.5f;        // Player needs to travel 0.5m for a footstep sound to play
    private float accumulatedDistance = 0f;  // Total distance travelled since the previous footstep
    private Vector3 lastPosition;

    public AudioSource audioSource;
    public AudioClip[] footstepClips;   // Randomise footstep sound using audio clips

    void Start()
    {
        lastPosition = playerTransform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, lastPosition);
        accumulatedDistance += distance;

        if (accumulatedDistance > stepDistance)
        {
            accumulatedDistance = 0f;
            PlayFootstep();
        }

        lastPosition = playerTransform.position;
    }

    // Plays a footstep sound through the audio source
    void PlayFootstep()
    {
        audioSource.Play();
    }
}