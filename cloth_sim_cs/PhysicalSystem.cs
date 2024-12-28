namespace PhysicalSystem;
using ClothPiece;
using ExternalForce;
using IntegrationMethod;
using Mass;
using Vector3D;
using Hook;

class PhysicalSystem
{
    private readonly List<ClothPiece> clothPieces;
    private readonly List<ExternalForce> externalForces;
    private double time;


    //Constructor

    public PhysicalSystem(List<ClothPiece> clothPieces_, List<ExternalForce> externalForces_, double initialTime = 0)
    {
        clothPieces = clothPieces_;
        time = initialTime;
        externalForces = externalForces_;
        for (int i = externalForces.Count - 1; i > -1; i--)
        {
            if (externalForces[i] is Hook) 
            {
                externalForces.Add(externalForces[i]);
                externalForces.RemoveAt(i);
            }
        }
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

    public void Initialize()
    {
        foreach (ClothPiece c in clothPieces)
        {
            foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                foreach (ExternalForce externalForce in externalForces) 
                {
                    if (externalForce.Applies(m, time)) {m.AddExternalForce(externalForce.Force(m, time));}
                }                
            }
        }
    }

    public void Update(IntegrationMethod intMeth, double dt)
    {
        foreach (ClothPiece c in clothPieces)
        {
            foreach (Mass m in c.GetMasses())
            {
                intMeth.UpdateForceVelocityPosition(m, externalForces, time, dt); 
            }
        }
        time += dt;
    }
}