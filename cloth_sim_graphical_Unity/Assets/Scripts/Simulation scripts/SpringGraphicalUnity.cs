namespace SpringGraphicalUnity{
using UnityEngine;
using Spring;
using Vector3D;
using Mass;


unsafe class SpringGraphicalUnity : Spring
{
    //A GameObject and a LineRenderer are the bare minimum to draw a line on the screen using Unity. 
    public GameObject gameObject;
    public LineRenderer lineRenderer;


    //Constructors

    public SpringGraphicalUnity(Mass firstEnd_, Mass secondEnd_, float* stiffness_, float* restLength_) : base(firstEnd_, secondEnd_, stiffness_, restLength_)
    {
        gameObject = new GameObject();
        gameObject.AddComponent<LineRenderer>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;                                     //LineRenderer allows for jagged lines that connect many points. We just need two points. 
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));   //Material and Shaders are Unity classes used to specify graphical many visual settings. 
        lineRenderer.material.SetColor("_BaseColor", Color.white);          //We set the color of the line to white here. 
        lineRenderer.startWidth = 0.05f;                                    //We set the width of the line to a constant 0.5.
        lineRenderer.endWidth = 0.05f;
    }


    //Other methods

    public void UpdateGraphicalPosition()
    {
        float[] vector = base.firstEnd.GetPosition().GetVector();
        lineRenderer.SetPosition(0, new Vector3(vector[0], vector[2], vector[1]));  //Updates the position of the zeroth point in lineRenderer.
        vector = base.secondEnd.GetPosition().GetVector();
        lineRenderer.SetPosition(1, new Vector3(vector[0], vector[2], vector[1]));  //Updates the position of the first point in lineRenderer.
    }

    public void DestroyGameObject() {Object.Destroy(gameObject);}


    //Finalizer

    ~SpringGraphicalUnity() {DestroyGameObject();}
}
}