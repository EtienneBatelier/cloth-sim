using System.Collections.Generic;
using UnityEngine;

namespace ClothSim{
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
using ClothPieceGraphicalUnity;
using SpringGraphicalUnity;
using ExternalForce;
using Sewer;

public unsafe class ClothSim : MonoBehaviour
{
    PhysicalSystem physicalSystem;
    IntegrationMethod integrationMethod;
    float dt;

    float mass;
    [SerializeField] [Range(0.1f, 10f)] public float dampingCoefficient;
    [SerializeField] [Range(0f, 20f)] public float stiffness;
    [SerializeField] [Range(0.1f, 2f)] public float restLength;
    [SerializeField] public Vector3 windVelocity;
    [SerializeField] public Vector3 gravitationalField;
    [SerializeField] public Vector3 normalToPlane;
    [SerializeField] public Vector2Int dimensions;
    [SerializeField] public string attachingInstructions;


    void UpdateGraphicalPosition(PhysicalSystem physicalSystem)
    {
        foreach (ClothPieceGraphicalUnity clothPiece in physicalSystem.clothPieces) {clothPiece.UpdateGraphicalPosition();}
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
        dimensions = new Vector2Int(10, 20);
        attachingInstructions = "all sides";
                       
        physicalSystem = new PhysicalSystem(new List<ClothPiece>{}, new List<ExternalForce>{});
        integrationMethod = new BackwardEulerMethod();
        dt = 0.07f;
    }

    void Update()
    {
        if (Input.GetKey (KeyCode.Return))
        {
            foreach (ClothPiece clothPiece in physicalSystem.clothPieces)
            {
                foreach (MassGraphicalUnity mass in clothPiece.masses) {mass.DestroySphere();} 
                foreach (SpringGraphicalUnity spring in clothPiece.springs) {spring.DestroyGameObject();} 
            }
            
            fixed (float* massPtr = &mass, dampingCoefficientPtr = &dampingCoefficient, stiffnessPtr = &stiffness, restLengthPtr = &restLength){
            fixed (Vector3* windVelocityPtr = &windVelocity, gravitationalFieldPtr = &gravitationalField){
                (ClothPiece clothPiece, Hook hook) = Sewer.HookedRectangle(dimensions.x, dimensions.y, massPtr, dampingCoefficientPtr, stiffnessPtr, restLengthPtr, new Vector3D(), new Vector3D(normalToPlane.x, normalToPlane.y, normalToPlane.z), attachingInstructions);
                physicalSystem = new PhysicalSystem(new List<ClothPiece>{clothPiece}, new List<ExternalForce>{hook, new Drag(windVelocityPtr), new Gravity(gravitationalFieldPtr)});
                physicalSystem.Initialize();}}
        }
        physicalSystem.Update(integrationMethod, dt);
        UpdateGraphicalPosition(physicalSystem);
    }
}
}