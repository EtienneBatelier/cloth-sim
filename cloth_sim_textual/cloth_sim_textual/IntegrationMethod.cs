namespace IntegrationMethod{
using Mass;
using ExternalForce;
using System.Collections.Generic;

class IntegrationMethod
{
    public IntegrationMethod() {}
    public virtual void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, float time, float dt) {}

    public void UpdateForce(Mass m, List<ExternalForce> externalForces, float time) 
    {
        m.SetInnerForce();
        foreach (ExternalForce externalForce in externalForces) 
        {
            if (externalForce.Applies(m, time)) {m.AddExternalForce(externalForce.Force(m, time));}
        } 
    }
}
}