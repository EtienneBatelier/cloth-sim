namespace IntegrationMethod{
using Vector3D;
using Mass;
using ExternalForce;
using System.Collections.Generic;

//A virtual class. 
//The overridden UpdateForceVelocityPosition in the child classes use their integration rules to solve for the new force, velocity and position of a mass. 
class IntegrationMethod
{
    public IntegrationMethod() {}
    public virtual void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, float time, float dt) {}

    public static void UpdateForce(Mass m, List<ExternalForce> externalForces, float time) 
    {
        m.SetInnerForce();
        foreach (ExternalForce externalForce in externalForces) 
        {
            if (externalForce.Applies(m, time)) {m.AddForce(externalForce.Force(m, time));}
        } 
    }
}
}