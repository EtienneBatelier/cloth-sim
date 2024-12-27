namespace TestPrinter;
using Vector3D;
using Mass;
using Spring;
using EulerMethod;
using ClothPiece;
using ConstantForce;
using ExternalForce;
using Drag;
using Hook;
using Push;
using PhysicalSystem;

unsafe class TestPrinter
{
    public static void TestVector3D()
    {
        Console.WriteLine("TESTING Vector3D");
        Console.WriteLine("Instanciating four Vector3Ds:");
        Console.WriteLine("origin = (0, 0, 0), ");
        Console.WriteLine("u = (2, 5, -7), ");
        Console.WriteLine("v = (1, 2, 3), ");
        Console.WriteLine("w = (1, 2, 3). ");
        Vector3D origin = new Vector3D();
        Vector3D u = new Vector3D(2, 5, -7);
        Vector3D v = new Vector3D([1.0, 2.0, 3.0]);
        Vector3D w = new Vector3D(v);
        Console.Write("Printing u: "); 
        Console.WriteLine(u); //The overridden ToString() proides an implicit conversion to string
        Console.Write("Printing the second entry of v: "); 
        Console.WriteLine(v.GetVector()[1]);

        //Testing Algebra methods
        Console.WriteLine("Printing the inner product of u and v, the squared norm of u, the norm of w, 6w, u + v, u - v and u x v.");
        Console.Write(u.InnerProd(v) + ", ");
        Console.Write(u.SquaredNorm() + ", ");
        Console.Write(w.Norm() + ", ");
        Console.Write(w.ScalarMult(6) + ", ");
        Console.Write(u.Addition(v) + ", ");
        Console.Write(u.Substraction(v) + ", ");
        Console.WriteLine(u.CrossProd(v) + ". ");


        //Testing the Equals method
        Console.Write("Does the origin equal (0, 0, 0)? ");
        Console.WriteLine(origin.Equals(new Vector3D(0.0, 0.0, 0.0)));
        Console.Write("Does v equal w? ");
        Console.WriteLine(v.Equals(w));
        Console.Write("Do v an w occupy the same memory space? ");
        Console.WriteLine(ReferenceEquals(v, w));

        //Testing methods that modify the instance they are applied to
        Console.Write("The Vector3D v is replaced by its opposite and then normalized. "); 
        Console.WriteLine("The new v equals: ");
        v.Oppose();
        v.Normalize();
        Console.WriteLine(v);

        //Testing overloaded operators
        Console.Write("Printing u + w and 2*u using overloaded operators: ");
        Console.Write(u+w + ", ");
        Console.WriteLine(2*u + ". ");
        Console.Write("The Vector3D v is replaced with its sum with w. ");
        Console.WriteLine("The new v equals: ");
        v += w;
        Console.WriteLine(v);       
    }

    public static void TestMassSpring()
    {
        Console.WriteLine("TESTING Mass and Spring");
        Console.WriteLine("Requires the commented testing methods in Mass.cs");
        Console.WriteLine("Instanciating three masses connected by two spring in a chain: ");
        Mass m1 = new Mass(1, .5, new Vector3D([-1, 0, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([0, 0, 0])); 
        Mass m3 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        Spring s1 = new Spring(m1, m2, 5, 2); 
        Spring s2 = new Spring(m2, m3, 5, 2);
        Console.Write(m1.ToString() + " and is connected to ");
        //foreach (Spring spring in m1.GetAssociatedSprings()) {Console.Write(spring + " ");}
        Console.WriteLine("");
        Console.Write(m2.ToString() + " and is connected to ");
        //foreach (Spring spring in m2.GetAssociatedSprings()) {Console.Write(spring + " ");}
        Console.WriteLine("");
        Console.Write(m3.ToString() + " and is connected to ");
        //foreach (Spring spring in m3.GetAssociatedSprings()) {Console.Write(spring + " ");}
        Console.WriteLine("");
        Console.WriteLine("We make the masses updates their forces");
        m1.SetInnerForce();
        m2.SetInnerForce();
        m3.SetInnerForce();
        Console.WriteLine(m1.ToString() + " is subject to force " + m1.GetForce());
        Console.WriteLine(m1.ToString() + " is subject to force " + m2.GetForce());
        Console.WriteLine(m1.ToString() + " is subject to force " + m3.GetForce());
    }

    public static void TestIntegrationMethod()
    {
        Console.WriteLine("TESTING IntegrationMethod");
        Console.WriteLine("Instanciating three masses connected by two springs in an L shape: ");
        Mass m1 = new Mass(1, .5, new Vector3D([0, 1, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([0, 0, 0]));
        Mass m3 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        Spring s1 = new Spring(m1, m2, 5, .5);
        Spring s2 = new Spring(m2, m3, 5, .5);
        Console.WriteLine(m1);
        Console.WriteLine(m2);
        Console.WriteLine(m3);
        EulerMethod euler = new EulerMethod(); 
        double dt = 0.01;
        double time = 0.0 ;

        Console.WriteLine("Simulating the system for one tenth of a second: ");
        for (int n = 0; n < 10; n++)
        {
            m1.SetInnerForce();
            m2.SetInnerForce();
            m3.SetInnerForce();
            m1.UpdateVelocityPosition(euler, dt);
            m2.UpdateVelocityPosition(euler, dt);
            m3.UpdateVelocityPosition(euler, dt);
            time += dt;
            Console.WriteLine("t = " + time);
            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m3);
        }
    }

    public static void TestClothPiece()
    {
        Console.WriteLine("TESTING ClothPiece");
        Console.WriteLine("Requires the commented testing methods in ClothPiece.cs");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5, new Vector3D([0, 1, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([1, 1, 0])); 
        Mass m3 = new Mass(1, .5, new Vector3D([0, 0, 0]));
        Mass m4 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        ClothPiece c = new ClothPiece([m1, m2, m3, m4]); 
        c.Connect(0, 1, 5, .5); 
        c.Connect(1, 3, 5, .5); 
        c.Connect(3, 2, 5, .5); 
        c.Connect(2, 0, 5, .5);
        Console.WriteLine(c);

        EulerMethod euler = new EulerMethod(); 
        double dt = 0.01;
        double time = 0.0 ;

        Console.WriteLine("Simulating the system for one tenth of a second: ");
        for (int n = 0; n < 10; n++)
        {
            time += dt;
            foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();;
            }
            foreach (Mass m in c.GetMasses())
            {
                m.UpdateVelocityPosition(euler, dt);
            }
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestConstantForce()
    {
        Console.WriteLine("TESTING ConstantForce");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5, new Vector3D([0, 1, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([1, 1, 0])); 
        Mass m3 = new Mass(1, .5, new Vector3D([0, 0, 0]));
        Mass m4 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        ClothPiece c = new ClothPiece([m1, m2, m3, m4]); 
        c.Connect(0, 1, 5, .5); 
        c.Connect(1, 3, 5, .5); 
        c.Connect(3, 2, 5, .5); 
        c.Connect(2, 0, 5, .5);
        Console.WriteLine(c);

        EulerMethod euler = new EulerMethod(); 
        double dt = 0.01;
        double time = 0.0 ;

        Console.WriteLine("Instanciating a downwards constant force with no start and no end: ");
        ConstantForce gravity = new ConstantForce(new Vector3D(0, 0, -9.81)); 
        List<ExternalForce> externalForces = [gravity];
        Console.WriteLine("Simulating the system for one tenth of a second: ");
        for (int n = 0; n < 10; n++)
        {
            time += dt;
            foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                Vector3D totalExternalForce = new Vector3D();
                foreach (ExternalForce externalForce in externalForces) 
                {
                    if (externalForce.Applies(m, time)) {totalExternalForce += externalForce.Force(m, time);}
                }                
                m.AddExternalForce(totalExternalForce);
            }
            foreach (Mass m in c.GetMasses())
            {
                m.UpdateVelocityPosition(euler, dt); 
            }
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestDrag()
    {
        Console.WriteLine("TESTING Drag");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5, new Vector3D([0, 1, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([1, 1, 0])); 
        Mass m3 = new Mass(1, .5, new Vector3D([0, 0, 0]));
        Mass m4 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        ClothPiece c = new ClothPiece([m1, m2, m3, m4]); 
        c.Connect(0, 1, 5, .5); 
        c.Connect(1, 3, 5, .5); 
        c.Connect(3, 2, 5, .5); 
        c.Connect(2, 0, 5, .5);
        Console.WriteLine(c);

        EulerMethod euler = new EulerMethod(); 
        double dt = 0.01;
        double time = 0.0 ;

        Console.WriteLine("Instanciating a perpetual wind of velocity (0, 0, 1): ");
        Drag wind = new Drag(new Vector3D(0, 0, 1)); 
        List<ExternalForce> externalForces = [wind];
        Console.WriteLine("Simulating the system for one tenth of a second: ");
        for (int n = 0; n < 10; n++)
        {
            time += dt;
            foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                Vector3D totalExternalForce = new Vector3D();
                foreach (ExternalForce externalForce in externalForces) 
                {
                    if (externalForce.Applies(m, time)) {totalExternalForce += externalForce.Force(m, time);}
                }                
                m.AddExternalForce(totalExternalForce);
            }
            foreach (Mass m in c.GetMasses())
            {
                m.UpdateVelocityPosition(euler, dt); 
            }
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
        Console.WriteLine("This simulation is to be compared with TestClothPiece, in which the same system is simulated withtout wind.");
    }
    
    public static void TestHook()
    {
        Console.WriteLine("TESTING Hook");
        Console.WriteLine("Instanciating a piece of cloth with three masses in an L shape: ");
        Mass m1 = new Mass(1, .5, new Vector3D([0, 1, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([0, 0, 0]));
        Mass m3 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        ClothPiece c = new ClothPiece([m1, m2, m3]); 
        c.Connect(0, 1, 5, .5);
        c.Connect(1, 2, 5, .5);
        Console.WriteLine(c);

        EulerMethod euler = new EulerMethod(); 
        double dt = 0.01;
        double time = 0.0 ;

        Console.WriteLine("Instanciating a hook on mass m1 (top of the L): ");
        Hook hook = new Hook([m1]); 
        List<ExternalForce> externalForces = [hook];
        Console.WriteLine("Simulating the system for one tenth of a second: ");
        for (int n = 0; n < 10; n++)
        {
            time += dt;
            foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                Vector3D totalExternalForce = new Vector3D();
                foreach (ExternalForce externalForce in externalForces) 
                {
                    if (externalForce.Applies(m, time)) {totalExternalForce += externalForce.Force(m, time);}
                }                
                m.AddExternalForce(totalExternalForce);
            }
            foreach (Mass m in c.GetMasses())
            {
                m.UpdateVelocityPosition(euler, dt); 
            }
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestPush()
    {
        Console.WriteLine("TESTING Push");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5, new Vector3D([0, 1, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([1, 1, 0])); 
        Mass m3 = new Mass(1, .5, new Vector3D([0, 0, 0]));
        Mass m4 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        ClothPiece c = new ClothPiece([m1, m2, m3, m4]); 
        c.Connect(0, 1, 5, .5); 
        c.Connect(1, 3, 5, .5); 
        c.Connect(3, 2, 5, .5); 
        c.Connect(2, 0, 5, .5);
        Console.WriteLine(c);

        EulerMethod euler = new EulerMethod(); 
        double dt = 0.01;
        double time = 0.0 ;

        Console.WriteLine("Instanciating an upward push on mass m1 (top left vertex): ");
        Push push = new Push([m1], new Vector3D(0, 0, 5), 0.0, 0.015); 
        List<ExternalForce> externalForces = [push];
        Console.WriteLine("Simulating the system for one tenth of a second: ");
        for (int n = 0; n < 10; n++)
        {
            time += dt;
            foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                Vector3D totalExternalForce = new Vector3D();
                foreach (ExternalForce externalForce in externalForces) 
                {
                    if (externalForce.Applies(m, time)) {totalExternalForce += externalForce.Force(m, time);}
                }                
                m.AddExternalForce(totalExternalForce);
            }
            foreach (Mass m in c.GetMasses())
            {
                m.UpdateVelocityPosition(euler, dt); 
            }
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestPhysicalSystem()
    {
        Console.WriteLine("TESTING PhysicalSystem");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5, new Vector3D([0, 1, 0])); 
        Mass m2 = new Mass(1, .5, new Vector3D([1, 1, 0])); 
        Mass m3 = new Mass(1, .5, new Vector3D([0, 0, 0]));
        Mass m4 = new Mass(1, .5, new Vector3D([1, 0, 0]));
        ClothPiece c = new ClothPiece([m1, m2, m3, m4]); 
        c.Connect(0, 1, 5, .5); 
        c.Connect(1, 3, 5, .5); 
        c.Connect(3, 2, 5, .5); 
        c.Connect(2, 0, 5, .5);
        Console.WriteLine(c);        

        Console.WriteLine("Instanciating a hook on mass m1 (top left vertex)");
        Hook hook = new Hook([m1]); 
        Console.WriteLine("Instanciating an upward push on mass m4 (bottom right vertex)");
        Push push = new Push([m4], new Vector3D(0, 0, 5), 0.0, 0.015); 
        Console.WriteLine("Instanciating a perpetual wind of velocity (0, 1, 0)");
        Drag wind = new Drag(new Vector3D(0, 1, 0)); 
        Console.WriteLine("Instanciating a perpetual downwards constant force with no start and no end");
        ConstantForce gravity = new ConstantForce(new Vector3D(0, 0, -9.81)); 

        Console.WriteLine("Instanciating a physical system with the above-mentioned piece of cloth and external forces");
        PhysicalSystem system = new PhysicalSystem([c], [hook, push, wind, gravity]);

        EulerMethod euler = new EulerMethod(); 
        double dt = 0.01;

        Console.WriteLine("Simulating the system for one tenth of a second: ");
        for (int n = 0; n < 10; n++)
        {
            system.Update(euler, dt);
            Console.WriteLine(system);
        }
    }
}