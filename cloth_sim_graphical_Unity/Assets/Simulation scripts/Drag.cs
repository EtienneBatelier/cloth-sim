using UnityEngine;
namespace Drag{
using ExternalForce;
using Mass;
using Vector3D;

unsafe class Drag : ExternalForce
{
    private Vector3* windVelocity;
    private readonly float dragFactor;


    //Constructor

    public Drag(Vector3* windVelocity_, float dragFactor_ = 1f, float? start_ = null, float? end_ = null) 
    {
        windVelocity = windVelocity_;
        dragFactor = dragFactor_;
        base.start = start_; 
        base.end = end_; 
    }


    //Other methods

    public override bool Applies(Mass m, float time) {return base.InTimeInterval(time);}
    public override Vector3D Force(Mass m, float time) 
    {
        Vector3D relativeVelocity = new Vector3D(- (*windVelocity).x, - (*windVelocity).y, - (*windVelocity).z);
        relativeVelocity.Add(m.GetVelocity());
        return -dragFactor*relativeVelocity.Norm()*relativeVelocity;
    }
}
}