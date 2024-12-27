
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
        //TestPrinter.TestIntegrationMethod();
        //TestPrinter.TestClothPiece();
        //TestPrinter.TestDrag();
        TestPrinter.TestPhysicalSystem();
    }
}