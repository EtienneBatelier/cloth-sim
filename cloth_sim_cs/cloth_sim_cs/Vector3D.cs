namespace Vector3D;

class Vector3D
{
    private double[] vector; 


    //Constructors

    public Vector3D(double[] vector_)                               {vector = vector_;}
    public Vector3D(double x_1 = 0, double x_2 = 0, double x_3 = 0) {vector = [x_1, x_2, x_3];}
    public Vector3D(Vector3D v)                                     {vector = [v.GetVector()[0], v.GetVector()[1], v.GetVector()[2]];}


    //Get, Equals, and ToString methods

    public double[] GetVector()         {return vector;}
    public override string ToString()   {return "(" + vector[0].ToString() + ", "  +  vector[1].ToString() + ", " + vector[2] + ")";}

    public bool Equals(Vector3D w)
    {
        for (int i = 0; i < 3; i++)
        {
            if (vector[i] == w.GetVector()[i])  //Evaluating (vector == w.GetVector()) would compare references
            return true;
        }
        return false;
    }

    public override bool Equals(object? obj)    //This override is Good measure to avoid a compilator Warning CS0660
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals(obj);
    }

    public override int GetHashCode() {return vector.GetHashCode();}    //This override is Good measure to avoid a compilator Warning CS0659


    //Algebra methods

    public double InnerProd(Vector3D w)     {return vector[0]*w.GetVector()[0] + vector[1]*w.GetVector()[1] + vector[2]*w.GetVector()[2];}
    public double SquaredNorm()             {return InnerProd(this);}
    public double Norm()                    {return Math.Sqrt(SquaredNorm());}
    public Vector3D ScalarMult(double a)    {return new Vector3D(a*vector[0], a*vector[1], a*vector[2]);}
    public Vector3D Opposite()              {return ScalarMult(-1);}
    public Vector3D Addition(Vector3D w)    {return new Vector3D(vector[0] + w.GetVector()[0], vector[1] + w.GetVector()[1], vector[2] + w.GetVector()[2]);}
    public Vector3D Substraction(Vector3D w){return Addition(w.Opposite());}

    public Vector3D CrossProd(Vector3D w)   
    {
        double x_1 = vector[1]*w.GetVector()[2] - vector[2]*w.GetVector()[1]; 
        double x_2 = vector[2]*w.GetVector()[0] - vector[0]*w.GetVector()[2]; 
        double x_3 = vector[0]*w.GetVector()[1] - vector[1]*w.GetVector()[0]; 
        return new Vector3D(x_1, x_2, x_3);
    }


    //Methods that modify the instance they are applied to 
    
    public void Scale(double a) {for (int i = 0; i < 3; i++) vector[i] *= a;}
    public void Oppose() {Scale(-1);}

    public void Normalize()
    {
        double norm = Norm();
        if (norm == 0)  throw new ArgumentException("Cannot normalize a zero-norm vector");
        Scale(1.0/norm);
    }


    //Operators

    public static Vector3D operator +(Vector3D v) {return v;}   
    public static Vector3D operator -(Vector3D v) {return v.Opposite();}
    public static Vector3D operator +(Vector3D v, Vector3D w) {return v.Addition(w);}   
    public static Vector3D operator -(Vector3D v, Vector3D w) {return v.Substraction(w);}
    public static Vector3D operator ^(Vector3D v, Vector3D w) {return v.CrossProd(w);}
    public static Vector3D operator *(Vector3D v, double a) {return v.ScalarMult(a);}
    public static Vector3D operator *(double a, Vector3D v) {return v.ScalarMult(a);}
    public static double operator *(Vector3D v, Vector3D w) {return v.InnerProd(w);}
    public static bool operator ==(Vector3D v, Vector3D w) {return v.Equals(w);}
    public static bool operator !=(Vector3D v, Vector3D w) {return !v.Equals(w);}
}
