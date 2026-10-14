using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Switches the footstep audio source's output mixer group when the player
// enters a trigger zone, giving each room type its own reverb
public class ReverbZoneSwitcher : MonoBehaviour
{
    public AudioSource footstepSource;   // The audio source playing footstep sounds

    // One audio mixer group per room type
    public AudioMixerGroup hubRoomGroup;
    public AudioMixerGroup jailGroup;
    public AudioMixerGroup hallwayGroup;
    public AudioMixerGroup woodGroup;
    public AudioMixerGroup sewerGrateGroup;

    // Defines the available room acoustic environments
    public enum RoomType
    {
        Hub_Room,
        Jail,
        Stone_Hallway,
        Wood,
        Sewer_Grate
    }

    public RoomType roomType;

    // If the player enters, reroute the footstep audio source to the mixer group that matches this zone's RoomType
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))   // Only respond to the player entering. Ignore other colliders
        {
            switch (roomType)   // Route the footstep source to the appropriate mixer group for this room
            {
                case RoomType.Hub_Room:
                    footstepSource.outputAudioMixerGroup = hubRoomGroup;
                    break;

                case RoomType.Jail:
                    footstepSource.outputAudioMixerGroup = jailGroup;
                    break;

                case RoomType.Stone_Hallway:
                    footstepSource.outputAudioMixerGroup = hallwayGroup;
                    break;

                case RoomType.Wood:
                    footstepSource.outputAudioMixerGroup = woodGroup;
                    break;

                case RoomType.Sewer_Grate:
                    footstepSource.outputAudioMixerGroup = sewerGrateGroup;
                    break;
            }
        }
    }
}