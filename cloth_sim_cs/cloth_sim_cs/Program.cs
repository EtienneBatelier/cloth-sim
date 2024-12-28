
namespace cloth_sim_cs;
using TestPrinter;
using Vector3D; 
using Mass;
using Spring;

class Program
{
    static unsafe void Main()
    {
        //TestPrinter.TestVector3D();
        //TestPrinter.TestMassSpring();
        //TestPrinter.TestEulerMethod();
        //TestPrinter.TestNewmarkMethod();
        //TestPrinter.TestClothPiece();
        //TestPrinter.TestConstantForce();
        //TestPrinter.TestDrag();
        //TestPrinter.TestHook();
        //TestPrinter.TestPush();
        TestPrinter.TestPhysicalSystem();
    }
}