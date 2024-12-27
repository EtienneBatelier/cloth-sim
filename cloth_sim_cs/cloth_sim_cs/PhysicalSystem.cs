namespace PhysicalSystem;
using ClothPiece;
using ExternalForce;
using IntegrationMethod;
using Mass;
using Vector3D;

class PhysicalSystem
{
    private readonly List<ClothPiece> clothPieces;
    private readonly List<ExternalForce> externalForces;
    private double time;


    //Constructor

    public PhysicalSystem(List<ClothPiece> clothPieces_, List<ExternalForce> externalForces_, double initialTime = 0)
    {
        clothPieces = clothPieces_;
        externalForces = externalForces_;
        time = initialTime;
    }

    //ToString method
    public override string ToString()
    {
        string toReturn = "";
        toReturn += "time = " + time + "\n";
        foreach (ClothPiece c in clothPieces) 
        {
            toReturn += "Cloth " + GetHashCode() + "\n";
            toReturn += c.ToString();
            toReturn += "\n";
        }
        return toReturn;
    }


    //Other methods

    public void Update(IntegrationMethod intMeth, double dt)
    {
        time += dt;
        foreach (ClothPiece c in clothPieces)
        {
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
                m.UpdateVelocityPosition(intMeth, dt); 
            }
        }
    }
}