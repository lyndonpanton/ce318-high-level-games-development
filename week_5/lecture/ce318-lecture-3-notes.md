# CE318 Lecture 3 Notes

## Course Information

- Lab Assignment Part 1 of 4 will be graded on Wednesday in the labs
- Then work for the next lab for Lab Assignment Part 2 will begin



## Models

There are some basic meshes in Unity: Cube, Sphere, Cylinder, Capsule, Plane,
Quad

A mesh is a collection of 3D points (vertices)
Vertices are combined to form triangle

Models can be used for more complex meshes
There are two types of model formats:
- Exported 3D formats: FBX, OBJ
- Proprietary 3D formats: .max, .blend

A material is like the skin of a mesh and every mesh requires a material to be
seen

Model materials have two twos:
- Textures: A drawing applied to the "skin" of a model
- Shaders: How to model will react to lighting

One of the basic parameters for materials is a texture

New materials can be created and have textures assigned to them

The albedo property of a material is the base colour if no lighting is applied
to a game object

The standard Unity shader has multiple rendering modes:
- Opaque (default)
- Cutout: The alpha channel of the diffuse image that is used to cut out parts
of the texture
- Fade: 
- Transparent: 

The standard Unity shader has multiple main maps:
- Albedo: 
- Metallic:
- Normal map: 
- Height map: 
- Occulusion
- Emission: 
- Tiling: 
- Offset: 

Also shaders have secondary maps for defining additional surface details, draw

## Physics

Using Sleep or Disabling a game object is useful for when you no longer want to
calculate physics for a game object

Static colliders should be used for game objects that do not move or move
occasionally (i.e., doors, moving platforms)

Mesh Colliders are a lot computationally expensive then other colliders and so
should be used sparingly

Terrains colliders are used for terrains in a specific game (lecture 5 is
dedicated to this)

There is a _Wheel collider_ specifically for wheel-like objects (wheels, yo-yos,
plate?)

It is recommended to use forces to move physics objects

There are linear forces (force) and rotational forces (torque)

Forces can be applied to specific points of a game object

Forces should be update in FixedUpdate

The drag property of Rigidbody can be used to dampen forces

NOTE: When using explosions, it is good to apply forces in multiple frames to get
a better visual effect (instead of a single frame)

{ Torque notes }

Force Modes:
- Force: Continuous changes are affected by mass
- Acceleration: Add a continuous acceleration to the Rigidbody, ignoring its
mass
- Impulse: Add an instant force, using the mass (force is applied all at once) 
- VelocityChange: Add an instant force, ignoring the game object's mass

Physics materials can be used to adjust friction and boucing effects between
game objects and is applied to colliders

There are two different types of friction for physics materials:
- Dynamic friction: Friction used when already moving (0 - 1)  
- Static friction: Friction used when an object is still on a surface (0 - 1)

### Physics Best Practices

Assign objects to different layers and disable collisions that are not supposed
to happen between layers in the collision matrix (Edit -> Project Setting -> 
Physics)

Ray Casting can be expensive:
- Use the least amount of rays as possible
- Set a distance limit (when possible)
- Do not use Raycasts in FixedUpdate
- Complex colliders (i.e., mesh colliders) are expensive when raycasting with
them
- Specify a layer mask to limit the number of collisions a raycast checks
- A more efficient way of specifying a layer mask is with bit operators:
  if you want a ray to hit an object which is on layer which id is 10,
  what you should specify is layerMask = 1  10. If you want for
  the ray to hit everything except what is on layer 10 then simply use
  the bitwise complement operator (∼) which reverses each bit on the
  the bitmask 

### Joint Examples

Joints apply forces that move Rigidbodies, and can also restrict movement

Fixed: Sticks objects together permanently or temporarily
- Magnet
- Pick up objects


Spring: Acts like a piece of elastic the pulls anchor points together to the
same position
- Elastic band
- 

Hinge
- Grappling Hook
- Spider-man

Character
- 

Configurable
- Vehicle building game


## Raycasting

RaycastHit is a struct that can be used to get information about what point was
hit and game objects occupy that area

LayerMasks can be used to only Raycast something on or not on a specific layout

## CharacterController

This is a special component, used on occasions you do not necessarily want
characters to react to physics as normal (i.e., do not react to forces, do not
apply forces to other rigidbodies)

CharacterController automatically includes a Capsule Collider, in order to
react to collisions that are desired

This includes functions such as:
- isGrounded: Whether the controller is touching the ground on the current frame
- Velocity: The current velocity of the controller
- CharacterController.OnControllerColliderHit: Called when colliding with
another collider, if the current game object is performing a Move()

This has a _skin width_ property, which gives the character extra space
This can be used to avoid characters getting stuck between objects, etc.