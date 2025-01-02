namespace Gravity{
using ExternalForce;
using Mass;
using Vector3D;

class Gravity : ExternalForce
{
    private readonly Vector3D gravitationalField;


    //Constructor

    public Gravity(Vector3D gravitationalField_, float? start_ = null, float? end_ = null) 
    {
        gravitationalField = new Vector3D(gravitationalField_);
        base.start = start_;
        base.end = end_;
    }


    //Other methods

    public override bool Applies(Mass m, float time) {return base.InTimeInterval(time);}
    public override Vector3D Force(Mass m, float time) {return m.GetMass()*gravitationalField;}
}
}