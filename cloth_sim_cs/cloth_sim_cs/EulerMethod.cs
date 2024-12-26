namespace EulerMethod; 
using Vector3D; 
using IntegrationMethod; 

class EulerMethod: IntegrationMethod
{
    public EulerMethod() {}

    public override (Vector3D, Vector3D) Integrate(Vector3D acceleration, Vector3D velocity, Vector3D position, double dt)
    {  
	    velocity += dt*acceleration;
        position += dt*velocity;
        return (velocity, position);
    }
}