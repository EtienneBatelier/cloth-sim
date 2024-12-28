namespace Push;
using Mass;
using Vector3D;
using ExternalForce;
using ClothPiece;

class Push : ExternalForce
{
    private readonly List<Mass> affectedMasses;
    private readonly Vector3D force;


    //Construtors 

    public Push(List<Mass> affectedMasses_, Vector3D force_, double? start_ = null, double? end_ = null) 
    {
        force = force_;
        affectedMasses = affectedMasses_;
        base.start = start_;
        base.end = end_;
    }

    public Push(Vector3D center, double radius, List<ClothPiece> clothPieces, Vector3D force_, double? start_ = null, double? end_ = null) 
    {
        force = force_;
        base.start = start_;
        base.end = end_;
        affectedMasses = [];
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
    public override Vector3D Force(Mass m, double time) {return new Vector3D(force);}
}




