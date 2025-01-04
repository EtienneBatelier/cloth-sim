namespace ClothPiece{
using Mass;
using System.Collections.Generic;
using Spring;

//A class with a List of Masses and a List of Springs to represent a piece of cloth. 
//The Connect method takes two indices and creates a new spring between the corresponding masses in the List. 
unsafe class ClothPiece
{
    public List<Mass> masses;
    public List<Spring> springs;


    //Constructor

    public ClothPiece(List<Mass> masses_) {masses = masses_; springs = new List<Spring>();}
    public ClothPiece() {masses = new List<Mass>(); springs = new List<Spring>();}


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

    public void Connect(int idx1, int idx2, float* stiffness, float* restLength)
    {
        springs.Add(new Spring(masses[idx1], masses[idx2], stiffness, restLength));
    }


    //Testing methods (should remain as comments)

    //public List<Spring> GetSprings() {return springs;}
}
}
