namespace EulerMethod{
using IntegrationMethod; 
using Mass;
using System.Collections.Generic;
using ExternalForce;

class EulerMethod: IntegrationMethod
{
    public EulerMethod() {}

    public override void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, float time, float dt)
    {
        m.SetPosition(m.GetPosition() + dt*m.GetVelocity());
        m.SetVelocity(m.GetVelocity() + dt*m.Acceleration());
        IntegrationMethod.UpdateForce(m, externalForces, time);
    }
}
}