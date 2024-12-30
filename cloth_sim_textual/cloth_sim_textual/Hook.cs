namespace Hook{
using ExternalForce;
using System.Collections.Generic;
using Vector3D;
using Mass;
using ClothPiece;

class Hook : ExternalForce
{
    private readonly List<Mass> affectedMasses; 

    //Constructors

    public Hook(List<Mass> affectedMasses_, double? start_ = null, double? end_ = null) 
    {
        base.start = start_;
        base.end = end_;
        affectedMasses = affectedMasses_;
    }

    public Hook(Vector3D center, double radius, List<ClothPiece> clothPieces, double? start_ = null, double? end_ = null) 
    {
        base.start = start_;
        base.end = end_;
        affectedMasses = new List<Mass>();
        foreach (ClothPiece clothPiece in clothPieces)
        {
            foreach (Mass m in clothPiece.GetMasses())
            {
                if ((m.GetPosition() - center).SquaredNorm() <= radius*radius) {affectedMasses.Add(m);}
            }
        } 
    }

    //Other methods

    public override bool Applies(Mass m , double time) {return base.InTimeInterval(time) && affectedMasses.Contains(m);} 
    public override Vector3D Force(Mass m, double time) {return new Vector3D(-m.GetForce());}
}
}