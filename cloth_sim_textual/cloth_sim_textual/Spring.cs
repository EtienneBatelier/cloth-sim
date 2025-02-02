namespace Spring{
using Mass;
using Vector3D;

//A class to represent a spring connecting two masses. Most important method is SpringForce, 
//returning the spring's force on a Mass using Hook's law from classical mechanics. 
unsafe class Spring
{
    protected readonly Mass firstEnd; 
    protected readonly Mass secondEnd; 
    private float* stiffness; 
    private float* restLength; 


    //Constructor

    public Spring(Mass firstEnd_, Mass secondEnd_, float* stiffness_, float* restLength_)
    {
        firstEnd = firstEnd_;
        secondEnd = secondEnd_;
        stiffness = stiffness_;
        restLength = restLength_;
        firstEnd.Attach(this);
        secondEnd.Attach(this);
    }


    //Get and ToString() methods

    public override string ToString() 
    {
        return "Spring " + GetHashCode();
    }

    //Methods

    public bool IsAnEnd(Mass m) {return m == firstEnd | m == secondEnd;}
    public float SpringForceMagnitude() {return SpringForce(firstEnd).Norm();}

    public Vector3D SpringForce(Mass m)
    {
        if (m == firstEnd)
        {
            Vector3D v = secondEnd.GetPosition() - firstEnd.GetPosition();
            float length = v.Norm();
            return (*stiffness*(length - *restLength)/length)*v; 
        }
        if (m == secondEnd)
        {
            Vector3D v = firstEnd.GetPosition() - secondEnd.GetPosition();
            float length = v.Norm();
            return (*stiffness*(length - *restLength)/length)*v; 
        }
        return new Vector3D();
    }
}
}