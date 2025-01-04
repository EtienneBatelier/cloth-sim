namespace ExternalForce{
using Mass;
using Vector3D;

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