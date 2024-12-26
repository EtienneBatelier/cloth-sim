namespace IntegrationMethod;
using Vector3D;


class IntegrationMethod
{
    public IntegrationMethod() {}

    public virtual (Vector3D, Vector3D) Integrate(Vector3D acceleration, Vector3D velocity, Vector3D position, double dt)
    {
        return (velocity, position);
    }
}