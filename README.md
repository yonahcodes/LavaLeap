# Lava Leap - 2D Platformer Game

## Description
This project was developed as part of an **Introduction to Video Game Programming** course. The game is a platformer created using `Unity`, integrating class concepts such as character animations, keyboard controls, platform design with `2DSpriteShape`, and interactive objects animated using the `Timeline`.

## Key Features

### Environment
- Platforms designed using `2DSpriteShape` for dynamic and visually appealing level design.
- Interactive objects (`accessories`) with unique animations and behaviors.

### Camera
- A dynamic camera that follows the character while staying within the game boundaries.

### Character: RobotBoy
- **Controls**:
  - **Movement**:
    - Use the arrow keys (`←`, `→`) to move left and right.
    - Press `W` to jump.
  - **Roll**:
    - Press the `X` key to perform a roll animation.
  - **Crouch**:
    - Press `S` to crouch, reducing the character's movement speed by half.
    - Release `S` to return to normal movement speed.
  - **Double Jump**:
    - Jump a second time while airborne (limited to two consecutive jumps).

- **Behavior**:
  - Background music plays when the character is present in the scene.

### Interactive Accessories
- **Bonus Accessories**:
  - Increase the number of lives by 1, with a configurable maximum.
- **Malus Accessories**:
  - Decrease the number of lives by 1. The character dies if lives reach zero.
- **Mortem Accessories**:
  - Trigger a death animation and replace the background music with a death theme. The game restarts after a set duration.

### Animations for Accessories
- Accessories are animated using the `Timeline` and include:
  - Two single-Timeline animations.
  - One animation combining two Timelines.
  - Animations using interpolation, frame-by-frame, particles, and sound effects.

### Interface
- **Start Screen**:
  - Features a graphical start screen with background music. The game starts upon clicking a button.
- **Lives Display**:
  - Displays the character's remaining lives using visual icons that reflect the character's current state.

## Requirements
- **Unity Version**: `LTS 2022.3.40f1`
- Free or personally created assets (no copyrighted media).

## How to Play
- Clone the repository:

  ```bash
  git clone https://github.com/yourusername/your-repository.git
  ```
