# CE318 Lecture 8: Navigation & AI

## Steering Behaviours for Autonomous Characters

Characters should move around the environment naturally and in a way that makes sense

Steering behaviours are based on apply simple forces to a character to produce life-like (improvisational) navigation around an environment

They are concerned with things local to them (i.e., a neighbour's forces), rather than complex path planning systems

Common steering behaviours (Code provided in lecture slides):

- Seek: Game object will attempt to match the position (coordinates) of the target, (this is different from attractive force, i.e., gravity, that would produce an orbital path around the target)

    - Vampire survivors
    - 20MTD

    // Seek code
    // Applying the force code
- Flee: Game object will attempt to get as far as possible from the position of the target (opposite of Seek)

    - Pac-man

    // Flee code
- Arrival: Game object will attempt to match the position (coordinates) of the target but slows down when approaching target (similar to Seek), there should be defined area around the target, or areas, that the game object will begin slowing down at

    - Any game where an NPC needs to "Follow You"
- Wander:

    - NPCS
    - Skyrim
    - Zelda
    - Neutral Animals
- Pursuit: Like seek but, the target is moving, used a linear vector-based that assumes target will not turn

    - Pong
- Evade: Like flee but the target the game object is fleeing from is moving

    - ??

## Navigation Meshes in Unity

Walls, environment objects, etc. can get in the way of the walkable path

A graph is needed to build a graph that describes the level

A Navigation Mesh (NavMesh) is a data structure that is used to model the traversable areas of a virtual map

NavMesh is a collection of 2D convex polygons (usually triangles) that define areas of the virtual map that are traversable by agents

Each polygon acts as a single node that links to other adjacent nodes

Polygons are convex which means that any point from inside the polygon can be reached in a straight line from any other point inside the same polygon

Advantages

- Creates shorter and more natural paths than traditional grid and waypoint-based pathfinding systems
- Allows pathfinding algorithms to ignore static and dynamic obstacles
- Many pathfinding algorithms can be modified and optimised for using navigation meshes

Disadvantages

- ?

NavMesh vs. Grid/Waypoint-based Pathfinding...

## Navigation in Unity

Navigation System...
NavMesh Setup + NavMesh Links...

Baking is the process of setting up the NavMesh into a game

Unity needs to know what objects are navigation static to bake a NavMesh

Navigation static objects won't move (floors, walls, rocks) and can be used to calculate the navigable areas.

Off-mesh links can be used to create additional paths

Water should be non-navigable

The navigation layer defines the in-built or custom layer for a mesh and can be Walkable (default), Not Walkable or Jump (Off-mesh links)

NavMesh areas are used to defined different surfaces that might have different associated costs (i.e. mud, sand, water, ice)

NavMesh Agent is a component with a radius and height, and is represented by a cylinder

The Agent will try to keep _radius_ distance away from surrounding objects (based on its center) and cannot pass under ceilings lower than its defined _height_

Agents are able to query paths to the NavMesh

Agents will avoid fixed obstacles in the scene as well as other agents

Obstacle Avoidance Type defines how accurate the avoidance should be

Avoidance Priority defines how the agents will behave when it encounters another agent

- Agents with a larger priority number will avoid
- Agents with a lower priority number will follow its normal path

To create an agent, a game object should have the NavMesh Agent component

NavMesh agent properties

- Radius: Area around the agent within which objects should not pass
- Height: Height clearance the agent needs overhead
- Base offset: ...
- Speed: ...
- Angular speed: ...
- Acceleration: ...
- Stopping distance: ...
- Auto braking: ...

Scripting a NavMesh agent

    // Retrieve the nav mesh agent component
    NavMeshAgent agent = GetComponent<NavMeshAgent>();
    // Set a path for the agent
    agent.SetDestination(targe.position);

NavMesh agents also have functions to:

- Calculate and store a path to a point (CalculatePath)
- Assign a new path for this agent (SetPath)
- Trace a straight path towards a target position in the NavMesh without moving the agent (Raycast)
- Stop the movement along the current path (Stop)
- Resume the movement along the current path (Resume)
- Get the coset for crossing ground of a particular type (GetLayerCost)

NavMesh obstacle is a movable object that must be avoided by a NavMesh agent (i.e., movable walls, doors that can be opened)

To denote that a game object is a NavMesh obstacle, a NavMesh obstacle should be added to it

A NavMesh obstacle needs to have a defined _Radius_ and _Height_

## Decision Making

Simple systems are cheap, faster to greater and are less prone to bugs

Complex systems give designers a lot of control but are very time-consuming to create and game objects can get _stuck_ if a player does something not expected or not tested for

A behaviour tree is a mathematical model that contains all the transitions? for changing between one state and the other

### Finite State Machine

State machines can also be used for changing states

Finite State Machines (FSM) consist of:

- An initial state
- A (finite) set of states
- A (finite) amount of transitions that define how a game object should move between on state to another

Adding more states can possible double the amount of transitions you have, in the event that all states could possibly to transition to a new state

FSM do not scale very well

FSM components:

- Transition: Labels to the transitions that can be triggered (enum)
- StateID: IDs of the states of the FSM (enum)
- FSMState: Stores transition-state pairs that indicate the relationships between origin and destination states, as well as the transition that links them

Hierarchical State Machines (HSM) group states into higher level states:

- There is a high-level starting state
- Each high-level start has a starting state
- Transitions happen normally within each high-level state
- Low-level states can trigger transfers to another high-level state

### Behaviour Trees

A _Task_ is an activity that returns a value

- Simplest case: Returns success or failure
- Also can return a more complex outcome (enum, range)

Tasks should be broken down into smaller complete (independent actions)

Behaviour trees have 3 types of nodes:

- Conditions: Test a property of the game (has 40+ health, player is nearby)
- Actions: Alter the state of the game (break down door, heal player)
- Composites: Collections of child tasks (conditions, actions, composites)

Composite tasks can be divided into two types:

- Selector: Returns success as soon as one child behaviour succeeds
- Sequence: Returns success only if all child behaviours succeed

...

## Quiz

Which steering behaviour should be used to head towards a predicted position of a moving targe

1. Seek
2. Evade
3. **Pursuit**
4. Arrival

What is a waypoint in Unity?

1. Steering behaviour
2. **One of the reference points for a particular path**
3. NavMesh 