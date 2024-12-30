using System;

namespace Vector3D{

class Vector3D
{
    private float[] vector; 


    //Constructors

    public Vector3D(float[] vector_)                               {vector = new float[]{vector_[0], vector_[1], vector_[2]};}
    public Vector3D(float x_1 = 0, float x_2 = 0, float x_3 = 0) {vector = new float[]{x_1, x_2, x_3};}
    public Vector3D(Vector3D v)                                     {vector = new float[]{v.GetVector()[0], v.GetVector()[1], v.GetVector()[2]};}


    //Get, Equals, and ToString methods

    public float[] GetVector()         {return new float[]{vector[0], vector[1], vector[2]};}
    public override string ToString()   {return "(" + vector[0].ToString() + ", "  +  vector[1].ToString() + ", " + vector[2] + ")";}

    public bool Equals(Vector3D w)
    {
        for (int i = 0; i < 3; i++)
        {
            if (vector[i] != w.GetVector()[i])  //Evaluating (vector == w.GetVector()) would compare references
            return false;
        }
        return true;
    }

    #nullable enable
    public override bool Equals(object? obj)    //This override is good measure to avoid a compilator Warning CS0660
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals(obj);
    }
    #nullable disable

    public override int GetHashCode() {return vector.GetHashCode();}    //This override is Good measure to avoid a compilator Warning CS0659


    //Algebra methods

    public float InnerProd(Vector3D w)     {return vector[0]*w.GetVector()[0] + vector[1]*w.GetVector()[1] + vector[2]*w.GetVector()[2];}
    public float SquaredNorm()             {return InnerProd(this);}
    public float Norm()                    {return (float) Math.Sqrt(SquaredNorm());}
    public Vector3D ScalarMult(float a)    {return new Vector3D(a*vector[0], a*vector[1], a*vector[2]);}
    public Vector3D Opposite()              {return ScalarMult(-1);}
    public Vector3D Addition(Vector3D w)    {return new Vector3D(vector[0] + w.GetVector()[0], vector[1] + w.GetVector()[1], vector[2] + w.GetVector()[2]);}
    public Vector3D Substraction(Vector3D w){return Addition(w.Opposite());}

    public Vector3D CrossProd(Vector3D w)   
    {
        float x_1 = vector[1]*w.GetVector()[2] - vector[2]*w.GetVector()[1]; 
        float x_2 = vector[2]*w.GetVector()[0] - vector[0]*w.GetVector()[2]; 
        float x_3 = vector[0]*w.GetVector()[1] - vector[1]*w.GetVector()[0]; 
        return new Vector3D(x_1, x_2, x_3);
    }


    //Methods that modify the instance they are applied to 
    
    public void Scale(float a) {for (int i = 0; i < 3; i++) vector[i] *= a;}
    public void Oppose() {Scale(-1);}

    public void Normalize()
    {
        float norm = Norm();
        if (norm == 0)  throw new ArgumentException("Cannot normalize a zero-norm vector");
        Scale((float) 1.0/norm);
    }


    //Operators

    public static Vector3D operator +(Vector3D v) {return v;}   
    public static Vector3D operator -(Vector3D v) {return v.Opposite();}
    public static Vector3D operator +(Vector3D v, Vector3D w) {return v.Addition(w);}   
    public static Vector3D operator -(Vector3D v, Vector3D w) {return v.Substraction(w);}
    public static Vector3D operator ^(Vector3D v, Vector3D w) {return v.CrossProd(w);}
    public static Vector3D operator *(Vector3D v, float a) {return v.ScalarMult((float) a);}
    public static Vector3D operator *(float a, Vector3D v) {return v.ScalarMult((float) a);}
    public static float operator *(Vector3D v, Vector3D w) {return v.InnerProd(w);}
    public static bool operator ==(Vector3D v, Vector3D w) {return v.Equals(w);}
    public static bool operator !=(Vector3D v, Vector3D w) {return !v.Equals(w);}
}
}