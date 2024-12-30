namespace Mass{
using Vector3D;
using Spring;
using System.Collections.Generic;

class Mass
{
    protected float mass;
    protected float dragFactor;
    protected Vector3D position;
    protected Vector3D velocity; 
    protected Vector3D force; 
    protected List<Spring> associatedSprings;


    //Constructors


    public Mass()
    {
        mass = 1;
        dragFactor = .5f;
        position = new Vector3D(); 
        velocity = new Vector3D(); 
        force = new Vector3D(); 
        associatedSprings = new List<Spring>();
    }

    public Mass(float mass_, float dragFactor_, Vector3D position_)
    {
        mass = mass_;
        dragFactor = dragFactor_;
        position = new Vector3D(position_); //We use the copy constructor here; otherwise, creating two masses at the same position would link them forever
        velocity = new Vector3D(); 
        force = new Vector3D(); 
        associatedSprings = new List<Spring>();
    }

    public Mass(float mass_, float dragFactor_, Vector3D position_, Vector3D velocity_, Vector3D force_, List<Spring> associatedSprings_)
    {
        mass = mass_;
        dragFactor = dragFactor_;
        position = new Vector3D(position_); //We use the copy constructor here; otherwise, creating two masses at the same position would link them forever
        velocity = new Vector3D(velocity_); //Same comment as above 
        force = new Vector3D(force_);
        associatedSprings = new List<Spring>();
        foreach (Spring associatedSpring_ in associatedSprings_) associatedSprings.Add(associatedSpring_); 
    }

    public Mass(Mass mass_)
    {
        mass = mass_.GetMass();
        dragFactor = mass_.GetDragFactor();
        position = mass_.GetPosition();
        velocity = new Vector3D();
        force = new Vector3D();
        associatedSprings = new List<Spring>();
    }


    //Get and ToString() methods

    public float GetMass() {return mass;}
    public float GetDragFactor() {return dragFactor;}
    public Vector3D GetPosition() {return new Vector3D(position);}
    public Vector3D GetVelocity() {return new Vector3D(velocity);}
    public Vector3D GetForce() {return new Vector3D(force);}

    public override string ToString()
    {
        return "Mass " + GetHashCode() + " is at position " + position; 
    }


    //Set methods 

    public void SetVelocity(Vector3D velocity_) {velocity.SetVector(velocity_);}
    public void SetPosition(Vector3D position_) {position.SetVector(position_);}

    public void SetInnerForce() 
    {
        force.SetVector(0, 0, 0);
        foreach (Spring spring in associatedSprings)
        {
            force.Add(spring.SpringForce(this));
        } 
    }


    //Other methods

    public float Speed() {return velocity.Norm();}
    public Vector3D Acceleration() {return force*(1.0f/mass);}
    public void Attach(Spring spring) {associatedSprings.Add(spring);} 
    public void AddForce(Vector3D force_){force.Add(force_);}
    
    public Vector3D InnerForce()
    {
        Vector3D force_ = new Vector3D(); 
        foreach (Spring spring in associatedSprings)
        {
            force_ += spring.SpringForce(this);
        } 
        return force_;
    }


    //Testing methods (should remain as comments)
    
    //public List<Spring> GetAssociatedSprings() {return associatedSprings;}
}
}