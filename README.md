# Castle Walk XR 🏰🎧

**Castle Walk** is an immersive XR exploration game developed in Unity for the PICO 4 VR headset. Rather than relying on traditional game objectives or competition, the project treats **spatial and interactive audio as the primary core gameplay mechanic** to drive player curiosity and room-to-room exploration[cite: 1].

---

## 🌟 Key Features & Design Philosophy

* **Audio-Driven Exploration:** Inspired by proximity-based audio cues (such as the Nirnroot plant from *The Elder Scrolls V: Skyrim*)[cite: 1], the game encourages players to investigate distinct sonic identities across four unique areas[cite: 1].
* **Acoustically Distinct Rooms:** Features a central Hub Room, Armoury, Jail, and Alchemy Lab[cite: 1], each characterized by customized environmental ambisonics, audio mixer reverbs, and surface-dependent drop sounds[cite: 2, 3].
* **Advanced Spatial Audio & Occlusion:** Utilizes the Steam Audio SDK to calculate realistic sound propagation and audio occlusion (such as muffled water streams passing through stone doorways)[cite: 1].
* **Dynamic Interaction Systems:** Implements custom C# controllers (`DoorButton.cs`, `DoorController.cs`, and `InteractableAudioController.cs`) allowing fluid button triggers, door rotations, and object grab-and-rotate physics[cite: 2].

---

## 🗺️ Castle Layout & Sound Design

| Room | Sonic Characteristics & Ambiance | Reverb / Acoustic Profile |
| :--- | :--- | :--- |
| **Hub Room** | Cold atmosphere, prominent brazier fire source[cite: 1, 2]; completely dry of background ambience to match its large stone geometry[cite: 2]. | High reverberation, large hall reverb[cite: 2]. |
| **Armoury** | Industrial, war-like impression featuring tanker truck metal clangs[cite: 2]. | Drier acoustic profile governed by "Wood" floor reverb settings[cite: 2]. |
| **Jail** | Eerie ambient stereo loop paired with interactive stone walls and interactive iron chain mechanics[cite: 2, 3]. | Acoustically tight stone hallway/jail reverb[cite: 2]. |
| **Alchemy Lab** | Mystical character driven by elephant bell sound beds and bubbling cauldron effects[cite: 2, 3]. | Low reverberation/dry "Wood" floor profile[cite: 2]. |

---

## 🛠️ Technical Implementation

* **Engine:** Unity[cite: 1]
* **Target Hardware:** PICO 4 All-in-One VR Headset[cite: 1]
* **Spatial Audio SDK:** Steam Audio SDK[cite: 1]
* **Performance Optimization:** Utilizes optimized low-poly dungeon environmental assets from the Unity Asset Store to maintain stable VR frame rates[cite: 3].
* **Source Audio Libraries:** Sound effects sourced and minimally processed from Freesound, the BBC Sound Library, and the Rode Ambisonic Sound Library[cite: 2].

---

## 🚀 Getting Started (Cloning & Setup)

To clone and open this project locally:

1. Clone the repository to your local machine:
   ```bash
   git clone [https://github.com/YourUsername/Castle-Walk.git](https://github.com/YourUsername/Castle-Walk.git)
