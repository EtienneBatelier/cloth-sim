using System.Collections.Generic;
using UnityEngine;

namespace cloth_sim_graphical_Unity{
using Mass;
using MassGraphicalUnity;
using Vector3D;
using ConstantForce;
using PhysicalSystem;
using Hook;
using NewmarkMethod;
using EulerMethod;
using IntegrationMethod;
using Push;
using Drag;
using ClothPiece;
using ExternalForce;

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
        float radius = .5f;
        List<Mass> masses = new List<Mass>{};
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                masses.Add(new MassGraphicalUnity(0.1f, 0.7f, new Vector3D(i, j, 10), radius));
            }
        }
        ClothPiece clothPiece = new ClothPiece(masses); 
        float dist = 0;
        for (int a = 0; a < clothPiece.masses.Count; a++)
        {
            for (int b = 0; b < clothPiece.masses.Count; b++)
            {
                dist = (clothPiece.masses[a].GetPosition() - clothPiece.masses[b].GetPosition()).SquaredNorm();
                if (0 < dist && dist < 1.1f) {clothPiece.Connect(a, b, 100, 1);}
            }
        }

        Hook hook = new Hook(new List<Mass>{clothPiece.masses[0], clothPiece.masses[19], clothPiece.masses[380], clothPiece.masses[399]});
        //Push push = new Push(new List<Mass>{clothPiece.masses[150]}, new Vector3D(0, 0, 50), 0.0, 0.055);
        Drag wind = new Drag(new Vector3D(0, 2, 0), 0, 22);
        ConstantForce gravity = new ConstantForce(new Vector3D(0, 0, (float) -9.81));

        physicalSystem = new PhysicalSystem(new List<ClothPiece>{clothPiece}, new List<ExternalForce>{hook, wind, gravity});
        intMeth = new NewmarkMethod();
        dt = (float) 0.005;

        physicalSystem.Initialize();
    }

    void Update()
    {
        physicalSystem.Update(intMeth, dt);
        UpdateGraphicalPosition(physicalSystem);
    }
}
}