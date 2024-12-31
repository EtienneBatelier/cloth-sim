namespace Drag{
using ExternalForce;
using Mass;
using Vector3D;

class Drag : ExternalForce
{
    private readonly Vector3D windVelocity;
    private readonly float dragFactor;


    //Constructor

    public Drag(Vector3D windVelocity_, float dragFactor_ = 0.1f, float? start_ = null, float? end_ = null) 
        {
            windVelocity = new Vector3D(windVelocity_);
            dragFactor = dragFactor_;
            base.start = start_; 
            base.end = end_; 
        }


    //Other methods

    public override bool Applies(Mass m, float time) {return base.InTimeInterval(time);}
    public override Vector3D Force(Mass m, float time) {return -dragFactor*m.GetVelocity().Norm()*(m.GetVelocity() - windVelocity);}
}
}