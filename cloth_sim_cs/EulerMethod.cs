namespace EulerMethod; 
using Vector3D; 
using IntegrationMethod; 
using Mass;
using ExternalForce;

class EulerMethod: IntegrationMethod
{
    public EulerMethod() {}

    public override void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, double time, double dt)
    {
        m.SetPosition(m.GetPosition() + dt*m.GetVelocity());
        m.SetVelocity(m.GetVelocity() + dt*m.Acceleration());
        base.UpdateForce(m, externalForces, time);
    }
}