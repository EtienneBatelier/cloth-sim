namespace NewmarkMethod;
using Vector3D;
using IntegrationMethod;

class NonLinearNewmarkMethod : IntegrationMethod
{
    private double epsilon;

    public NonLinearNewmarkMethod(double epsilon_) {epsilon = epsilon_;}

    public override (Vector3D, Vector3D) Integrate(Vector3D acceleration, Vector3D velocity, Vector3D position, double dt)
    {
        return base.Integrate(acceleration, velocity, position, dt);
    }
}