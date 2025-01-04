namespace Drag{
using ExternalForce;
using Mass;
using Vector3D;

unsafe class Drag : ExternalForce
{
    private readonly Vector3D windVelocity;
    private readonly float dragFactor;


    //Constructor

    public Drag(Vector3D windVelocity_, float dragFactor_ = .5f, float? start_ = null, float? end_ = null) 
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
        Vector3D relativeVelocity = m.GetVelocity() - windVelocity;
        return -dragFactor*relativeVelocity.Norm()*relativeVelocity;
    }
}
}