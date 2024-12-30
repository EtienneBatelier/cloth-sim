namespace ExternalForce{
using Mass;
using Vector3D;

class ExternalForce
{   
    protected double? start; 
    protected double? end; 
    public ExternalForce() {}
    public virtual bool Applies(Mass m, double time) {return false;} 
    public virtual Vector3D Force(Mass m, double time) {return new Vector3D();}

    protected bool InTimeInterval(double time)
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