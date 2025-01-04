namespace SpringGraphicalUnity{
using UnityEngine;
using Spring;
using Vector3D;
using Mass;

unsafe class SpringGraphicalUnity : Spring
{
    public GameObject gameObject;
    public LineRenderer lineRenderer;


    //Constructors

    public SpringGraphicalUnity(Mass firstEnd_, Mass secondEnd_, float* stiffness_, float* restLength_) : base(firstEnd_, secondEnd_, stiffness_, restLength_)
    {
        gameObject = new GameObject();
        gameObject.AddComponent<LineRenderer>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
    }


    //Other methods

    public void UpdateGraphicalPosition()
    {
        float[] vector = base.firstEnd.GetPosition().GetVector();
        lineRenderer.SetPosition(0, new Vector3(vector[0], vector[2], vector[1]));
        vector = base.secondEnd.GetPosition().GetVector();
        lineRenderer.SetPosition(1, new Vector3(vector[0], vector[2], vector[1]));
    }

    public void DestroyGameObject() {Object.Destroy(gameObject);}

    //Finalizer

    ~SpringGraphicalUnity() {DestroyGameObject();}
}
}