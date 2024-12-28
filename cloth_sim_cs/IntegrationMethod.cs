namespace IntegrationMethod;
using Vector3D;
using Mass;
using ExternalForce;

class IntegrationMethod
{
    public IntegrationMethod() {}
    public virtual void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, double time, double dt) {}

    public void UpdateForce(Mass m, List<ExternalForce> externalForces, double time) 
    {
        m.SetInnerForce();
        foreach (ExternalForce externalForce in externalForces) 
        {
            if (externalForce.Applies(m, time)) {m.AddExternalForce(externalForce.Force(m, time));}
        } 
    }
}