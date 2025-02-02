namespace RungeKuttaMethod{
using Vector3D;
using IntegrationMethod;
using ExternalForce;
using Mass;
using System.Collections.Generic;

//An implementation of the RK4 integration method. 
class RungeKuttaMethod : IntegrationMethod
{
    private Vector3D k1;
    private Vector3D k2;
    private Vector3D k3;
    private Vector3D k4;
    private Vector3D oldPosition;
    private Vector3D oldVelocity;


    public RungeKuttaMethod() 
    {
        k1 = new Vector3D();
        k2 = new Vector3D();
        k3 = new Vector3D();
        k4 = new Vector3D();
        oldPosition = new Vector3D();
        oldVelocity = new Vector3D();
    }

    public override void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, float time, float dt)
    {
        oldPosition = m.GetPosition();
        oldVelocity = m.GetVelocity();

        k1.SetVector(m.Acceleration());
        m.AddToPosition(0.5f*dt*oldVelocity);
        m.AddToVelocity(0.5f*dt*k1);
        IntegrationMethod.UpdateForce(m, externalForces, time);
        k2.SetVector(m.Acceleration());
        m.AddToPosition(0.25f*dt*dt*k1);
        m.SetVelocity(oldVelocity + 0.5f*dt*k2);
        IntegrationMethod.UpdateForce(m, externalForces, time);
        k3.SetVector(m.Acceleration());
        m.SetPosition(oldPosition + dt*oldVelocity + 0.5f*dt*dt*k2);
        m.SetVelocity(oldVelocity + dt*k3);
        IntegrationMethod.UpdateForce(m, externalForces, time);
        k4.SetVector(m.Acceleration());
        
        m.SetPosition(oldPosition + dt*oldVelocity + (dt*dt/6)*(k1 + k2 + k3));
        m.SetVelocity(oldVelocity + (dt/6)*(k1 + 2*k2 + 2*k3 + k4));
        IntegrationMethod.UpdateForce(m, externalForces, time);
    }
}
}