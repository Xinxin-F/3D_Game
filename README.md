# 3D Boss Fight Game

## Overview
The player must utilise various skills and strategies to defeat the boss within two minutes. 

## Gameplay Instructions
- **Movement:** Right mouse button clicks on the map to move the hero to the movement indicator. 
- **Attacks:**
  - **Primary Attack:** Left mouse short click to release most skills. 
  - **Switch Skills:** Number keys `1`, `2`, `3`, `4` to switch between skills.
- **Rotate Camera:**
  - Press and hold `Q` and to rotate camera clockwise around the map. 
  - Press and hold `E` for counterclockwise.

## Installation
- You may download `3D_Game.exe` file to have a go.
- Target Platform: Windows


## Skills Implemented so far
Level indicates the implementation difficulty of a skill. \
Interaction Method for level 1 to 4: Left mouse short click to release skills. 


### Level 1
- **Shoot Straight Bullet**  
  Shoot a bullet straight based on the mouse direction.
  
### Level 2
- **Shoot Bullet in Parabolic Shape**  
  Shoot a bullet in a parabolic trajectory based on the mouse direction.
  
- **Heal**  
  This skill replenishes certain health points.

### Level 3
- **Area Attack**  
  Fire area attack around the target.

- **Rain Attack**  
  Rain area attack around the target.

- **Grenade**  
  - Throw a grenade in a parabolic trajectory.
  - Upon colliding with any object, the grenade will detonate after a 3-second delay.
  - This causes damage to targets within its attack range.

### Level 4
- **Mini-Player**  
  - The player shoots a Mini-Player in a parabolic trajectory.
  - Upon colliding with the ground, the Mini-Player will attach itself and continuously fire small bullets towards the target position at 3-second intervals.
  - After a set duration, the Mini-Player will self-destruct.
  - This skill allows the Mini-Player to attack targets at any distance on the map.

### Level 5
- **Elemental Reaction**  
  - The Fire and Ice elemental bullets will alter the target's elemental state based on the amount of fire and ice bullets it receives.
  - This skill does not directly cause health damage to the target but instead modifies its elemental properties.\
  **Interaction Method:**
    - Left Mouse Button Short press -- Release Fire Ball Bullet
    - Left Mouse Button Long Press -- Release Ice Ball Bullet

  **Elemental Reaction skill implemented in Training Ground Scene:**

https://github.com/Xinxin-F/3D_Game/assets/127718380/c8902525-1662-441a-a70b-20def8360c4e



## Screenshots of Game Scenes (archived in June 8, 2024)
**Game Scene:**

<img width="700" alt="Screenshot 2024-06-08 at 10 55 37" src="https://github.com/Xinxin-F/3D_Game/assets/127718380/5276851a-5aa6-4ead-933e-51ee7412d6a9">


**Training Scene:**

<img width="700" alt="Screenshot 2024-06-08 at 10 54 24" src="https://github.com/Xinxin-F/3D_Game/assets/127718380/2730eddc-f252-4ece-965e-9b91705424d4">


## Development
- **Technology:** Unity 3D, C#
- **Unity Version**: 2021.3.23f1
- **AI Tools:** ChatGPT, AI Tool (Game Dev Bot) developed by the Research Team of Dr. Hai-Ning Liang.


## Acknowledgments
Developed by Xinxin Fan for the Completion of CPT306 Principles of Computer Games Design Assignment 4 for 2023/2024 Term 2.


