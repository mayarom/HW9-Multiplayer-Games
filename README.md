# HW9 – Multiplayer Games  
Homework 9 for the “Game Development” course.

## 🎮 Game Description  
This assignment implements a small 3D multiplayer prototype using Unity and Fusion.  
Players can move in a shared arena, shoot projectiles, and gain score when hitting another player.

The game syncs movement, shooting, collisions, and scoring across all players in real-time.

---

## 🆕 Changes I Added  
This homework required each student to add **two improvements** to the base classroom project.  
My two additions are:

### 1. Score System  
Every time a player hits another player with a projectile, the shooter gains +1 score.  
The score is displayed on-screen using a TextMeshPro UI element.

### 2. Health System  
Each player now has health.  
Being hit reduces health, and health is displayed using a dynamic NumberField UI element.

---

## 🕹️ How to Play  

### Movement  
- **WASD / Arrow keys:** Move the player  
- **Left Shift:** Temporary speed boost  

### Actions  
- **Space:** Shoot a ball  
- **C:** Change the player color  

### Goal  
Move around, shoot other players, avoid getting hit, and try to get the highest score.

Supports:  
- Host  
- Client  
- Shared mode (Fusion play mode helper)

---

## 🔧 Build  
The playable build is available on itch.io:  
👉 *Insert your itch.io link here after uploading*

---

## 📦 Technologies Used  
- Unity 6000.0.24f1  
- Photon Fusion  
- C#  
- TextMeshPro

---

## 👤 Author  
Liri (Maya)
