# HW9 - Multiplayer Games

<p align="center">
  <img src="./HW9_PNG.png" alt="HW9 Multiplayer Banner" style="width:75%; max-width:750px; border-radius:6px; box-shadow:0 0 12px rgba(0,0,0,0.25); margin-top:10px;">
</p>

<p align="center">
  <a href="https://mayarom.itch.io/hw9-multiplayer-games"><b>Play the game on itch.io</b></a>
</p>

---

## 1. Overview

This repository contains my submission for Homework 9 in the "Game Development" course.

The project is a 3D real-time multiplayer prototype built with **Unity** and **Photon Fusion**.  
Players move around a shared arena, change their appearance, shoot projectiles, and compete for the highest score.

The implementation includes:
- Networked movement  
- Networked shooting + hit detection  
- Score system  
- Health system  
- Full synchronization across clients  

---

## 2. Gameplay Features

### 2.1 Core Gameplay
- Third-person movement in a compact arena  
- Real-time multiplayer using Photon Fusion  
- Synchronized:
  - Player movement  
  - Projectile spawning and collisions  
  - Score updates  
  - Health values  
  - Player color  

### 2.2 Custom Additions for the Assignment

#### 2.2.1 Score System
- Each successful hit with a projectile gives the **shooter** +1 score  
- Score is displayed using a **TextMeshPro** UI element  
- Updated instantly for all players  

#### 2.2.2 Health System
- Each player has a health value  
- Getting hit reduces health  
- Health displayed using a dynamic **NumberField** UI element  
- When health reaches zero, the player is considered defeated  

---

## 3. How To Play

### 3.1 Controls
**Movement**
- W A S D / Arrow Keys — Move  
- Left Shift — Speed boost  

**Actions**
- Space — Shoot  
- C — Change player color  

### 3.2 Objective
Avoid getting hit, shoot other players, and try to finish with the highest score.

---

## 4. Networking Modes

Supported Photon Fusion modes:
- **Host** — Runs the simulation and plays  
- **Client** — Joins an existing session  
- **Shared Mode** — Local simulation for testing  

---

## 5. Build and Deployment

### 5.1 WebGL Build
Available here:  
**https://mayarom.itch.io/hw9-multiplayer-games**

### 5.2 Development Environment
- Unity **6000.0.24f1 (LTS)**  
- Photon Fusion SDK  

---

## 6. Requirements
- Unity 6000.0.24f1  
- Photon Fusion installed  
- Valid Photon App ID  

---

## 7. Running the Project in Unity
1. Clone the repository  
2. Open with Unity 6000.0.24f1  
3. Configure Photon Fusion (App ID, region)  
4. Open the main scene (`Scenes/MainMultiplayerScene`)  
5. Press Play:
   - Host  
   - Client  
   - Shared Mode  

---

## 8. Technologies Used
- Unity 6000.0.24f1  
- Photon Fusion  
- C#  
- TextMeshPro  
- Unity UI  

---

## 9. High-Level Project Structure
Assets/
Scripts/
Player/
PlayerMovement.cs
PlayerColorController.cs
PlayerHealth.cs
PlayerScore.cs
Networking/
NetworkRunnerHandler.cs
ProjectileNetworkLogic.cs
Gameplay/
ProjectileController.cs
GameManager.cs

Prefabs/
Player.prefab
Projectile.prefab

Scenes/
MainMultiplayerArena.unity

UI/
ScoreDisplay.prefab
HealthDisplay.prefab

- **Player** — Handles player movement, appearance, scoring and health  
- **Networking** — Fusion session management and synchronization  
- **Gameplay** — Projectile logic and game manager  
- **UI** — Score and health displays 
