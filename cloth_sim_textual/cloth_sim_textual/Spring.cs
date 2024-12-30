namespace Spring{
using Mass;
using Vector3D;

class Spring
{
    private readonly Mass firstEnd; 
    private readonly Mass secondEnd; 
    private readonly float stiffness; 
    private readonly float restLength; 


    //Constructor

    public Spring(Mass firstEnd_, Mass secondEnd_, float stiffness_ = 1, float restLength_ = 1)
    {
        firstEnd = firstEnd_;
        secondEnd = secondEnd_;
        stiffness = stiffness_;
        restLength = restLength_;
        firstEnd.Attach(this);
        secondEnd.Attach(this);
    }


    //Get and ToString() methods

    public Mass GetFirstEnd() {return new Mass(firstEnd);}
    public Mass GetSecondEnd() {return new Mass(secondEnd);}

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
            return (stiffness*(length - restLength)/length)*v; 
        }
        if (m == secondEnd)
        {
            Vector3D v = firstEnd.GetPosition() - secondEnd.GetPosition();
            float length = v.Norm();
            return (stiffness*(length - restLength)/length)*v; 
        }
        return new Vector3D();
    }
}
}