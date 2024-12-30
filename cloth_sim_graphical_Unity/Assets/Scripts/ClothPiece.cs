namespace ClothPiece{
using Vector3D;
using Mass;
using System.Collections.Generic;
using Spring;

class ClothPiece
{
    public List<Mass> masses;
    private List<Spring> springs;

    //Constructor

    public ClothPiece(List<Mass> masses_) {masses = masses_; springs = new List<Spring>();}


    //Get and ToString() methods

    public List<Mass> GetMasses() {return masses;}
    public override string ToString()
    {
        string toReturn = "";
        foreach (Mass mass in masses) 
        {
            toReturn += mass.ToString();
            toReturn += "\n";
        }
        return toReturn;
    }


    //Other methods

    public void Connect(int idx1, int idx2, float stiffness, float restLength)
    {
        springs.Add(new Spring(masses[idx1], masses[idx2], stiffness, restLength));
    }

    //Testing methods

    public List<Spring> GetSprings() {return springs;}
}
}
