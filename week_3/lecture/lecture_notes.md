# CE318 Lecture 1 Notes

## Lectures

### Topics

- Creating 3D games in Unity 3D
- Using the Unity 3D editor
- 2D and 3D mathematical concepts
- Managing player input
- 3D animations
- Cameras and Navigation
- Graphical User Interfaces
- Lights and Audio
- Particle System
- Terrains
- Game design

## Labs and Assessments

- Make sure to use **Unity 3D 2022.3.8f1** when doing work for the labs
- All assignments are individual only
- Anything outside the module content should be referenced
- This module is coursework only and has _no exam_
- Free assets can be used for all assignments and labs and should be referenced
  appropriately (see assignment brief instructions) **paid assets cannot be
used**
- You can make your own assets

### Lab Assignments

- Worth 10% of the total module grade
- Released bi-weekly
- 4 lab exercises (assuming 2.5% each)

### Progress Test 1

- Worth 15% of the total module grade

### Progress Test 2

- Worth 15% of the total module grade

### Assignment Part 1

- Worth 20% of the total module grade
- Due 10/11/23 at 13:59:59
- A game prototype
- A game design document
- Minimal functionality
- You can make your own assets
- Due to Faser's upload size limit, the project should be uploaded to OneDrive
and a link to that directory should be uploaded to Faser

### Assignment Part 2

- Worth 40% of the total module grade
- Due at 15/12/23 at 13:59:59
- Fully developed game
- Final Report
- Case study **MSc students only**

## Self-study

### Recommended Books

- "Learning C# by Developing Games with Unity 2021 (2021)" by _Harrison Ferrone_
- "3D Game Development with Unity (2022)" by _Franz Lanzinger_
- "AI for Games (2019)" by _Ian Millington_

## Unity Scripting

- Code in scripts should be separated by functionality (1 script = 1
functionality)

### Event Functions

#### Initialisation

- Awake(): Initialises any variables or game state before the game starts and is
only called once during the lifetime of the script instance
- Start(): Called at the start of the scene, only once, and requires the script
to be enabled

#### Regular Update

- Update(): Called once per frame
- FixedUpdate(): Called when working with physics (i.e., Rigidbody)
- LateUpdate(): Runs after all other updates in the current  

#### GUI Updates

- OnGUI(): For rendering and handling GUI events
- OnMouseDown(), OnMouseEnter(), OnMouseOver(): For mouse events on related to
GUI components

#### Physics Updates

- OnCollisionEnter(), OnCollisionStay(), OnCollisionExit()
- OnTriggerEnter, OnTriggerStay, OnTriggerExit(): Triggers are better for none
visual events (i.e., passing point or finish line)

### Retrieving Game Objects

- GameObjectFind(string name)
  - Uses name defined in editor
  - Is slow, not recommended to run every frame
  - Returns null if object does not exist
- GameObjectFindWithTag(string name)
  - Uses tag defined in editor
  - Returns null if no matching objects does not exist
  - Throws _UnityException_ if the name is not defined as a tag 
- GameObject[] FindGameObjectsWithTag(string tag)
  - Uses tag defined in editor
  - Returns an empty array if no matching objects exist
  - Throws _UnityException_ if the name is not defined as a tag

### Destroying Game Objects

- Can be used to remove components from specific game objecs
- Destroy marks objects to be destroyed and all marked objects are destroyed at
the end of the frame

### Activating and Deactivating Game Objects

- SetActive(bool): For game objects
- .enabled = bool: For components
- Deactivated game objects / components are not updates

## Introduction to C#

### Namespaces

- Used to organise code in logical groups and create a hierarchical
organisation of your code
- Namespaces are used like packages and can be imported
- The **using** directive can be used to import a namespace in order to access its
methods and variables
- Namespaces contain other namespaces

## Values and References

- Value types: bool, byte, char, double, float, int, etc.
  - Holds a data value with its own memory
- Reference types: string, arrays, classes, etc.
  - Stores the address in memory where the value is stored

### Enumerations

- enumerations are user defined values for representing a list of **named
integer constants**
- enumerations should be defined in a class, structure or namespace
- enumerations can improve readability, maintainability and complexity