# HW9 - Multiplayer Games

<p align="center">
  <img src="https://via.placeholder.com/900x180/101820/58D68D?text=HW9+-+Multiplayer+Games+%7C+Unity+%2B+Photon+Fusion" alt="HW9 Multiplayer Banner">
</p>

<p align="center">
  <a href="https://mayarom.itch.io/hw9-multiplayer-games">
    <b>Play the game on itch.io</b>
  </a>
</p>

---

## Overview

This repository contains my submission for Homework 9 in the "Game Development" course.

The project is a small 3D real-time multiplayer prototype built with **Unity** and **Photon Fusion**.  
Players move around a shared arena, change their appearance, shoot projectiles at each other, and compete for the highest score.

Core systems include:
- Networked movement
- Networked shooting and collisions
- Score tracking
- Health tracking

---

## Features

### Core Gameplay

- Third-person player controller in a small arena
- Movement, shooting, color changes and scoring are synchronized across all connected players
- Basic hit feedback through score and health changes

### Custom Additions For This Homework

The base classroom project was extended with two gameplay-oriented systems I implemented:

#### 1. Score System

- Each time a projectile hits another player, the **shooter** gains +1 score  
- The current score is displayed on screen using a **TextMeshPro** UI element  
- The score is updated and synchronized in real time for all participants

#### 2. Health System

- Every player has a **health value**
- When a player is hit by a projectile, their health is reduced
- Health is displayed in the UI using a dynamic **NumberField** element
- When health reaches zero, the player can be considered "defeated" (logic can be extended as needed)

---

## How To Play

### Controls

Movement  
- W A S D or Arrow Keys - Move the player  
- Left Shift - Temporary speed boost  

Actions  
- Space - Shoot a projectile  
- C - Change the player color  

### Objective

Move around the arena, avoid getting hit, and hit other players to:
- Increase your score
- Reduce your opponents' health
- Try to stay "alive" and end the session with the highest score

---

## Networking Modes

The project is configured to support Photon Fusion play modes such as:

- Host  
- Client  
- Shared Mode (Fusion play mode helper for local testing)

You can run multiple instances for quick local tests or connect over the network if properly configured.

---

## Build and Deployment

A playable WebGL build is available here:

- Itch.io page:  
  https://mayarom.itch.io/hw9-multiplayer-games

The project was developed and built using:

- Unity **6000.0.24f1**

---

## Technologies Used

- Unity 6000.0.24f1 (LTS)
- Photon Fusion
- C#
- TextMeshPro
- Unity UI

---

## Project Structure (High Level)

Typical high-level structure (exact folders may vary):

- `Assets/`  
  - `Scripts/`  
    - Player movement and input handling  
    - Shooting and projectile logic  
    - Score and health management  
    - Network-related components  
  - `Prefabs/`  
    - Player prefab  
    - Projectile prefab  
  - `Scenes/`  
    - Main multiplayer arena scene  
  - `UI/`  
    - Score text  
    - Health display

---

## Notes

- This project is primarily an academic exercise focused on:
  - Understanding real-time multiplayer concepts
  - Working with Photon Fusion inside Unity
  - Implementing basic game logic that is fully network-aware
- The systems are intentionally kept simple and readable so they can be extended easily:
  - New weapons
  - Different game modes
  - More advanced health and respawn logic
  - Visual polish and feedback (VFX, SFX, animations)

For any questions or suggestions, feel free to open an issue or comment on the itch.io page.
