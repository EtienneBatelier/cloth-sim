namespace NewmarkMethod{
using Vector3D;
using IntegrationMethod;
using ExternalForce;
using Mass;
using System.Collections.Generic;

class NewmarkMethod : IntegrationMethod
{
    private readonly float gamma;
    private readonly float beta;
    private readonly float epsilonSquared;
    private readonly int maxIterations;


    public NewmarkMethod(float gamma_ = .5f, float beta_ = .16f, float epsilon_ = 1e-4f, int maxIterations_ = 100) 
    {
        gamma = gamma_;
        beta = beta_;
        epsilonSquared = epsilon_*epsilon_;
        maxIterations = maxIterations_;
    }

    public override void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, float time, float dt)
    {
        int iterations = 0;
        Vector3D auxPos;
        Vector3D oldPos= new Vector3D(m.GetPosition());
        Vector3D oldVel = new Vector3D(m.GetVelocity());
        Vector3D oldAcc = new Vector3D(m.Acceleration());
        do{
            auxPos = m.GetPosition();
            iterations += 1;
            IntegrationMethod.UpdateForce(m, externalForces, time);
            m.SetVelocity(oldVel + dt*((1 - gamma)*oldAcc + gamma*m.Acceleration()));
            m.SetPosition(oldPos + dt*oldVel + dt*dt*0.5f*((1 - 2*beta)*oldAcc + 2*beta*m.Acceleration()));
        }while ((m.GetPosition() - auxPos).SquaredNorm() > epsilonSquared && iterations < maxIterations);
        IntegrationMethod.UpdateForce(m, externalForces, time);
    }
}
}