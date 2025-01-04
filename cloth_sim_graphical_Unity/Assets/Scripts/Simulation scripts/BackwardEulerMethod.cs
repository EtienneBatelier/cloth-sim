namespace BackwardEulerMethod{
using Vector3D;
using IntegrationMethod;
using ExternalForce;
using Mass;
using System.Collections.Generic;

class BackwardEulerMethod : IntegrationMethod
{
    private readonly float epsilonSquared;
    private readonly int maxIterations;


    public BackwardEulerMethod(float epsilon_ = 1e-3f, int maxIterations_ = 100) {epsilonSquared = epsilon_*epsilon_;; maxIterations = maxIterations_;}

    public override void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, float time, float dt)
    {
        int iterations = 0;
        Vector3D auxPos;
        Vector3D oldPos= new Vector3D(m.GetPosition());
        Vector3D oldVel = new Vector3D(m.GetVelocity());
        do{
            auxPos = m.GetPosition();
            iterations += 1;
            m.SetPosition(oldPos + dt*m.GetVelocity());
            m.SetVelocity(oldVel + dt*m.Acceleration());
            IntegrationMethod.UpdateForce(m, externalForces, time);
        }while ((m.GetPosition() - auxPos).SquaredNorm() > epsilonSquared && iterations < maxIterations);
        IntegrationMethod.UpdateForce(m, externalForces, time);
    }
}
}