namespace RungeKuttaMethod{
using Vector3D;
using IntegrationMethod;
using ExternalForce;
using Mass;
using System.Collections.Generic;

class RungeKuttaMethod : IntegrationMethod
{
    private Vector3D k1;
    private Vector3D k2;
    private Vector3D k3;
    private Vector3D k4;
    private Vector3D oldPosition;
    private Vector3D oldVelocity;


    public RungeKuttaMethod() {}

    public override void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, float time, float dt)
    {
        oldPosition = m.GetPosition();
        oldVelocity = m.GetVelocity();

        k1 = m.Acceleration();
        m.AddToPosition(0.5f*dt*oldVelocity);
        m.AddToVelocity(0.5f*dt*k1);
        IntegrationMethod.UpdateForce(m, externalForces, time);
        k2 = m.Acceleration();
        m.AddToPosition(0.25f*dt*dt*k1);
        m.SetVelocity(oldVelocity + 0.5f*dt*k2);
        IntegrationMethod.UpdateForce(m, externalForces, time);
        k3 = m.Acceleration();
        m.SetPosition(oldPosition + dt*oldVelocity + 0.5f*dt*dt*k2);
        m.SetVelocity(oldVelocity + dt*k3);
        IntegrationMethod.UpdateForce(m, externalForces, time);
        k4 = m.Acceleration();
        
        m.SetPosition(oldPosition + dt*oldVelocity + (dt*dt/6)*(k1 + k2 + k3));
        m.SetVelocity(oldVelocity + (dt/6)*(k1 + 2*k2 + 2*k3 + k4));
        IntegrationMethod.UpdateForce(m, externalForces, time);
    }
}
}