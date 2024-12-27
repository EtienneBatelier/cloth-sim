namespace Mass; 
using Vector3D;
using Spring;
using IntegrationMethod; 

unsafe class Mass
{
    private readonly double mass;
    private readonly double penetrationCoef;
    private Vector3D position;
    private Vector3D velocity; 
    private Vector3D force; 
    private List<Spring> associatedSprings;


    //Constructors

    public Mass(double mass_, double penetrationCoef_, Vector3D position_)
    {
        mass = mass_;
        penetrationCoef = penetrationCoef_;
        position = new Vector3D(position_); //We use the copy constructor here; otherwise, creating two masses at the same position would link them forever
        velocity = new Vector3D(); 
        force = new Vector3D(); 
        associatedSprings = [];
    }

    public Mass(double mass_, double penetrationCoef_, Vector3D position_, Vector3D velocity_, Vector3D force_, List<Spring> associatedSprings_)
    {
        mass = mass_;
        penetrationCoef = penetrationCoef_;
        position = new Vector3D(position_); //We use the copy constructor here; otherwise, creating two masses at the same position would link them forever
        velocity = new Vector3D(velocity_); //Same comment as above 
        force = new Vector3D(force_);
        associatedSprings = [];
        foreach (Spring associatedSpring_ in associatedSprings_) associatedSprings.Add(associatedSpring_); 
    }

    public Mass(Mass mass_)
    {
        mass = mass_.GetMass();
        penetrationCoef = mass_.GetPenetrationCoef();
        position = mass_.GetPosition();
        velocity = new Vector3D();
        force = new Vector3D();
        associatedSprings = [];
    }


    //Get and ToString() methods

    public double GetMass() {return mass;}
    public double GetPenetrationCoef() {return penetrationCoef;}
    public Vector3D GetPosition() {return new Vector3D(position);}
    public Vector3D GetVelocity() {return new Vector3D(velocity);}
    public Vector3D GetForce() {return new Vector3D(force);}

    public override string ToString()
    {
        return "Mass " + GetHashCode() + " is at position " + position; 
    }


    //Other methods

    public double Speed() {return velocity.Norm();}
    public Vector3D Acceleration() {return force*(1.0/mass);}
    public void Attach(Spring spring) {associatedSprings.Add(spring);} 
    public void AddExternalForce(Vector3D totalExternalForce) {force += totalExternalForce;}

    public void SetInnerForce()
    {
        force = new Vector3D(); 
        foreach (Spring spring in associatedSprings)
        {
            force += spring.SpringForce(this);
        } 
    }

    public void UpdateVelocityPosition(IntegrationMethod intMeth, double dt)
    {
        (Vector3D velocity_, Vector3D position_) = intMeth.Integrate(Acceleration(), 
                                                                    new Vector3D(velocity), 
                                                                    new Vector3D(position), 
                                                                    dt);
        velocity = velocity_;
        position = position_;
    }


    //Testing methods (should remain as comments)
    
    //public List<Spring> GetAssociatedSprings() {return associatedSprings;}
}