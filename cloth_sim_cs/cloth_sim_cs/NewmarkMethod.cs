namespace NewmarkMethod;
using Vector3D;
using IntegrationMethod;

class NewmarkMethod : IntegrationMethod
{
    private readonly double gamma;
    private readonly double beta;
    private readonly double epsilon;
    private readonly int maxIteration;
    private Vector3D posAux;
    private Vector3D velAux;
    private Vector3D accAux;


    public NewmarkMethod(double gamma_ = .5, double beta_ = .6, double epsilon_ = 0.01, int maxIteration_ = 100) 
    {
        gamma = gamma_;
        beta = beta_;
        epsilon = epsilon_;
        maxIteration = maxIteration_;
        posAux = new Vector3D();
        velAux = new Vector3D();
        accAux = new Vector3D();
    }

    public override (Vector3D, Vector3D) Integrate(Vector3D acceleration, Vector3D velocity, Vector3D position, double dt)
    {
        return base.Integrate(acceleration, velocity, position, dt);
    }
}