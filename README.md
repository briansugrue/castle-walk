# Castle Walk XR 🏰🎧

**Castle Walk** is an immersive XR exploration game developed in Unity for the PICO 4 VR headset. Rather than relying on traditional game objectives or competition, the project treats **spatial and interactive audio as the primary core gameplay mechanic** to drive player curiosity and room-to-room exploration.

---

## 🌟 Key Features & Design Philosophy

* **Audio-Driven Exploration:** Inspired by proximity-based audio cues (such as the Nirnroot plant from *The Elder Scrolls V: Skyrim*), the game encourages players to investigate distinct sonic identities across four unique areas.
* **Acoustically Distinct Rooms:** Features a central Hub Room, Armoury, Jail, and Alchemy Lab, each characterized by customized environmental ambisonics, audio mixer reverbs, and surface-dependent drop sounds.
* **Advanced Spatial Audio & Occlusion:** Utilizes the Steam Audio SDK to calculate realistic sound propagation and audio occlusion (such as muffled water streams passing through stone doorways).
* **Dynamic Interaction Systems:** Implements custom C# controllers (`DoorButton.cs`, `DoorController.cs`, and `InteractableAudioController.cs`) allowing fluid button triggers, door rotations, and object grab-and-rotate physics.

---

## 🗺️ Castle Layout & Sound Design

| Room | Sonic Characteristics & Ambiance | Reverb / Acoustic Profile |
| :--- | :--- | :--- |
| **Hub Room** | Cold atmosphere, prominent brazier fire source; completely dry of background ambience to match its large stone geometry. | High reverberation, large hall reverb. |
| **Armoury** | Industrial, war-like impression featuring tanker truck metal clangs. | Drier acoustic profile governed by "Wood" floor reverb settings. |
| **Jail** | Eerie ambient stereo loop paired with interactive stone walls and interactive iron chain mechanics. | Acoustically tight stone hallway/jail reverb. |
| **Alchemy Lab** | Mystical character driven by elephant bell sound beds and bubbling cauldron effects. | Low reverberation/dry "Wood" floor profile. |

---

## 🛠️ Technical Implementation

* **Engine:** Unity
* **Target Hardware:** PICO 4 All-in-One VR Headset
* **Spatial Audio SDK:** Steam Audio SDK
* **Performance Optimization:** Utilizes optimized low-poly dungeon environmental assets from the Unity Asset Store to maintain stable VR frame rates.
* **Source Audio Libraries:** Sound effects sourced and minimally processed from Freesound, the BBC Sound Library, and the Rode Ambisonic Sound Library.

---

## 🚀 Getting Started (Cloning & Setup)

To clone and open this project locally:

1. Clone the repository to your local machine:
   ```bash
   git clone [https://github.com/YourUsername/Castle-Walk.git](https://github.com/YourUsername/Castle-Walk.git)
