namespace ClothPieceGraphicalUnity{

using System.Collections.Generic;
using ClothPiece;
using SpringGraphicalUnity;
using Mass;

unsafe class ClothPieceGraphicalUnity : ClothPiece
{
    //Constructors

    public ClothPieceGraphicalUnity(List<Mass> masses_) : base(masses_) {}
    public ClothPieceGraphicalUnity() : base(new List<Mass>()) {}


    //Other methods

    public void ConnectGraphicalUnity(int idx1, int idx2, float* stiffness, float* restLength)
    {
        base.springs.Add(new SpringGraphicalUnity(masses[idx1], masses[idx2], stiffness, restLength));
    }

    public void UpdateGraphicalPosition()
    {
        foreach (SpringGraphicalUnity spring in base.springs) {spring.UpdateGraphicalPosition();}
    }
}
}