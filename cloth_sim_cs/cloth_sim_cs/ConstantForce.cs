namespace ConstantForce;
using ExternalForce;
using Mass;
using Vector3D;

class ConstantForce : ExternalForce
{
    private readonly Vector3D force;


    //Constructor

    public ConstantForce(Vector3D force_, double? start_ = null, double? end_ = null) 
    {
        force = new Vector3D(force_);
        base.start = start_;
        base.end = end_;
    }


    //Other methods

    public override bool Applies(Mass m, double time) {return base.InTimeInterval(time);}
    public override Vector3D Force(Mass m, double time) {return new Vector3D(force);}
}
