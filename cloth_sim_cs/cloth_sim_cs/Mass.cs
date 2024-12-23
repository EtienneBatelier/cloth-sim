namespace Mass; 
using Vector3D;
using Spring;

unsafe class Mass
{
    private double mass;
    private double penetrationCoef;
    private Vector3D position;
    private Vector3D velocity; 
    private List<Vector3D> forces; 
    private List<Spring> associatedSprings;


    //Constructor

    public Mass(double mass_, double penetrationCoef_, Vector3D position_, Vector3D velocity_, List<Vector3D> forces_, List<Spring> associatedSprings_)
    {
        mass = mass_;
        penetrationCoef = penetrationCoef_;
        position = new Vector3D(position_); //We use the copy constructor here; otherwise, creating two masses at the same position 
        velocity = new Vector3D(velocity_); //(or with the same velocity/forces) would link them forever
        forces = [];
        foreach (Vector3D force_ in forces_) forces.Add(new Vector3D(force_)); 
        associatedSprings = [];
        foreach (Spring associatedSpring_ in associatedSprings_) associatedSprings.Add(associatedSpring_); 
    }


    //Get methods

    public Vector3D GetPosition() {return new Vector3D(position);}
}
