# GLIMMER - Web-Based Walking Simulator

**GLIMMER** is a Unity-based walking simulator designed for web browsers on desktops, providing an immersive exploration experience in a rich virtual environment. The game features mechanics such as boundary-based object interactions, dissolving shaders, collectibles, and customizable UI elements.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
  - [Boundary-Based Dissolve](#boundary-based-dissolve)
  - [Collectibles System](#collectibles-system)
  - [Dynamic Lighting](#dynamic-lighting)
  - [UI and HUD](#ui-and-hud)
  - [WebGL Integration](#webgl-integration)
- [Setup and Installation](#setup-and-installation)
  - [Unity Version](#unity-version)
  - [Required Packages](#required-packages)
- [Code Structure](#code-structure)
  - [Scripts Overview](#scripts-overview)
  - [Key Script Functionality](#key-script-functionality)
- [How to Play](#how-to-play)
- [License](#license)

---

## Project Overview

GLIMMER is a minimalist walking simulator, with an emphasis on exploration and interaction in a serene virtual environment. The player navigates through a series of landscapes, triggering visual and auditory effects, while collecting and interacting with various objects.

---

## Features

### Boundary-Based Dissolve

- **Dissolve effects** are triggered based on the player’s proximity to objects. This effect gradually reveals or hides boundaries when the player approaches or moves away from certain objects.
- Implemented using shaders to create a fade-in/out effect.

### Collectibles System

- A variety of **collectibles**, including text-based notes, images, sounds, and videos, can be interacted with.
- Each collectible has its own traits and status tracking, allowing players to collect and unlock them in a sequence.

### Dynamic Lighting

- The game's **lighting system** dynamically adjusts based on the player's distance from key objects, such as light sources. This adds to the atmospheric feel of the environment.

### UI and HUD

- **User Interface (UI)** includes:
  - Dynamic panels that appear when interacting with objects.
  - Inventory and map systems, allowing players to track collected items and explore the environment more effectively.
- **HUD elements** such as crosshair and minimap enhance the gameplay experience.

### WebGL Integration

- GLIMMER is optimized for **WebGL**, allowing it to be played directly in web browsers.
- Integrated with WebGL-specific video players for smooth multimedia content display during gameplay.

---

## Setup and Installation

### Unity Version

Ensure you are using **Unity 2021.3 LTS** or higher for compatibility with WebGL and the project features.

### Required Packages

Install the following packages via Unity's Package Manager:
- **URP (Universal Render Pipeline)** for graphics and shaders.
- **LeanTween** for smooth UI transitions and animations.
- **TextMeshPro** for high-quality text rendering.
  
---

## Code Structure

The project is structured into several main components:

### Scripts Overview

- **Boundary Interactions**: Handles player-object boundary interactions using triggers.
- **Collectibles System**: Abstract base classes and subclasses for different types of collectibles (text, image, sound, etc.).
- **UI Controllers**: Manages the display of information and interactions within the game’s user interface.
- **WebGL Video Players**: Ensures video content works seamlessly on WebGL platforms.
  
### Key Script Functionality

1. **Boundary Trigger (`boundaryTrigger.cs`)**  
   - Triggers object dissolution when the player crosses specific boundaries. Uses coroutines to start and stop dissolve effects dynamically.

2. **Dissolve Controller (`dissolveController.cs`)**  
   - Implements smooth dissolve transitions on objects based on the player's proximity using shaders.

3. **Grid Controller (`GridController.cs`)**  
   - Controls the appearance and transparency of objects within the game’s grid system based on player distance.

4. **Collectibles (`Scripts/Collectibles/Collectible.cs`)**  
   - Base class for various collectible items such as text, images, videos, and sounds. Each collectible has specific methods for interaction and tracking progress.

5. **Dynamic Lighting (`LightDistance.cs`)**  
   - Adjusts light intensity based on the distance between the player and the light source.

6. **UI Panels and Interaction (`UI/DialogBox.cs`, `UI/NodePanel.cs`, `UI/ImagePanel.cs`)**  
   - Handles the opening and closing of various in-game panels and the UI's response to player inputs.

7. **WebGL Video Support (`WebGLVideoPlayer.cs`)**  
   - Ensures videos are correctly loaded and played in a WebGL environment.

---

## How to Play

1. **Movement**: Use standard **WASD** keys to move through the environment.
2. **Interaction**: Hover over objects and use the mouse to interact with them when prompted. Collect items and explore the environment for clues.
3. **Inventory and Map**: Use the map and inventory system to track your progress through the game world.
4. **Collectibles**: Look for hidden collectibles and interact with them to unlock further areas or information.

---

## License

This project is open-source and available under the **MIT License**. Feel free to modify and use it for your own projects.
