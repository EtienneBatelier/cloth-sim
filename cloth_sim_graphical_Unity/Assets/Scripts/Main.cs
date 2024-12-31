using System.Collections.Generic;
using UnityEngine;

namespace cloth_sim_graphical_Unity{
using Mass;
using MassGraphicalUnity;
using Vector3D;
using Gravity;
using PhysicalSystem;
using Hook;
using IntegrationMethod;
using NewmarkMethod;
using EulerMethod;
using RungeKuttaMethod;
using BackwardEulerMethod;
using Push;
using Drag;
using ClothPiece;
using ExternalForce;
using Sewer;

public class Main : MonoBehaviour
{
    PhysicalSystem physicalSystem;
    IntegrationMethod intMeth;
    float dt;

    void UpdateGraphicalPosition(ClothPiece clothPiece)
    {
        foreach (MassGraphicalUnity mass in clothPiece.masses) {mass.UpdateGraphicalPosition();}
    }

    void UpdateGraphicalPosition(PhysicalSystem physicalSystem)
    {
        foreach (ClothPiece clothPiece in physicalSystem.clothPieces) {UpdateGraphicalPosition(clothPiece);}
    }

    void Start()
    {
        //Push push = new Push(new List<Mass>{clothPiece.masses[150]}, new Vector3D(0, 0, 50), 0.0, 0.055);
        Drag wind = new Drag(new Vector3D(0, 3, 0), 1f, 5, 10);
        Drag ambientAir = new Drag(new Vector3D(0, 0, 0), 1f);
        Gravity gravity = new Gravity(new Vector3D(0, 0, (float) -1f));

        List<string> hookTypes = new List<string>{"firstSide", "thirdCorner"};
        (ClothPiece clothPiece, Hook hook) = Sewer.HookedRectangle(10, 15, new Vector3D(0, 0, 5), new Vector3D(1, 1, 7), hookTypes);

        physicalSystem = new PhysicalSystem(new List<ClothPiece>{clothPiece}, new List<ExternalForce>{hook, ambientAir, wind, gravity});
        intMeth = new BackwardEulerMethod();
        dt = (float) 0.1;

        physicalSystem.Initialize();
    }

    void Update()
    {
        physicalSystem.Update(intMeth, dt);
        UpdateGraphicalPosition(physicalSystem);
    }
}
}