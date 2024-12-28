namespace NewmarkMethod;
using Vector3D;
using IntegrationMethod;
using ExternalForce;
using Mass;

class NewmarkMethod : IntegrationMethod
{
    private readonly double gamma;
    private readonly double beta;
    private readonly double epsilon;
    private readonly int maxIterations;


    public NewmarkMethod(double gamma_ = .5, double beta_ = .6, double epsilon_ = 1e-10, int maxIterations_ = 100) 
    {
        gamma = gamma_;
        beta = beta_;
        epsilon = epsilon_;
        maxIterations = maxIterations_;
    }

    public override void UpdateForceVelocityPosition(Mass m, List<ExternalForce> externalForces, double time, double dt)
    {
        int iterations = 0;
        Vector3D auxPos;
        Vector3D oldPos= new Vector3D(m.GetPosition());
        Vector3D oldVel = new Vector3D(m.GetVelocity());
        Vector3D oldAcc = new Vector3D(m.Acceleration());
        do{
            auxPos = m.GetPosition();
            iterations += 1;
            base.UpdateForce(m, externalForces, time);
            m.SetVelocity(oldVel + dt*((1 - gamma)*oldAcc + gamma*m.Acceleration()));
            m.SetPosition(oldPos + dt*oldVel + dt*dt*0.5*((1 - 2*beta)*oldAcc + 2*beta*m.Acceleration()));
        }while ((m.GetPosition() - auxPos).Norm() > epsilon && iterations < maxIterations);
        base.UpdateForce(m, externalForces, time);
    }
}