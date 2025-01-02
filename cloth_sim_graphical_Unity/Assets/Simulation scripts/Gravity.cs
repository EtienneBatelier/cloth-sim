using UnityEngine;
namespace Gravity{
using ExternalForce;
using Mass;
using Vector3D;

unsafe class Gravity : ExternalForce
{
    private Vector3* gravitationalField;


    //Constructor

    public Gravity(Vector3* gravitationalField_, float? start_ = null, float? end_ = null) 
    {
        gravitationalField = gravitationalField_;
        base.start = start_;
        base.end = end_;
    }


    //Other methods

    public override bool Applies(Mass m, float time) {return base.InTimeInterval(time);}
    public override Vector3D Force(Mass m, float time) 
    {
        return new Vector3D(m.GetMass()*(*gravitationalField).x, m.GetMass()*(*gravitationalField).y, m.GetMass()*(*gravitationalField).z);
    }
}
}