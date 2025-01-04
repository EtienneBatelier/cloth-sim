Cloth Simulation -- 01.2025


What is in this repository? 

This repository contains two versions of a program that simulates the motion of a rectangular piece of cloth. The first version is purely textual. It is a C# console application that prints out the positions of the particles making up a simulated piece of cloth. The second version uses the Unity engine to provide a real-time, graphical, interactive simulation. 
 
The overlap in code between the two versions is large, which is intended. The graphical, Unity version includes most of the .cs files of the textual versions as scripts. It requires a couple specific additional classes whose code is written in new .cs files. They are exactly those whose names end with "GraphicalUnity". These additional classes are solely dedicated to the graphical, Unity version. They all inherit from a textual counterpart, and only contain as new attributes what is strictly needed to display things on the screen. The Unity project contains a single Scene with a Camera, a GameObject to which the simulation scripts are attached to, as well as some additional GameObjects, scripts and other Unity-specific tools to provide a rudimentary UI to the graphical version of the program. 

The strong separation between the code specific to the graphical, Unity version and the code dedicated to the core of the physical simulation should make it straightforward for the user fluent in another game engine or graphical library to turn the textual version into another graphical version. 


How to run the program? 

The textual version is a C# console application that be built and run using a C# compiler. Pointers are used, which means one is forced to allow "unsafe code" in the compiler options. The class ClothSim contains a Main function in which a (very) small simulation is readily initialized. 

The graphical version takes the form of a Unity project. At it is in the repository, it is fairly incomplete, for a full working Unity project is generally pretty large (several GB). A somewhat severe but widespread .gitignore is used to discard many files that are automatically created upon the generation of a new 3D project in Unity. If the project in the cloth_sim_graphical_Unity folder is opened with Unity Editor 6, the needed redundant files should be created automatically, making it complete. 
The project can then be explored from the Editor, or built and run. It comes with a rudimentary UI, so that it is not necessary to interact with it in the Editor. See more below under "How to interact with the program?".


The simulation.

A rectangular piece of cloth is simulated as a lattice of masses connected by damped springs. The classes Mass and Spring represent these objects in both versions. They have as attributes various physical parameters necessary to compute the acceleration, velocity and position of each of the masses at each simulation step. A List of Masses and a List of Spring make up a ClothPiece. The program also takes into account external forces, in the form of instances of the class ExternalForce. More precisely, the class ExternalForce is virtual, and its sub-classes are Drag, Gravity, Push and Hook. The first implements the drag due to friction between the piece of cloth and the fluid that makes up its environment. The second takes into account an ambient (constant) gravitational field. The third simulates an external agent pushing one or many of the masses making up the piece of cloth for a period of time. The last one, Hook, enables one to immobilize some of the masses to simulate an attached cloth piece. A List of ClothPieces and a List of ExternalForces make up (most of) a PhysicalSystem. A PhysicalSystem contains all the methods needed to couple it with an IntegrationMethod to make the simulation go forward in time, one step at a time. More on the class IntegrationMethod below. 

This simulation was a good occasion to compare different integration methods for the resolution of the second-order differential equations at stake here. Four are included: the classical (forward) Euler method, the explicit Runge-Kutta 4 method, the implicit (backwards) Euler method, and another implicit method known as Newmark's method. The differential equations in the system at stake are so-called stiff, which leaves little chances for the explicit methods to yield satisfactory results without exploding. This was confirmed by experimentation. Thus, the method used by default is an instance of BackwardEuler, which is especially stable. 
Regarding implementation: each of the four methods is a sub-class of the virtual class IntegrationMethod. IntegrationMethod has a virtual method UpdateForceVelocityPosition, which takes as arguments, among other things, a Mass and a List of ExternalForces. The overridden UpdateForceVelocityPosition in each sub-class takes uses its own integration rules to take the Mass passed as an argument a step forward. 


How to interact with the program? 

The textual version has a Main function in the ClothSim class. It can be used to call methods from the TestPrinter static class in which some small examples and test code are readily available. 

The graphical version comes with a simple UI that enables one to interact with the simulation in real time. The keys WASD control the position of the camera. Keeping the right mouse button pressed while moving the mouse around rotates the camera. Below the tag "Parameters" in the top right corners of the screen lie many sliders. They control various parameters of the simulation (e.g, the stiffness of the internal springs making up the piece of cloth, or their rest length, the wind, ...). 
Below the tag "Cloth" are yet another bunch of sliders and UI components. The sliders "Dimensions" control the dimensions of a new rectangular cloth piece to be simulated. The sliders "Normal to Plane" control the entries of a vector that will be normal to the plane in which the new cloth piece will spawn. The input field "Attaching Instructions" can be used to specify how the new piece of cloth shall be attached. In this field, zero, one or more of the following instructions can be combined: "first side", "second side", "third side", "fourth side", "all sides", "first corner", ..., "all corners". Once the dimensions, normal vector and attaching instructions are specified, pressing Enter will spawn the new piece of cloth. For instance, hitting Enter while the Dimensions sliders are set to 10 and 20, the Normal to Plane sliders are set to 1, 0, 0 and the Attaching Instructions are set to "first side, third corners" will spawn a 10x20 rectangular piece of cloth lying in the yz-plane, with its entire first side and third corner immobilized. 


Authorship. 


This program is a personal project, though it is a heavily revisited version of an assignment received while studying at EPFL, Lausanne around 2017. 


Where from here? 

Possible extensions: 
- Coloring the displayed line. The redder, the lager the magnitude of the force of the corresponding spring. 
- Implementing collisions between a piece of cloth and standard objects, like a sphere or a table. 
- Enabling one to create cloth pieces of varying shape rapidly by, e.g, reading a .bmp black-and-white image file that indicates where to put masses and where to leave empty space. 
