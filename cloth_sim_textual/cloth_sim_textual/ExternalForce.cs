namespace ExternalForce{
using Mass;
using Vector3D;

//A virtual class to implement forces in the system that do not come from the damped springs. 
//Each sub-class has its own rules regarding how to check if the forces Applies to a Mass, 
//and what that Force should be. 
class ExternalForce
{   
    protected float? start; 
    protected float? end; 
    public ExternalForce() {}
    public virtual bool Applies(Mass m, float time) {return false;} 
    public virtual Vector3D Force(Mass m, float time) {return new Vector3D();}

    protected bool InTimeInterval(float time)
    {
        if (start == null)
        {
            if (end == null | time <= end) {return true;}
        }
        if (start <= time)
        {
            if (end == null | time <= end) {return true;}
        } 
        return false; 
    }
}
}