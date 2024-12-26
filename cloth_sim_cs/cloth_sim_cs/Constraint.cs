namespace Constraint;
using Mass;
using Vector3D;

class Constraint
{
    protected double start;
    protected double end;

    //Constructor

    public Constraint() {start = 0; end = 0;}


    //Other methods
    
    public virtual bool Applies(Mass m , double time) {return false;} 
    public virtual Vector3D Force(Mass m, double time) {return new Vector3D();}
    public virtual void Effect(Mass m) {}
}