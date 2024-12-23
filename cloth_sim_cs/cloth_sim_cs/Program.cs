namespace cloth_sim_cs;
using Vector3D; 
using Mass;
using Spring;

class Program
{
    static void TestVector3D()
    {
        //Testing Vector3D constructors, Get and ToString methods 
        //Passing an object with an overridden ToString() method to Console.WriteLine implictely uses ToString()
        Console.WriteLine("Creating four instances of Vector3D");
        Vector3D origin = new Vector3D();
        Vector3D u = new Vector3D(2, 5, -7);
        Vector3D v = new Vector3D([1.0, 2.0, 3.0]);
        Vector3D w = new Vector3D(v);
        Console.WriteLine("Printing a coordinate and a Vector3D");
        Console.WriteLine(u.GetVector()[1]); 
        Console.WriteLine(v); 

        //Testing Algebra methods
        Console.WriteLine("Printing the outcome of some algebraic operations");
        Console.WriteLine(u.InnerProd(v));
        Console.WriteLine(u.InnerProd(u));
        Console.WriteLine(u.SquaredNorm());
        Console.WriteLine(w.Norm());
        Console.WriteLine(w.ScalarMult(6));
        Console.WriteLine(v.Opposite());
        Console.WriteLine(u.Addition(v));
        Console.WriteLine(u.Substraction(v));
        Console.WriteLine(u.CrossProd(v));
        Console.WriteLine(origin.Equals(new Vector3D(0.0, 0.0, 0.0)));

        //Testing methods that modify the instance they are applied to
        v.Oppose();
        v.Normalize();
        Console.WriteLine(v);
        Console.WriteLine(w);

        //Testing overloaded operators
        Console.WriteLine("Testing the overloaded operators");
        Console.WriteLine(v != w);
        Console.WriteLine(v + w);
        v += w;
        Console.WriteLine(v);



        
    }

    static unsafe void Main()
    {
        TestVector3D();
    }
}