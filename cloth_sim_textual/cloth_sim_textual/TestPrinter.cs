namespace TestPrinter{
using Vector3D;
using ExternalForce;
using Mass;
using Spring; 
using EulerMethod;
using NewmarkMethod;
using ClothPiece;
using Drag;
using Hook;
using Push;
using PhysicalSystem;
using Gravity;

class TestPrinter
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
        Vector3D v = new Vector3D(1.0f, 2.0f, 3.0f);
        Vector3D w = new Vector3D(v);
        Console.Write("Printing u: "); 
        Console.WriteLine(u); 
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
        Console.WriteLine(origin.Equals(new Vector3D(0.0f, 0.0f, 0.0f)));
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
        Mass m1 = new Mass(1, .5f, new Vector3D(-1, 0, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(0, 0, 0)); 
        Mass m3 = new Mass(1, .5f, new Vector3D(1, 0, 0));
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

    public static void TestEulerMethod()
    {
        Console.WriteLine("TESTING EulerMethod");
        Console.WriteLine("Instanciating three masses connected by two springs in an L shape");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m3 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        Spring s1 = new Spring(m1, m2, 5, .5f);
        Spring s2 = new Spring(m2, m3, 5, .5f); 

        Console.WriteLine("Instanciating Euler's integration method");
        EulerMethod euler = new EulerMethod(); 
        float dt = 0.01f;
        float time = 0;

        Console.WriteLine("Initializing the system: ");
        m1.SetInnerForce();
        m2.SetInnerForce();
        m3.SetInnerForce();
        Console.WriteLine("t = " + time);
        Console.WriteLine(m1);
        Console.WriteLine(m2);
        Console.WriteLine(m3);

        Console.WriteLine("Simulating the system for half a second: ");
        for (int n = 0; n < 50; n++)
        {
            euler.UpdateForceVelocityPosition(m1, new List<ExternalForce>{}, time, dt);
            euler.UpdateForceVelocityPosition(m2, new List<ExternalForce>{}, time, dt);
            euler.UpdateForceVelocityPosition(m3, new List<ExternalForce>{}, time, dt);
            time += dt;
            Console.WriteLine("t = " + time);
            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m3);
        }
    }

    public static void TestNewmarkMethod()
    {
        Console.WriteLine("TESTING NewmarkMethod");
        Console.WriteLine("Instanciating three masses connected by two springs in an L shape");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m3 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        Spring s1 = new Spring(m1, m2, 5, .5f);
        Spring s2 = new Spring(m2, m3, 5, .5f);

        Console.WriteLine("Instanciating Newmark's integration method");
        NewmarkMethod newmark = new NewmarkMethod(); 
        float dt = 0.01f;
        float time = 0;

        Console.WriteLine("Initializing the system: ");
        m1.SetInnerForce();
        m2.SetInnerForce();
        m3.SetInnerForce();
        Console.WriteLine("t = " + time);
        Console.WriteLine(m1);
        Console.WriteLine(m2);
        Console.WriteLine(m3);

        Console.WriteLine("Simulating the system for half a second: ");
        for (int n = 0; n < 50; n++)
        {
            newmark.UpdateForceVelocityPosition(m1, new List<ExternalForce>{}, time, dt);
            newmark.UpdateForceVelocityPosition(m2, new List<ExternalForce>{}, time, dt);
            newmark.UpdateForceVelocityPosition(m3, new List<ExternalForce>{}, time, dt);
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
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(1, 1, 0)); 
        Mass m3 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m4 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        ClothPiece c = new ClothPiece(new List<Mass>{m1, m2, m3, m4}); 
        c.Connect(0, 1, 5, .5f); 
        c.Connect(1, 3, 5, .5f); 
        c.Connect(3, 2, 5, .5f); 
        c.Connect(2, 0, 5, .5f);

        Console.WriteLine("Instanciating Newmark's integration method");
        NewmarkMethod newmark = new NewmarkMethod(); 
        float dt = 0.01f;
        float time = 0;

        Console.WriteLine("Initializing the system: ");
        foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
            }
        Console.WriteLine("t = " + time);
        Console.WriteLine(c);

        Console.WriteLine("Simulating the system for half a second: ");
        for (int n = 0; n < 50; n++)
        {
            foreach (Mass m in c.GetMasses())
            {
                newmark.UpdateForceVelocityPosition(m, new List<ExternalForce>{}, time, dt);
            }
            time += dt;
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestGravity()
    {
        Console.WriteLine("TESTING Gravity");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(1, 1, 0)); 
        Mass m3 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m4 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        ClothPiece c = new ClothPiece(new List<Mass>{m1, m2, m3, m4}); 
        c.Connect(0, 1, 5, .5f); 
        c.Connect(1, 3, 5, .5f); 
        c.Connect(3, 2, 5, .5f); 
        c.Connect(2, 0, 5, .5f);

        Console.WriteLine("Instanciating Newmark's integration method");
        NewmarkMethod newmark = new NewmarkMethod(); 
        float dt = 0.01f;
        float time = 0;

        Console.WriteLine("Instanciating a perpetual downwards constant force");
        Gravity gravity = new Gravity(new Vector3D(0, 0, -9.81f)); 

        Console.WriteLine("Initializing the system: ");
        foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                if (gravity.Applies(m, time)) {m.AddForce(gravity.Force(m, time));}
            }
        Console.WriteLine("t = " + time);
        Console.WriteLine(c);

        Console.WriteLine("Simulating the system for half a second: ");
        for (int n = 0; n < 50; n++)
        {
            foreach (Mass m in c.GetMasses())
            {
                newmark.UpdateForceVelocityPosition(m, new List<ExternalForce>{gravity}, time, dt);
            }
            time += dt;
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestDrag()
    {
        Console.WriteLine("TESTING Drag");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(1, 1, 0)); 
        Mass m3 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m4 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        ClothPiece c = new ClothPiece(new List<Mass>{m1, m2, m3, m4}); 
        c.Connect(0, 1, 5, .5f); 
        c.Connect(1, 3, 5, .5f); 
        c.Connect(3, 2, 5, .5f); 
        c.Connect(2, 0, 5, .5f);

        Console.WriteLine("Instanciating Newmark's integration method");
        NewmarkMethod newmark = new NewmarkMethod(); 
        float dt = 0.01f;
        float time = 0;

        Console.WriteLine("Instanciating a perpetual wind of velocity (0, 0, 1): ");
        Drag wind = new Drag(new Vector3D(0, 0, 1)); 

        Console.WriteLine("Initializing the system: ");
        foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                if (wind.Applies(m, time)) {m.AddForce(wind.Force(m, time));}
            }
        Console.WriteLine("t = " + time);
        Console.WriteLine(c);

        Console.WriteLine("Simulating the system for half a second: ");
        for (int n = 0; n < 50; n++)
        {
            foreach (Mass m in c.GetMasses())
            {
                newmark.UpdateForceVelocityPosition(m, new List<ExternalForce>{wind}, time, dt);
            }
            time += dt;
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestHook()
    {
        Console.WriteLine("TESTING Hook");
        Console.WriteLine("Instanciating a piece of cloth with three masses in an L shape: ");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m3 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        ClothPiece c = new ClothPiece(new List<Mass>{m1, m2, m3}); 
        c.Connect(0, 1, 5, .5f);
        c.Connect(1, 2, 5, .5f);

        Console.WriteLine("Instanciating Newmark's integration method");
        NewmarkMethod newmark = new NewmarkMethod(); 
        float dt = 0.01f;
        float time = 0;

        Console.WriteLine("Instanciating a hook on mass m1 (top of the L): ");
        Hook hook = new Hook(new List<Mass>{m1}); 

        Console.WriteLine("Initializing the system: ");
        foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                if (hook.Applies(m, time)) {m.AddForce(hook.Force(m, time));}
            }
        Console.WriteLine("t = " + time);
        Console.WriteLine(c);

        Console.WriteLine("Simulating the system for half a second: ");
        for (int n = 0; n < 50; n++)
        {
            foreach (Mass m in c.GetMasses())
            {
                newmark.UpdateForceVelocityPosition(m, new List<ExternalForce>{hook}, time, dt);
            }
            time += dt;
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }
    
    public static void TestPush()
    {
        Console.WriteLine("TESTING Push");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(1, 1, 0)); 
        Mass m3 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m4 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        ClothPiece c = new ClothPiece(new List<Mass>{m1, m2, m3, m4}); 
        c.Connect(0, 1, 5, .5f); 
        c.Connect(1, 3, 5, .5f); 
        c.Connect(3, 2, 5, .5f); 
        c.Connect(2, 0, 5, .5f);

        Console.WriteLine("Instanciating Newmark's integration method");
        NewmarkMethod newmark = new NewmarkMethod(); 
        float dt = 0.01f;
        float time = 0;

        Console.WriteLine("Instanciating an upward push on mass m1 (top left vertex): ");
        Push push = new Push(new List<Mass>{m1}, new Vector3D(0, 0, 5), 0.0f, 0.015f); 

        Console.WriteLine("Initializing the system: ");
        foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                if (push.Applies(m, time)) {m.AddForce(push.Force(m, time));}
            }
        Console.WriteLine("t = " + time);
        Console.WriteLine(c);

        Console.WriteLine("Simulating the system for half a second: ");
        for (int n = 0; n < 50; n++)
        {
            foreach (Mass m in c.GetMasses())
            {
                newmark.UpdateForceVelocityPosition(m, new List<ExternalForce>{push}, time, dt);
            }
            time += dt;
            Console.WriteLine("t = " + time);
            Console.WriteLine(c);
        }
    }

    public static void TestPhysicalSystem()
    {
        Console.WriteLine("TESTING PhysicalSystem");
        Console.WriteLine("Instanciating a piece of cloth with four masses in a square: ");
        Mass m1 = new Mass(1, .5f, new Vector3D(0, 1, 0)); 
        Mass m2 = new Mass(1, .5f, new Vector3D(1, 1, 0)); 
        Mass m3 = new Mass(1, .5f, new Vector3D(0, 0, 0));
        Mass m4 = new Mass(1, .5f, new Vector3D(1, 0, 0));
        ClothPiece c = new ClothPiece(new List<Mass>{m1, m2, m3, m4}); 
        c.Connect(0, 1, 5, .5f); 
        c.Connect(1, 3, 5, .5f); 
        c.Connect(3, 2, 5, .5f); 
        c.Connect(2, 0, 5, .5f);

        Console.WriteLine("Instanciating Newmark's integration method");
        NewmarkMethod newmark = new NewmarkMethod(); 
        float dt = 0.01f;

        Console.WriteLine("Instanciating a hook on the top left vertex)");
        Hook hook = new Hook(new List<Mass>{m1}); 
        Console.WriteLine("Instanciating an upward push on the bottom right vertex)");
        Push push = new Push(new List<Mass>{m4}, new Vector3D(0, 0, 50), 0.0f, 0.015f); 
        Console.WriteLine("Instanciating a perpetual wind of velocity (0, 1, 0)");
        Drag wind = new Drag(new Vector3D(0, 1, 0)); 
        Console.WriteLine("Instanciating a perpetual downwards constant force");
        Gravity gravity = new Gravity(new Vector3D(0, 0, -9.81f)); 

        Console.WriteLine("Instanciating a physical system with the above-mentioned piece of cloth and external forces");
        PhysicalSystem system = new PhysicalSystem(new List<ClothPiece>{c}, new List<ExternalForce>{hook, push, wind, gravity});

        Console.WriteLine("Initializing and simulating the system for half a second: ");
        system.Initialize();
        Console.WriteLine(system);
        for (int n = 0; n < 50; n++)
        {
            system.Update(newmark, dt);
            Console.WriteLine(system);
        }
    }
}
}