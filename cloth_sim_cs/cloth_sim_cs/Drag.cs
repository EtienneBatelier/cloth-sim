namespace Drag;
using Constraint;
using Mass;
using Vector3D;

class Drag : Constraint
{
    private Vector3D windVelocity;

    //Constructor

    public Drag(double start_, double end_, Vector3D windVelocity_) {base.start = start_; base.end = end_; windVelocity = new Vector3D(windVelocity_);}


    //Other methods

    public override bool Applies(Mass m, double time) {return (base.start <= time && base.end >= time);}
    public override Vector3D Force(Mass m, double time) {return -m.GetPenetrationCoef()*(m.GetVelocity() - windVelocity);}
    public override void Effect(Mass m) {}
}