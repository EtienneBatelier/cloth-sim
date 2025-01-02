using System.Collections.Generic;
using UnityEngine;

namespace cloth_sim{
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

public unsafe class cloth_sim : MonoBehaviour
{
    PhysicalSystem physicalSystem;
    IntegrationMethod integrationMethod;
    float dt;

    [SerializeField] [Range(1f, 10f)] float mass;
    [SerializeField] [Range(0f, 10f)] float dampingCoefficient;
    [SerializeField] [Range(1f, 20f)] float stiffness;
    [SerializeField] [Range(0f, 2f)] float restLength;
    [SerializeField] Vector3 windVelocity;
    [SerializeField] Vector3 gravitationalField;
    [SerializeField] Vector3 normalToPlane;
    [SerializeField] Vector2Int dimensions;
    [SerializeField] string attachingInstructions;


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
        mass = 1;
        dampingCoefficient = .5f; 
        stiffness = 10;
        restLength = 1;
        windVelocity = new Vector3(0, 0, 0);
        gravitationalField = new Vector3(0, 0, -1);
        normalToPlane = new Vector3(0, 0, 1);
                       
        List<ClothPiece> clothPieces = new List<ClothPiece>{};
        List<ExternalForce> externalForces = new List<ExternalForce>{};
        physicalSystem = new PhysicalSystem(clothPieces, externalForces);
        integrationMethod = new BackwardEulerMethod();
        dt = 0.07f;
    }

    void Update()
    {
        if (Input.GetKey (KeyCode.C))
        {
            foreach (ClothPiece clothPiece_ in physicalSystem.clothPieces)
            {
                foreach (MassGraphicalUnity m in clothPiece_.masses)
                {
                    m.DestroySphere();
                } 
            }
            fixed (float* massPtr = &mass, dampingCoefficientPtr = &dampingCoefficient, stiffnessPtr = &stiffness, restLengthPtr = &restLength){
            fixed (Vector3* windVelocityPtr = &windVelocity, gravitationalFieldPtr = &gravitationalField){
                (ClothPiece clothPiece, Hook hook) = Sewer.HookedRectangle(dimensions.x, dimensions.y, massPtr, dampingCoefficientPtr, stiffnessPtr, restLengthPtr, new Vector3D(), new Vector3D(normalToPlane.x, normalToPlane.y, normalToPlane.z));
                Drag wind = new Drag(windVelocityPtr);
                Gravity gravity = new Gravity(gravitationalFieldPtr);
                physicalSystem = new PhysicalSystem(new List<ClothPiece>{clothPiece}, new List<ExternalForce>{hook, wind, gravity});
                physicalSystem.Initialize();
            }
            }
        }
        physicalSystem.Update(integrationMethod, dt);
        UpdateGraphicalPosition(physicalSystem);
    }
}
}