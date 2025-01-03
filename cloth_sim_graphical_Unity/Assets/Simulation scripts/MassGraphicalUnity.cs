namespace MassGraphicalUnity{
using UnityEngine;
using Mass;
using Vector3D;

unsafe class MassGraphicalUnity : Mass
{
    public GameObject sphere;


    //Constructors

    public MassGraphicalUnity(float* mass_, float* penetrationCoef_, Vector3D position_) : base(mass_, penetrationCoef_, position_)
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        float[] vector = position_.GetVector();
        sphere.transform.position = new Vector3(vector[0], vector[2], vector[1]); //Switching second and third coordinates
    }

    public MassGraphicalUnity(float* mass_, float* penetrationCoef_, Vector3D position_, float radius) : base(mass_, penetrationCoef_, position_)
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        float[] vector = position_.GetVector();
        sphere.transform.position = new Vector3(vector[0], vector[2], vector[1]); //Switching second and third coordinates
        sphere.transform.localScale = new Vector3(radius, radius, radius);
    }

    public void UpdateGraphicalPosition()
    {
        float[] vector = base.position.GetVector();
        sphere.transform.position = new Vector3(vector[0], vector[2], vector[1]); //Switching second and third coordinates
    }

    public void DestroySphere()
    {
        Object.Destroy(sphere);
    }

    //Finalizer

    ~MassGraphicalUnity() {DestroySphere();}
}
}
