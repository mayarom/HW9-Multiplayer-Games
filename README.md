# HW9 - Multiplayer Games

<p align="center">
  <img src="./HW9_PNG.png" alt="HW9 Multiplayer Banner" width="900">
</p>

<p align="center">
  <a href="https://mayarom.itch.io/hw9-multiplayer-games">
    <b>Play the game on itch.io</b>
  </a>
</p>

---

## 1. Overview

This repository contains my submission for Homework 9 in the "Game Development" course.

The project is a small 3D real-time multiplayer prototype built with **Unity** and **Photon Fusion**.  
Multiple players can connect to a shared arena, move around, change their appearance, shoot projectiles, and compete for the highest score.

The implementation focuses on:

- Authoritative networked movement  
- Networked shooting and hit detection  
- Score and health systems that are synchronized across clients  

---

## 2. Gameplay Features

### 2.1 Core Gameplay

- Third-person style movement in a compact arena  
- Real-time multiplayer using Photon Fusion  
- Synchronized:
  - Player movement  
  - Shooting and projectile spawning  
  - Hit detection and scoring  
  - Basic state (color, health, score)  

### 2.2 Custom Additions for the Assignment

The base classroom project was extended with two gameplay systems, implemented specifically for this homework.

#### 2.2.1 Score System

- Each time a projectile successfully hits another player, the **shooter** gains +1 score  
- The current score is displayed on screen using a **TextMeshPro** UI element  
- Score is updated in real time so that all clients see the correct value  

#### 2.2.2 Health System

- Every player has a **health value**  
- When a player is hit by a projectile, their health is reduced  
- Health is displayed in the UI using a dynamic **NumberField** element  
- When health reaches zero, the player is considered "defeated" (the logic is kept simple and can be extended with respawn, game over, etc.)  

---

## 3. How To Play

### 3.1 Controls

**Movement**

- W A S D or Arrow Keys - Move the player  
- Left Shift - Temporary speed boost  

**Actions**

- Space - Shoot a projectile  
- C - Change the player color  

### 3.2 Objective

- Navigate the arena while avoiding incoming projectiles  
- Hit other players to:
  - Increase your score  
  - Reduce their health  
- Try to remain alive and finish the session with the highest score  

---

## 4. Networking Modes

The project is configured to use Photon Fusion and supports several play modes, including:

- **Host** - Runs the simulation and also participates as a player  
- **Client** - Connects to a running host session  
- **Shared Mode** - Fusion play mode helper for quick local simulation and debugging  

This allows testing both locally with multiple instances and remotely (given valid Photon configuration).

---

## 5. Build and Deployment

### 5.1 WebGL Build

A playable WebGL build is available here:

- Itch.io page:  
  **https://mayarom.itch.io/hw9-multiplayer-games**

### 5.2 Development Environment

- Unity **6000.0.24f1 (LTS)**  
- Photon Fusion (Unity package)  

---

## 6. Requirements

- Unity 6000.0.24f1 (or compatible 6000.x LTS)  
- Photon Fusion SDK installed and configured  
- Valid Photon App ID (for running networked sessions outside of local simulation)  

---

## 7. Running the Project in Unity

1. Clone this repository.  
2. Open the project in Unity 6000.0.24f1.  
3. Ensure Photon Fusion is installed and configured (App ID, region, etc.).  
4. Open the main scene (e.g. `Scenes/MainMultiplayerScene` or equivalent, depending on the final folder name).  
5. Enter Play Mode:
   - Start as Host  
   - Start as Client (in another instance)  
   - Or use Shared Mode for local testing  

---

## 8. Technologies Used

- **Unity 6000.0.24f1 (LTS)**  
- **Photon Fusion**  
- **C#**  
- **TextMeshPro**  
- Unity UI components  

---

## 9. High-Level Project Structure

A typical high-level layout (names may vary slightly):

```text
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
    Scripts/Player - Player movement, state, and interaction logic
    Scripts/Networking - Fusion-related scripts for handling sessions and synchronization
    Scripts/Gameplay - Game flow and projectile behavior
    Prefabs - Reusable game objects for players and projectiles
    Scenes - Main arena and any supporting scenes
    UI - Score and health display elements
    ScoreDisplay.prefab
    HealthDisplay.prefab
