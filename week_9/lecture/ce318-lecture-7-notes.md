# CE318 Lecture 7: Persistence & Animations

## Introduction

All lab presentations are due on the 13th, also present your game (worth 10%)

## Persistence

### PlayerPrefs

PlayerPrefs is the easiest way to load and save data

PlayerPrefs is essentially a hasp map that allows a programmer to store and retrieve values, and is not closed or deleted when the scene is closed

PlayerPrefs is dependent on the operating system _the application_ is running on

PlayerPrefs writes to the disk and is not secure as it is plain text stored on the file system

Good with small amounts of data, not good with large amounts of data

### DontDestroyOnLOad

It is better to save data to an object, and DontDestroyOnLoad will stop the specified game objects from being deleted from scene to scene

    public class DontDestroy : MonoBehaviour
    {
        void Awake()
        {
            DontDestoryOnLoad(gameObject);
        }
    }

Singletons approach:

    // Accessible from any script
    public class GameControl : MonoBehaviour
    {
        public static GameControl control;
        public int health;

        void Awake()
        {
            if (control == null)
            {
                DontDestroyOnLoad(gameObject);
                control this;
            }
            else if (control != this)
            {
                Destroy(gameObject);
            }
        }
    }

### Saving to a File

This is a way to save data between application executions

Serialization is the process on converting an object to a stream of bytes to be able to store the object in memory, a database or a file

Objects that will be serializable should be marked _[Serializable]_

    [Serializable]
    class PlayerData
    {
        public float health;
    }

## Finite State Machines, Animations and Animators Transitions

Finite State Machines (FSMs) are mathematical models that display an abstract machine that can be in one of a finite number of states

Moving from one state to another is called a transition, and is caused a trigger or event

States are linked to each other via transitions and each corresponds to an action or behaviour

Logic for FSMs:

- Flexible: Uses classes and interfaces for its components
- Hard-coded: All logic is defined in code

Advantages of FSMs:

- Simple to implement
- East to visualise

Disadvantages of FSMs:

- Scale poorly for complex logic
- Are not designed to deal with concurrency (multiple states at once)

### Exercise

Think about and create a FSM for the game Pac-man

## Unity Animation System

### Mecanim

Mecanim is the Unity Animation System, and it can be used to setup animation on a character of a particular build (i.e., humanoid), and define transit animations, and apply animations

This can access other parts of a game (i.e., scripts)

[List of mecanim terms](http://docs.unity3d.com/Manual/AnimationGlossary.html)

### Animation Clips

These are always part of an Animator

The Animator has the different states available for animation and allows a user to animate properties of game objects

The Controller property of Animator is a reference to an Animator Controlller asset

The Avatar property of Animator is a skeleton object that binds the model to be animated to the animator

The Animation Controller should store all the different states of a character, and defines how the blending between the animators are done

There are three special types of states:

- Entry (green): The entry point of the state machine
- Default (orange): The state 
- Any (blue): Used to represent transitions that must happen from any state

Animation states have certain properties:

- Name / Tag: Are specified for a particular state
- Speed: Normal speed is 1, Half is 0.5, Double is 2
- Motion: The animation clip or blend tree that will be played for that state
- Foot IK (Foot Inverse Kinematics): If you have uneven surfaces in the game, it will move the character so that there motion looks more realistic
- Mirror: Flips the animation from left to right

Only one transition can be active at any given time in the state machine

#### Animation Parameters

These are variables that are defined within the animation system and can be accessed and assigned values from scripts

There are four possible parameter types:

- Integer
- Float
- Bool
- Trigger: A boolean parameter that is reset by the controller when consumed by a transition

#### Sub-state Machines

Common for more complex actions that consist of a number of stages

Usually used when there is a large amount of animations and a programmer wants to group them

Standing -> Grab
Standing -> Attack

Crouching -> Grab
Standing -> Attack

## Blend Trees

A blend tree allows a smooth blending (transitions) when you have similar types of animations (i.e., turning left → turning right)

Good example would be walking and running animations

1D Blend Trees blend between motions using one parameter

- Run
- RunLeft
- RunRight

2D Blend Trees blend between motions using two parameters

- Idle
- Walk forward
- Walk back
- Walk strafe left
- Walk strafe right

Avatars are definition systems that tell the animation system how to animate the transforms of a model

Animation layers are used for managing complex state machines, to animate specific parts of the body

Animator controller layer parameters:

- Name: Layer name
- Weight: How much the layer affects the final animation (0: no affect, 1: full priority)
- Mask: Avatar mask used to isolate body parts for animation
- Blending:

    - Override: 
    - Additive: 

A Body Mask can be used to disable or enable different body parts in an animation

## Blending Animations

## Animation Scripting
