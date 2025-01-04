namespace Push{
using Mass;
using Vector3D;
using ExternalForce;
using ClothPiece;
using System.Collections.Generic;

class Push : ExternalForce
{
    private readonly List<Mass> affectedMasses;
    private readonly Vector3D force;


    //Construtors 

    public Push(List<Mass> affectedMasses_, Vector3D force_, float? start_ = null, float? end_ = null) 
    {
        force = force_;
        affectedMasses = affectedMasses_;
        base.start = start_;
        base.end = end_;
    }

    //Use this constructor to push all the masses in a spherical area. 
    public Push(Vector3D center, float radius, List<ClothPiece> clothPieces, Vector3D force_, float? start_ = null, float? end_ = null) 
    {
        force = force_;
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

    public override bool Applies(Mass m , float time) {return base.InTimeInterval(time) && affectedMasses.Contains(m);} 
    public override Vector3D Force(Mass m, float time) {return new Vector3D(force);}
}
}



