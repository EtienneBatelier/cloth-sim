namespace Drag;
using ExternalForce;
using Mass;
using Vector3D;

class Drag : ExternalForce
{
    private readonly Vector3D windVelocity;


    //Constructor

    public Drag(Vector3D windVelocity_, double? start_ = null, double? end_ = null) 
        {
            start = start_; 
            end = end_; 
            windVelocity = new Vector3D(windVelocity_);
        }


    //Other methods

    public override bool Applies(Mass m, double time) {return base.InTimeInterval(time);}
    public override Vector3D Force(Mass m, double time) {return -m.GetPenetrationCoef()*(m.GetVelocity() - windVelocity);}
}