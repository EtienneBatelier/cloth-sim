namespace Gravity;
using Constraint;
using Mass;
using Vector3D;

class Gravity : Constraint
{
    public override bool Applies(Mass m, double time) {return true;}
    public override Vector3D Force(Mass m, double time) {return new Vector3D(0, 0, -9.81);}
    public override void Effect(Mass m) {}
}
