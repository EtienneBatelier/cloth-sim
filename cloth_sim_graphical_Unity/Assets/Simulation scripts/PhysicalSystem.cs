namespace PhysicalSystem{
using ClothPiece;
using ExternalForce;
using IntegrationMethod;
using Mass;
using Hook;
using System.Collections.Generic;

class PhysicalSystem
{
    public List<ClothPiece> clothPieces;
    public List<ExternalForce> externalForces;
    private float time;


    //Constructor

    public PhysicalSystem(List<ClothPiece> clothPieces_, List<ExternalForce> externalForces_, float initialTime = 0)
    {
        clothPieces = clothPieces_;
        time = initialTime;
        externalForces = externalForces_;
        TidyExternalForces();
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


    public void TidyExternalForces()
    {
        for (int i = externalForces.Count - 1; i > -1; i--)
        {
            if (externalForces[i] is Hook) 
            {
                externalForces.Add(externalForces[i]);
                externalForces.RemoveAt(i);
            }
        }
    }

    public void Initialize()
    {
        foreach (ClothPiece c in clothPieces)
        {
            foreach (Mass m in c.GetMasses())
            {
                m.SetInnerForce();
                IntegrationMethod.UpdateForce(m, externalForces, time); 
            }
        }
    }

    public void Update(IntegrationMethod integrationMethod, float dt)
    {
        foreach (ClothPiece c in clothPieces)
        {
            foreach (Mass m in c.GetMasses())
            {
                integrationMethod.UpdateForceVelocityPosition(m, externalForces, time, dt); 
            }
        }
        time += dt;
    }
}
}