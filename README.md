# JobSim_Alone

[![Unity Version](https://img.shields.io/badge/Unity-2022.3+-blue.svg)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-green.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Windows-orange.svg)]()

`JobSim_Alone` is an atmospheric, first-person simulation game developed in Unity. The project combines immersive environment design with tight, modular mechanics to simulate an isolated, task-driven workspace. 

Built using a decoupled, component-based C# architecture, this project serves as a robust framework for physics-based interaction and environmental storytelling.

---

## 🚀 Key Features

* **Advanced First-Person Controller:** Responsive physics-based movement, looking, and state handling optimized for precise navigation within interior environments.
* **Modular Object Pickup System:** A dynamic, raycast-driven C# interaction system allowing players to pick up, hold, inspect, and drop physics-enabled objects seamlessly.
* **Immersive Atmosphere & Level Design:** Structured map layouts built utilizing optimized 3D prefabs to cultivate a solitary, focused workspace aesthetic ("Alone").
* **Clean Code & Git Workflow:** Well-structured project architecture separating concerns across scripts, prefabs, and scenes, maintained with a strict `.gitignore` to avoid merge conflicts.

---

## 🛠️ Tech Stack & Architecture

* **Engine:** Unity (2022.3 LTS recommended)
* **Language:** C# (.NET / Mono)
* **Physics:** Unity 3D Physics Engine (Rigidbodies, Colliders, Raycasting)
* **Target Platform:** Windows PC

---

## 📦 Project Structure

The project directory follows standard Unity best practices for clean asset management:

```text
Assets/
├── _Project/
│   ├── Scenes/          # Main gameplay, testing, and sandbox environments
│   ├── Scripts/         # Core C# systems (PlayerController, ObjectPickup, Interactivity)
│   ├── Prefabs/         # Pre-configured game objects (Player, Interactive props)
│   └── Materials/       # Environmental textures and shaders
