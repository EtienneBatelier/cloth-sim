namespace ConstantForce;
using Constraint;
using Mass;
using Vector3D;

class ConstantForce : Constraint
{
    private readonly Vector3D force;

    //Constructor

    public ConstantForce(List<Mass> affectedMasses_, double start_, double end_, Vector3D force_) 
    {
        base.affectedMasses = affectedMasses_;
        base.start = start_;
        base.end = end_;
        force = new Vector3D(force_);
    }


    //Other methods

    public override bool Applies(Mass m, double time) {return true;}
    public override Vector3D Force(Mass m, double time) {return new Vector3D(force);}
    public override void Effect(Mass m) {}
}
